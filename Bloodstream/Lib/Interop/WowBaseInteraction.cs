using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Bloodstream.Interfaces;
using Bloodstream.Lib.Injection;
using Bloodstream.Lib.Memory;
using Bloodstream.Patchables;
using Bloodstream.Patchables.DBC;

namespace Bloodstream.Lib
{
    public sealed partial class WowBase : INotifyPropertyChanged
    {
        #region corpse, rez, etc
        public void AcceptSpiritRessurection()
        {
            Lua.AcceptXPLoss();
        }
        #endregion

        #region vendor
        public List<MerchantItem> GetVendorInventory(IUnit target = null)
        {
            if (target.Valid() && OpenMerchantGUID != target.GUID)
                OpenGossip(target, GossipType.Vendor);

            return MerchantItems.ToList();
        }

        public List<MerchantItem> MerchantItems
        {
            get
            {
                return WowMemory.ConvertArray<MerchantItem>((uint)Merchants.MerchantItems, MerchantItemCount).ToList();
            }
        }
        public int MerchantItemCount
        {
            get
            {
                return WowMemory.Read<int>((uint)Merchants.MerchantItemCount);
            }
        }
        public ulong OpenMerchantGUID
        {
            get
            {
                return WowMemory.Read<ulong>((uint)Merchants.OpenMerchantGUID);
            }
        }
        #endregion

        #region gossip
        public void SelectGossipOption(GossipOption option)
        {
            Bridge.DoString(string.Format("SelectGossipOption({0})", option.Index));
        }

        public bool IsFrameShown(string frameName)
        {
            return Lua.IsFrameShown(frameName);
        }

        private bool IsGossipFrameShown()
        {
            return IsFrameShown("GossipFrame");
        }

        public bool IsQuestFrameShown()
        {
            return IsFrameShown("QuestFrame");
        }

        private bool IsTradeSkillFrameShown()
        {
            return IsFrameShown("TradeSkillFrame");
        }

        public bool IsVendorFrameShown()
        {
            return IsFrameShown("VendorFrame");
        }

        public List<GossipOption> OpenGossip(IUnit InteractNpc, GossipType gossipType)
        {
            using (var events = new Events())
            using (var handle = new EventWaitHandle(false, EventResetMode.ManualReset))
            {
                EventHandler<LuaEventArgs>
                    handleInteract = (event_name, args) => handle.Set();

                switch (gossipType)
                {
                    case GossipType.Gossip:
                        events.GossipShow += handleInteract;
                        break;
                    case GossipType.Vendor:
                        events.MerchantShow += handleInteract;
                        break;
                }

                InteractNpc.Interact();
                handle.WaitOne();

                return GetGossipOptions().Where(g => g.GossipType == gossipType).ToList();
            }
        }

        public List<GossipOption> GetGossipOptions()
        {
            var options = new List<GossipOption>();
            if (!IsGossipFrameShown())
                return options;

            var gossips = Lua.GetGossipOptions();
            int gossipCount = gossips.Length / 2;

            for (int i = 1; i <= gossipCount; i++)
            {
                int offset = 2 * (i - 1);
                options.Add(new GossipOption
                {
                    Index = i,
                    Text = gossips[offset],
                    GossipType = (GossipType)Enum.Parse(typeof(GossipType), gossips[offset + 1], true),
                });
            }

            return options;
        }
        #endregion

        #region train

        private void expandAllSkills(IUnit target)
        {
            for (int i = Lua.GetNumTrainerServices(); i >= 1; i--)
                if (Lua.GetTrainerServiceInfo(i).serviceType == SkillCategory.Header)
                    Lua.ExpandSkillHeader(i);
        }

        public List<TrainerSkill> GetTrainerSkills(IUnit target)
        {
            target.Interact();
            //B  expandAllSkills(target);
            Lua.SetTrainerServiceTypeFilter("available", 1);
            Lua.SetTrainerServiceTypeFilter("unavailable", 0);
            Lua.SetTrainerServiceTypeFilter("used", 0);
            var number = Lua.GetNumTrainerServices();
            var skills = new List<TrainerSkill>(number);

            for (int i = 1; i <= number; i++)
            {
                var service = Lua.GetTrainerServiceInfo(i);
                skills.Add(new TrainerSkill()
                {
                    Index = i,
                    Name = service.serviceName,
                    SubText = service.serviceSubText,
                    Category = service.serviceType,
                    Cost = Lua.GetTrainerServiceCost(i).moneyCost,
                    RequiredLevel = Lua.GetTrainerServiceLevelReq(i)
                });
            }

            return skills;
        }

        public void BuyTrainerSkill(int index)
        {
            Lua.BuyTrainerService(index);
        }
        #endregion

        #region quest

        public List<AvailableQuestOption> GetAvailableQuests(IUnit target)
        {
            var options = new List<AvailableQuestOption>();

            Lua.CloseQuest();
            Lua.CloseGossip();

            if (target.Valid())
                target.Interact();
            Thread.Sleep(1000);

            if (IsGossipFrameShown())
            {
                var count = Lua.GetNumGossipAvailableQuests();
                if (count > 0)
                {
                    var gossips = Lua.GetGossipAvailableQuests();
                    for (int i = 0; i < gossips.Length; i++)
                        options.Add(new AvailableQuestOption
                        {
                            Index = i + 1,
                            Title = gossips[i],
                            Level = Convert.ToInt32(gossips[++i]),
                            IsLowLevel = Lua.From1Nil(gossips[++i]),
                            IsDaily = Lua.From1Nil(gossips[++i]),
                            IsRepeatable = Lua.From1Nil(gossips[++i]),
                        });
                }
            }

            if (IsQuestFrameShown())
                for (int gossipIndex = 1; gossipIndex <= Lua.GetNumAvailableQuests(); gossipIndex++)
                    options.Add(new AvailableQuestOption
                    {
                        Index = gossipIndex,
                        Title = Lua.GetAvailableTitle(gossipIndex)
                    });

            return options;
        }

        public List<ActiveQuestOption> GetActiveQuests(IUnit target)
        {
            var options = new List<ActiveQuestOption>();
            Lua.CloseQuest();
            Lua.CloseGossip();
            target.Interact(); //nullrefexception

            System.Threading.Thread.Sleep(1000);

            if (IsQuestFrameShown())
            {
                for (int gossipIndex = 1; gossipIndex <= Lua.GetNumActiveQuests(); gossipIndex++)
                {
                    var title = Lua.GetActiveTitle(gossipIndex);
                    if (string.IsNullOrEmpty(title))
                        continue;

                    options.Add(new ActiveQuestOption()
                    {
                        Index = gossipIndex,
                        Title = title,
                        Level = Lua.GetActiveLevel(gossipIndex)
                    });
                }
            }

            if (IsGossipFrameShown())
            {
                var gossips = Lua.GetGossipActiveQuests();
                for (int gossipIndex = 1; gossipIndex <= Lua.GetNumGossipActiveQuests(); gossipIndex++)
                {
                    options.Add(new ActiveQuestOption
                    {
                        Index = gossipIndex,
                        Title = gossips[(gossipIndex - 1) * 4],
                    });
                }
            }

            return options;
        }

        public void SelectAvailableQuest(AvailableQuestOption quest)
        {
            if (IsGossipFrameShown())
                Lua.SelectGossipAvailableQuest(quest.Index);

            if (IsQuestFrameShown())
                Lua.SelectAvailableQuest(quest.Index);
        }

        public void SelectActiveQuest(ActiveQuestOption quest)
        {
            if (IsGossipFrameShown())
                Lua.SelectGossipActiveQuest(quest.Index);

            if (IsQuestFrameShown())
                Lua.SelectActiveQuest(quest.Index);
        }

        public void AcceptQuest()
        {
            Lua.AcceptQuest();
            Lua.CloseQuest();
        }

        public void CompleteQuest()
        {
            Lua.CompleteQuest();
        }

        public int GetNumQuestChoices()
        {
            return Lua.GetNumQuestChoices();
        }

        public List<QuestRewardInfo> GetQuestRewardChoices()
        {
            var rewards = new List<QuestRewardInfo>();
            var count = Lua.GetNumQuestChoices();

            //for (int i = 1; i <= count.numQuestChoices; i++)
            //{
            //    var luaReward = Lua.getquestchoi
            //    var reward = new QuestRewardInfo();
            //}

            return rewards;
        }

        public void GetQuestReward()
        {
            Lua.GetQuestReward();
        }
        public void GetQuestReward(int opt)
        {
            Lua.GetQuestReward(opt);
        }

        public List<int> GetQuestsCompleted()
        {
            Lua.QueryQuestsCompleted();
            Thread.Sleep(5000);
            return Lua.GetQuestsCompleted();
        }
        #endregion

        #region Mail
        public void SendMail(string recipient, string subject, string body)
        {
            Lua.SendMail(recipient, subject, body);
        }

        public void ClickSendMailItemButton()
        {
            Lua.ClickSendMailItemButton();
        }
        #endregion

        #region taxi
        public List<TaxiOption> GetTaxiOptions(IUnit target)
        {
            var options = new List<TaxiOption>();
            for (int i = 1; i <= Lua.NumTaxiNodes(); i++)
                options.Add(new TaxiOption()
                {
                    Index = i,
                    Name = Lua.TaxiNodeName(i)
                });

            return options;

        }

        public void TakeTaxi(TaxiOption option)
        {
            Lua.TakeTaxiNode(option.Index);
        }

        #endregion

        #region Zone and Continent
        public string ZoneText
        {
            get
            {
                return Lua.GetZoneText();
            }
        }

        public string ContinentText
        {
            get
            {
                var MapID = Bridge.GetMapID();
                var MapRecord = DBC.Instance[ClientDb.Map].GetRow(MapID).GetStruct<MapRecord>();

                return MapRecord.InternalName;
            }
        }
        #endregion

        #region Spells
        public void CastProfessionSpell(string profession, string spell, int repeat = 1, IItem item = null)
        {
            Lua.CastSpellByName(profession);
            Thread.Sleep(500);

            if (IsTradeSkillFrameShown())
            {
                TradeSkillInfo info = null;

                for (int i = 1; i <= Lua.GetNumTradeSkills(); i++)
                {
                    var luaInfo = Lua.GetTradeSkillInfo(i);
                    info = new TradeSkillInfo()
                    {
                        //skillName,skillType,numAvailable,isExpanded,serviceType
                        Index = i,
                        SkillName = luaInfo.skillName,
                        SkillType = luaInfo.skillType,
                        NumAvailable = luaInfo.numAvailable,
                        // IsExpanded = luaInfo.isExpanded==1?true:false,
                        Verb = luaInfo.serviceType

                    };

                    if (info.SkillName == spell)
                        break;
                }

                if (info != null)
                {
                    Lua.DoTradeSkill(info.Index, repeat);

                    if (item.Valid())
                        item.Use();

                    Lua.ReplaceEnchant();
                    Thread.Sleep(2000);
                    while (Me.IsCasting)
                        Thread.Sleep(100);
                }
            }
        }

        /*
        public bool GetSpellCooldown(uint spellID, out uint Start, out uint Duration, out uint Enable)
        {
            return Bridge.GetSpellCooldown(spellID, out Start, out Duration, out Enable);
        }

        public uint GetSpellCooldownRemaining(uint spellID)
        {
            uint Start, Duration, Enable;
            GetSpellCooldown(spellID, out Start, out Duration, out Enable);

            return Duration;
        }*/
        #endregion
    }
}