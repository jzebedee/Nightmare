using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public class LuaEventArgs : EventArgs
    {
        public LuaEventArgs(Stack<string> lua_stack)
        {
            Event = (WowEvents)Enum.Parse(typeof(WowEvents), lua_stack.First());
            Args = lua_stack.Skip(1).ToList();
        }

        public List<string> Args { get; private set; }
        public WowEvents Event { get; private set; }
    }

    public abstract class EventBase
    {
        public abstract void RegisterEvent(string event_name, EventHandler<LuaEventArgs> handler);
        public abstract void UnregisterEvent(string event_name, EventHandler<LuaEventArgs> handler);

        public event EventHandler<LuaEventArgs> SetGlueScreen
        {
            add
            {
                RegisterEvent("SET_GLUE_SCREEN", value);
            }
            remove
            {
                UnregisterEvent("SET_GLUE_SCREEN", value);
            }
        }
        public event EventHandler<LuaEventArgs> StartGlueMusic
        {
            add
            {
                RegisterEvent("START_GLUE_MUSIC", value);
            }
            remove
            {
                UnregisterEvent("START_GLUE_MUSIC", value);
            }
        }
        public event EventHandler<LuaEventArgs> DisconnectedFromServer
        {
            add
            {
                RegisterEvent("DISCONNECTED_FROM_SERVER", value);
            }
            remove
            {
                UnregisterEvent("DISCONNECTED_FROM_SERVER", value);
            }
        }
        public event EventHandler<LuaEventArgs> OpenStatusDialog
        {
            add
            {
                RegisterEvent("OPEN_STATUS_DIALOG", value);
            }
            remove
            {
                UnregisterEvent("OPEN_STATUS_DIALOG", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateStatusDialog
        {
            add
            {
                RegisterEvent("UPDATE_STATUS_DIALOG", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_STATUS_DIALOG", value);
            }
        }
        public event EventHandler<LuaEventArgs> CloseStatusDialog
        {
            add
            {
                RegisterEvent("CLOSE_STATUS_DIALOG", value);
            }
            remove
            {
                UnregisterEvent("CLOSE_STATUS_DIALOG", value);
            }
        }
        public event EventHandler<LuaEventArgs> AddonListUpdate
        {
            add
            {
                RegisterEvent("ADDON_LIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("ADDON_LIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CharacterListUpdate
        {
            add
            {
                RegisterEvent("CHARACTER_LIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CHARACTER_LIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateSelectedCharacter
        {
            add
            {
                RegisterEvent("UPDATE_SELECTED_CHARACTER", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_SELECTED_CHARACTER", value);
            }
        }
        public event EventHandler<LuaEventArgs> OpenRealmList
        {
            add
            {
                RegisterEvent("OPEN_REALM_LIST", value);
            }
            remove
            {
                UnregisterEvent("OPEN_REALM_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> GetPreferredRealmInfo
        {
            add
            {
                RegisterEvent("GET_PREFERRED_REALM_INFO", value);
            }
            remove
            {
                UnregisterEvent("GET_PREFERRED_REALM_INFO", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateSelectedRace
        {
            add
            {
                RegisterEvent("UPDATE_SELECTED_RACE", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_SELECTED_RACE", value);
            }
        }
        public event EventHandler<LuaEventArgs> SelectLastCharacter
        {
            add
            {
                RegisterEvent("SELECT_LAST_CHARACTER", value);
            }
            remove
            {
                UnregisterEvent("SELECT_LAST_CHARACTER", value);
            }
        }
        public event EventHandler<LuaEventArgs> SelectFirstCharacter
        {
            add
            {
                RegisterEvent("SELECT_FIRST_CHARACTER", value);
            }
            remove
            {
                UnregisterEvent("SELECT_FIRST_CHARACTER", value);
            }
        }
        public event EventHandler<LuaEventArgs> GlueScreenshotSucceeded
        {
            add
            {
                RegisterEvent("GLUE_SCREENSHOT_SUCCEEDED", value);
            }
            remove
            {
                UnregisterEvent("GLUE_SCREENSHOT_SUCCEEDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GlueScreenshotFailed
        {
            add
            {
                RegisterEvent("GLUE_SCREENSHOT_FAILED", value);
            }
            remove
            {
                UnregisterEvent("GLUE_SCREENSHOT_FAILED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PatchUpdateProgress
        {
            add
            {
                RegisterEvent("PATCH_UPDATE_PROGRESS", value);
            }
            remove
            {
                UnregisterEvent("PATCH_UPDATE_PROGRESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> PatchDownloaded
        {
            add
            {
                RegisterEvent("PATCH_DOWNLOADED", value);
            }
            remove
            {
                UnregisterEvent("PATCH_DOWNLOADED", value);
            }
        }
        public event EventHandler<LuaEventArgs> SuggestRealm
        {
            add
            {
                RegisterEvent("SUGGEST_REALM", value);
            }
            remove
            {
                UnregisterEvent("SUGGEST_REALM", value);
            }
        }
        public event EventHandler<LuaEventArgs> SuggestRealmWrongPvp
        {
            add
            {
                RegisterEvent("SUGGEST_REALM_WRONG_PVP", value);
            }
            remove
            {
                UnregisterEvent("SUGGEST_REALM_WRONG_PVP", value);
            }
        }
        public event EventHandler<LuaEventArgs> SuggestRealmWrongCategory
        {
            add
            {
                RegisterEvent("SUGGEST_REALM_WRONG_CATEGORY", value);
            }
            remove
            {
                UnregisterEvent("SUGGEST_REALM_WRONG_CATEGORY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ShowServerAlert
        {
            add
            {
                RegisterEvent("SHOW_SERVER_ALERT", value);
            }
            remove
            {
                UnregisterEvent("SHOW_SERVER_ALERT", value);
            }
        }
        public event EventHandler<LuaEventArgs> FramesLoaded
        {
            add
            {
                RegisterEvent("FRAMES_LOADED", value);
            }
            remove
            {
                UnregisterEvent("FRAMES_LOADED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ForceRenameCharacter
        {
            add
            {
                RegisterEvent("FORCE_RENAME_CHARACTER", value);
            }
            remove
            {
                UnregisterEvent("FORCE_RENAME_CHARACTER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ForceDeclineCharacter
        {
            add
            {
                RegisterEvent("FORCE_DECLINE_CHARACTER", value);
            }
            remove
            {
                UnregisterEvent("FORCE_DECLINE_CHARACTER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ShowSurveyNotification
        {
            add
            {
                RegisterEvent("SHOW_SURVEY_NOTIFICATION", value);
            }
            remove
            {
                UnregisterEvent("SHOW_SURVEY_NOTIFICATION", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerEnterPin
        {
            add
            {
                RegisterEvent("PLAYER_ENTER_PIN", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ENTER_PIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> ClientAccountMismatch
        {
            add
            {
                RegisterEvent("CLIENT_ACCOUNT_MISMATCH", value);
            }
            remove
            {
                UnregisterEvent("CLIENT_ACCOUNT_MISMATCH", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerEnterMatrix
        {
            add
            {
                RegisterEvent("PLAYER_ENTER_MATRIX", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ENTER_MATRIX", value);
            }
        }
        public event EventHandler<LuaEventArgs> ScandllError
        {
            add
            {
                RegisterEvent("SCANDLL_ERROR", value);
            }
            remove
            {
                UnregisterEvent("SCANDLL_ERROR", value);
            }
        }
        public event EventHandler<LuaEventArgs> ScandllDownloading
        {
            add
            {
                RegisterEvent("SCANDLL_DOWNLOADING", value);
            }
            remove
            {
                UnregisterEvent("SCANDLL_DOWNLOADING", value);
            }
        }
        public event EventHandler<LuaEventArgs> ScandllFinished
        {
            add
            {
                RegisterEvent("SCANDLL_FINISHED", value);
            }
            remove
            {
                UnregisterEvent("SCANDLL_FINISHED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ServerSplitNotice
        {
            add
            {
                RegisterEvent("SERVER_SPLIT_NOTICE", value);
            }
            remove
            {
                UnregisterEvent("SERVER_SPLIT_NOTICE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TimerAlert
        {
            add
            {
                RegisterEvent("TIMER_ALERT", value);
            }
            remove
            {
                UnregisterEvent("TIMER_ALERT", value);
            }
        }
        public event EventHandler<LuaEventArgs> AccountMessagesAvailable
        {
            add
            {
                RegisterEvent("ACCOUNT_MESSAGES_AVAILABLE", value);
            }
            remove
            {
                UnregisterEvent("ACCOUNT_MESSAGES_AVAILABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AccountMessagesHeadersLoaded
        {
            add
            {
                RegisterEvent("ACCOUNT_MESSAGES_HEADERS_LOADED", value);
            }
            remove
            {
                UnregisterEvent("ACCOUNT_MESSAGES_HEADERS_LOADED", value);
            }
        }
        public event EventHandler<LuaEventArgs> AccountMessagesBodyLoaded
        {
            add
            {
                RegisterEvent("ACCOUNT_MESSAGES_BODY_LOADED", value);
            }
            remove
            {
                UnregisterEvent("ACCOUNT_MESSAGES_BODY_LOADED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ClientTrial
        {
            add
            {
                RegisterEvent("CLIENT_TRIAL", value);
            }
            remove
            {
                UnregisterEvent("CLIENT_TRIAL", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerEnterToken
        {
            add
            {
                RegisterEvent("PLAYER_ENTER_TOKEN", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ENTER_TOKEN", value);
            }
        }
        public event EventHandler<LuaEventArgs> GameAccountsUpdated
        {
            add
            {
                RegisterEvent("GAME_ACCOUNTS_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("GAME_ACCOUNTS_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ClientConverted
        {
            add
            {
                RegisterEvent("CLIENT_CONVERTED", value);
            }
            remove
            {
                UnregisterEvent("CLIENT_CONVERTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPet
        {
            add
            {
                RegisterEvent("UNIT_PET", value);
            }
            remove
            {
                UnregisterEvent("UNIT_PET", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPet2
        {
            add
            {
                RegisterEvent("UNIT_PET_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_PET_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitTarget
        {
            add
            {
                RegisterEvent("UNIT_TARGET", value);
            }
            remove
            {
                UnregisterEvent("UNIT_TARGET", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitDisplaypower
        {
            add
            {
                RegisterEvent("UNIT_DISPLAYPOWER", value);
            }
            remove
            {
                UnregisterEvent("UNIT_DISPLAYPOWER", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitHealth
        {
            add
            {
                RegisterEvent("UNIT_HEALTH", value);
            }
            remove
            {
                UnregisterEvent("UNIT_HEALTH", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitMaxhealth
        {
            add
            {
                RegisterEvent("UNIT_MAXHEALTH", value);
            }
            remove
            {
                UnregisterEvent("UNIT_MAXHEALTH", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitLevel
        {
            add
            {
                RegisterEvent("UNIT_LEVEL", value);
            }
            remove
            {
                UnregisterEvent("UNIT_LEVEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitFaction
        {
            add
            {
                RegisterEvent("UNIT_FACTION", value);
            }
            remove
            {
                UnregisterEvent("UNIT_FACTION", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitFlags
        {
            add
            {
                RegisterEvent("UNIT_FLAGS", value);
            }
            remove
            {
                UnregisterEvent("UNIT_FLAGS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitFlags2
        {
            add
            {
                RegisterEvent("UNIT_FLAGS_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_FLAGS_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAttackSpeed
        {
            add
            {
                RegisterEvent("UNIT_ATTACK_SPEED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ATTACK_SPEED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAttackSpeed2
        {
            add
            {
                RegisterEvent("UNIT_ATTACK_SPEED_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ATTACK_SPEED_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitRangeddamage
        {
            add
            {
                RegisterEvent("UNIT_RANGEDDAMAGE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RANGEDDAMAGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitDamage
        {
            add
            {
                RegisterEvent("UNIT_DAMAGE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_DAMAGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitDamage2
        {
            add
            {
                RegisterEvent("UNIT_DAMAGE_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_DAMAGE_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitDamage3
        {
            add
            {
                RegisterEvent("UNIT_DAMAGE_3", value);
            }
            remove
            {
                UnregisterEvent("UNIT_DAMAGE_3", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitDamage4
        {
            add
            {
                RegisterEvent("UNIT_DAMAGE_4", value);
            }
            remove
            {
                UnregisterEvent("UNIT_DAMAGE_4", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPetExperience
        {
            add
            {
                RegisterEvent("UNIT_PET_EXPERIENCE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_PET_EXPERIENCE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPetExperience2
        {
            add
            {
                RegisterEvent("UNIT_PET_EXPERIENCE_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_PET_EXPERIENCE_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitDynamicFlags
        {
            add
            {
                RegisterEvent("UNIT_DYNAMIC_FLAGS", value);
            }
            remove
            {
                UnregisterEvent("UNIT_DYNAMIC_FLAGS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitStats
        {
            add
            {
                RegisterEvent("UNIT_STATS", value);
            }
            remove
            {
                UnregisterEvent("UNIT_STATS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitStats2
        {
            add
            {
                RegisterEvent("UNIT_STATS_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_STATS_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitStats3
        {
            add
            {
                RegisterEvent("UNIT_STATS_3", value);
            }
            remove
            {
                UnregisterEvent("UNIT_STATS_3", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitStats4
        {
            add
            {
                RegisterEvent("UNIT_STATS_4", value);
            }
            remove
            {
                UnregisterEvent("UNIT_STATS_4", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitStats5
        {
            add
            {
                RegisterEvent("UNIT_STATS_5", value);
            }
            remove
            {
                UnregisterEvent("UNIT_STATS_5", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances2
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances3
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_3", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_3", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances4
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_4", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_4", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances5
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_5", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_5", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances6
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_6", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_6", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances7
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_7", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_7", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances8
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_8", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_8", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances9
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_9", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_9", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances10
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_10", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_10", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances11
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_11", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_11", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances12
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_12", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_12", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances13
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_13", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_13", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances14
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_14", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_14", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances15
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_15", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_15", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances16
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_16", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_16", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances17
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_17", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_17", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances18
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_18", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_18", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances19
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_19", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_19", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances20
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_20", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_20", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitResistances21
        {
            add
            {
                RegisterEvent("UNIT_RESISTANCES_21", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RESISTANCES_21", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAttackPower
        {
            add
            {
                RegisterEvent("UNIT_ATTACK_POWER", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ATTACK_POWER", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAttackPower2
        {
            add
            {
                RegisterEvent("UNIT_ATTACK_POWER_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ATTACK_POWER_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAttackPower3
        {
            add
            {
                RegisterEvent("UNIT_ATTACK_POWER_3", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ATTACK_POWER_3", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAttackPower4
        {
            add
            {
                RegisterEvent("UNIT_ATTACK_POWER_4", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ATTACK_POWER_4", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitRangedAttackPower
        {
            add
            {
                RegisterEvent("UNIT_RANGED_ATTACK_POWER", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RANGED_ATTACK_POWER", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitRangedAttackPower2
        {
            add
            {
                RegisterEvent("UNIT_RANGED_ATTACK_POWER_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RANGED_ATTACK_POWER_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitRangedAttackPower3
        {
            add
            {
                RegisterEvent("UNIT_RANGED_ATTACK_POWER_3", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RANGED_ATTACK_POWER_3", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitRangedAttackPower4
        {
            add
            {
                RegisterEvent("UNIT_RANGED_ATTACK_POWER_4", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RANGED_ATTACK_POWER_4", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitRangeddamage2
        {
            add
            {
                RegisterEvent("UNIT_RANGEDDAMAGE_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RANGEDDAMAGE_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitRangeddamage3
        {
            add
            {
                RegisterEvent("UNIT_RANGEDDAMAGE_3", value);
            }
            remove
            {
                UnregisterEvent("UNIT_RANGEDDAMAGE_3", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitMana
        {
            add
            {
                RegisterEvent("UNIT_MANA", value);
            }
            remove
            {
                UnregisterEvent("UNIT_MANA", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitMana2
        {
            add
            {
                RegisterEvent("UNIT_MANA_2", value);
            }
            remove
            {
                UnregisterEvent("UNIT_MANA_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitStats6
        {
            add
            {
                RegisterEvent("UNIT_STATS_6", value);
            }
            remove
            {
                UnregisterEvent("UNIT_STATS_6", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAura
        {
            add
            {
                RegisterEvent("UNIT_AURA", value);
            }
            remove
            {
                UnregisterEvent("UNIT_AURA", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitCombat
        {
            add
            {
                RegisterEvent("UNIT_COMBAT", value);
            }
            remove
            {
                UnregisterEvent("UNIT_COMBAT", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitNameUpdate
        {
            add
            {
                RegisterEvent("UNIT_NAME_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_NAME_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPortraitUpdate
        {
            add
            {
                RegisterEvent("UNIT_PORTRAIT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_PORTRAIT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitModelChanged
        {
            add
            {
                RegisterEvent("UNIT_MODEL_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_MODEL_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitInventoryChanged
        {
            add
            {
                RegisterEvent("UNIT_INVENTORY_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_INVENTORY_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitClassificationChanged
        {
            add
            {
                RegisterEvent("UNIT_CLASSIFICATION_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_CLASSIFICATION_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitComboPoints
        {
            add
            {
                RegisterEvent("UNIT_COMBO_POINTS", value);
            }
            remove
            {
                UnregisterEvent("UNIT_COMBO_POINTS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitTargetableChanged
        {
            add
            {
                RegisterEvent("UNIT_TARGETABLE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_TARGETABLE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemLockChanged
        {
            add
            {
                RegisterEvent("ITEM_LOCK_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("ITEM_LOCK_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerXpUpdate
        {
            add
            {
                RegisterEvent("PLAYER_XP_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_XP_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerRegenDisabled
        {
            add
            {
                RegisterEvent("PLAYER_REGEN_DISABLED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_REGEN_DISABLED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerRegenEnabled
        {
            add
            {
                RegisterEvent("PLAYER_REGEN_ENABLED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_REGEN_ENABLED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerAurasChanged
        {
            add
            {
                RegisterEvent("PLAYER_AURAS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_AURAS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerEnterCombat
        {
            add
            {
                RegisterEvent("PLAYER_ENTER_COMBAT", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ENTER_COMBAT", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerLeaveCombat
        {
            add
            {
                RegisterEvent("PLAYER_LEAVE_COMBAT", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_LEAVE_COMBAT", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerTargetChanged
        {
            add
            {
                RegisterEvent("PLAYER_TARGET_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_TARGET_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerFocusChanged
        {
            add
            {
                RegisterEvent("PLAYER_FOCUS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_FOCUS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerControlLost
        {
            add
            {
                RegisterEvent("PLAYER_CONTROL_LOST", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_CONTROL_LOST", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerControlGained
        {
            add
            {
                RegisterEvent("PLAYER_CONTROL_GAINED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_CONTROL_GAINED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerFarsightFocusChanged
        {
            add
            {
                RegisterEvent("PLAYER_FARSIGHT_FOCUS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_FARSIGHT_FOCUS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerLevelUp
        {
            add
            {
                RegisterEvent("PLAYER_LEVEL_UP", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_LEVEL_UP", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerMoney
        {
            add
            {
                RegisterEvent("PLAYER_MONEY", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_MONEY", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerDamageDoneMods
        {
            add
            {
                RegisterEvent("PLAYER_DAMAGE_DONE_MODS", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_DAMAGE_DONE_MODS", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerTotemUpdate
        {
            add
            {
                RegisterEvent("PLAYER_TOTEM_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_TOTEM_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ZoneChanged
        {
            add
            {
                RegisterEvent("ZONE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("ZONE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ZoneChangedIndoors
        {
            add
            {
                RegisterEvent("ZONE_CHANGED_INDOORS", value);
            }
            remove
            {
                UnregisterEvent("ZONE_CHANGED_INDOORS", value);
            }
        }
        public event EventHandler<LuaEventArgs> ZoneChangedNewArea
        {
            add
            {
                RegisterEvent("ZONE_CHANGED_NEW_AREA", value);
            }
            remove
            {
                UnregisterEvent("ZONE_CHANGED_NEW_AREA", value);
            }
        }
        public event EventHandler<LuaEventArgs> MinimapUpdateZoom
        {
            add
            {
                RegisterEvent("MINIMAP_UPDATE_ZOOM", value);
            }
            remove
            {
                UnregisterEvent("MINIMAP_UPDATE_ZOOM", value);
            }
        }
        public event EventHandler<LuaEventArgs> MinimapUpdateTracking
        {
            add
            {
                RegisterEvent("MINIMAP_UPDATE_TRACKING", value);
            }
            remove
            {
                UnregisterEvent("MINIMAP_UPDATE_TRACKING", value);
            }
        }
        public event EventHandler<LuaEventArgs> ScreenshotSucceeded2
        {
            add
            {
                RegisterEvent("SCREENSHOT_SUCCEEDED_2", value);
            }
            remove
            {
                UnregisterEvent("SCREENSHOT_SUCCEEDED_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> ScreenshotFailed2
        {
            add
            {
                RegisterEvent("SCREENSHOT_FAILED_2", value);
            }
            remove
            {
                UnregisterEvent("SCREENSHOT_FAILED_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActionbarShowgrid
        {
            add
            {
                RegisterEvent("ACTIONBAR_SHOWGRID", value);
            }
            remove
            {
                UnregisterEvent("ACTIONBAR_SHOWGRID", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActionbarHidegrid
        {
            add
            {
                RegisterEvent("ACTIONBAR_HIDEGRID", value);
            }
            remove
            {
                UnregisterEvent("ACTIONBAR_HIDEGRID", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActionbarPageChanged
        {
            add
            {
                RegisterEvent("ACTIONBAR_PAGE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("ACTIONBAR_PAGE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActionbarSlotChanged
        {
            add
            {
                RegisterEvent("ACTIONBAR_SLOT_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("ACTIONBAR_SLOT_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActionbarUpdateState
        {
            add
            {
                RegisterEvent("ACTIONBAR_UPDATE_STATE", value);
            }
            remove
            {
                UnregisterEvent("ACTIONBAR_UPDATE_STATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActionbarUpdateUsable
        {
            add
            {
                RegisterEvent("ACTIONBAR_UPDATE_USABLE", value);
            }
            remove
            {
                UnregisterEvent("ACTIONBAR_UPDATE_USABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActionbarUpdateCooldown
        {
            add
            {
                RegisterEvent("ACTIONBAR_UPDATE_COOLDOWN", value);
            }
            remove
            {
                UnregisterEvent("ACTIONBAR_UPDATE_COOLDOWN", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateBonusActionbar
        {
            add
            {
                RegisterEvent("UPDATE_BONUS_ACTIONBAR", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_BONUS_ACTIONBAR", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyMembersChanged
        {
            add
            {
                RegisterEvent("PARTY_MEMBERS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PARTY_MEMBERS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyLeaderChanged
        {
            add
            {
                RegisterEvent("PARTY_LEADER_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PARTY_LEADER_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyMemberEnable
        {
            add
            {
                RegisterEvent("PARTY_MEMBER_ENABLE", value);
            }
            remove
            {
                UnregisterEvent("PARTY_MEMBER_ENABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyMemberDisable
        {
            add
            {
                RegisterEvent("PARTY_MEMBER_DISABLE", value);
            }
            remove
            {
                UnregisterEvent("PARTY_MEMBER_DISABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyLootMethodChanged
        {
            add
            {
                RegisterEvent("PARTY_LOOT_METHOD_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PARTY_LOOT_METHOD_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> Sysmsg
        {
            add
            {
                RegisterEvent("SYSMSG", value);
            }
            remove
            {
                UnregisterEvent("SYSMSG", value);
            }
        }
        public event EventHandler<LuaEventArgs> UiErrorMessage
        {
            add
            {
                RegisterEvent("UI_ERROR_MESSAGE", value);
            }
            remove
            {
                UnregisterEvent("UI_ERROR_MESSAGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UiInfoMessage
        {
            add
            {
                RegisterEvent("UI_INFO_MESSAGE", value);
            }
            remove
            {
                UnregisterEvent("UI_INFO_MESSAGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateChatColor
        {
            add
            {
                RegisterEvent("UPDATE_CHAT_COLOR", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_CHAT_COLOR", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgAddon
        {
            add
            {
                RegisterEvent("CHAT_MSG_ADDON", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_ADDON", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgSystem
        {
            add
            {
                RegisterEvent("CHAT_MSG_SYSTEM", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_SYSTEM", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgSay
        {
            add
            {
                RegisterEvent("CHAT_MSG_SAY", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_SAY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgParty
        {
            add
            {
                RegisterEvent("CHAT_MSG_PARTY", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_PARTY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgRaid
        {
            add
            {
                RegisterEvent("CHAT_MSG_RAID", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_RAID", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgGuild
        {
            add
            {
                RegisterEvent("CHAT_MSG_GUILD", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_GUILD", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgOfficer
        {
            add
            {
                RegisterEvent("CHAT_MSG_OFFICER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_OFFICER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgYell
        {
            add
            {
                RegisterEvent("CHAT_MSG_YELL", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_YELL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgWhisper
        {
            add
            {
                RegisterEvent("CHAT_MSG_WHISPER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_WHISPER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgWhisperInform
        {
            add
            {
                RegisterEvent("CHAT_MSG_WHISPER_INFORM", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_WHISPER_INFORM", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgEmote
        {
            add
            {
                RegisterEvent("CHAT_MSG_EMOTE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_EMOTE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgTextEmote
        {
            add
            {
                RegisterEvent("CHAT_MSG_TEXT_EMOTE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_TEXT_EMOTE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgMonsterSay
        {
            add
            {
                RegisterEvent("CHAT_MSG_MONSTER_SAY", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_MONSTER_SAY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgMonsterParty
        {
            add
            {
                RegisterEvent("CHAT_MSG_MONSTER_PARTY", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_MONSTER_PARTY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgMonsterYell
        {
            add
            {
                RegisterEvent("CHAT_MSG_MONSTER_YELL", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_MONSTER_YELL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgMonsterWhisper
        {
            add
            {
                RegisterEvent("CHAT_MSG_MONSTER_WHISPER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_MONSTER_WHISPER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgMonsterEmote
        {
            add
            {
                RegisterEvent("CHAT_MSG_MONSTER_EMOTE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_MONSTER_EMOTE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgChannel
        {
            add
            {
                RegisterEvent("CHAT_MSG_CHANNEL", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_CHANNEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgChannelJoin
        {
            add
            {
                RegisterEvent("CHAT_MSG_CHANNEL_JOIN", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_CHANNEL_JOIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgChannelLeave
        {
            add
            {
                RegisterEvent("CHAT_MSG_CHANNEL_LEAVE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_CHANNEL_LEAVE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgChannelList
        {
            add
            {
                RegisterEvent("CHAT_MSG_CHANNEL_LIST", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_CHANNEL_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgChannelNotice
        {
            add
            {
                RegisterEvent("CHAT_MSG_CHANNEL_NOTICE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_CHANNEL_NOTICE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgChannelNoticeUser
        {
            add
            {
                RegisterEvent("CHAT_MSG_CHANNEL_NOTICE_USER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_CHANNEL_NOTICE_USER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgAfk
        {
            add
            {
                RegisterEvent("CHAT_MSG_AFK", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_AFK", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgDnd
        {
            add
            {
                RegisterEvent("CHAT_MSG_DND", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_DND", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgIgnored
        {
            add
            {
                RegisterEvent("CHAT_MSG_IGNORED", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_IGNORED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgSkill
        {
            add
            {
                RegisterEvent("CHAT_MSG_SKILL", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_SKILL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgLoot
        {
            add
            {
                RegisterEvent("CHAT_MSG_LOOT", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_LOOT", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgMoney
        {
            add
            {
                RegisterEvent("CHAT_MSG_MONEY", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_MONEY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgOpening
        {
            add
            {
                RegisterEvent("CHAT_MSG_OPENING", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_OPENING", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgTradeskills
        {
            add
            {
                RegisterEvent("CHAT_MSG_TRADESKILLS", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_TRADESKILLS", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgPetInfo
        {
            add
            {
                RegisterEvent("CHAT_MSG_PET_INFO", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_PET_INFO", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgCombatMiscInfo
        {
            add
            {
                RegisterEvent("CHAT_MSG_COMBAT_MISC_INFO", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_COMBAT_MISC_INFO", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgCombatXpGain
        {
            add
            {
                RegisterEvent("CHAT_MSG_COMBAT_XP_GAIN", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_COMBAT_XP_GAIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgCombatHonorGain
        {
            add
            {
                RegisterEvent("CHAT_MSG_COMBAT_HONOR_GAIN", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_COMBAT_HONOR_GAIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgCombatFactionChange
        {
            add
            {
                RegisterEvent("CHAT_MSG_COMBAT_FACTION_CHANGE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_COMBAT_FACTION_CHANGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBgSystemNeutral
        {
            add
            {
                RegisterEvent("CHAT_MSG_BG_SYSTEM_NEUTRAL", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BG_SYSTEM_NEUTRAL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBgSystemAlliance
        {
            add
            {
                RegisterEvent("CHAT_MSG_BG_SYSTEM_ALLIANCE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BG_SYSTEM_ALLIANCE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBgSystemHorde
        {
            add
            {
                RegisterEvent("CHAT_MSG_BG_SYSTEM_HORDE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BG_SYSTEM_HORDE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgRaidLeader
        {
            add
            {
                RegisterEvent("CHAT_MSG_RAID_LEADER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_RAID_LEADER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgRaidWarning
        {
            add
            {
                RegisterEvent("CHAT_MSG_RAID_WARNING", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_RAID_WARNING", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgRaidBossWhisper
        {
            add
            {
                RegisterEvent("CHAT_MSG_RAID_BOSS_WHISPER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_RAID_BOSS_WHISPER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgRaidBossEmote
        {
            add
            {
                RegisterEvent("CHAT_MSG_RAID_BOSS_EMOTE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_RAID_BOSS_EMOTE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgFiltered
        {
            add
            {
                RegisterEvent("CHAT_MSG_FILTERED", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_FILTERED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBattleground
        {
            add
            {
                RegisterEvent("CHAT_MSG_BATTLEGROUND", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BATTLEGROUND", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBattlegroundLeader
        {
            add
            {
                RegisterEvent("CHAT_MSG_BATTLEGROUND_LEADER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BATTLEGROUND_LEADER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgRestricted
        {
            add
            {
                RegisterEvent("CHAT_MSG_RESTRICTED", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_RESTRICTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgAchievement
        {
            add
            {
                RegisterEvent("CHAT_MSG_ACHIEVEMENT", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_ACHIEVEMENT", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgGuildAchievement
        {
            add
            {
                RegisterEvent("CHAT_MSG_GUILD_ACHIEVEMENT", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_GUILD_ACHIEVEMENT", value);
            }
        }
        public event EventHandler<LuaEventArgs> LanguageListChanged
        {
            add
            {
                RegisterEvent("LANGUAGE_LIST_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("LANGUAGE_LIST_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TimePlayedMsg
        {
            add
            {
                RegisterEvent("TIME_PLAYED_MSG", value);
            }
            remove
            {
                UnregisterEvent("TIME_PLAYED_MSG", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellsChanged
        {
            add
            {
                RegisterEvent("SPELLS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("SPELLS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CurrentSpellCastChanged
        {
            add
            {
                RegisterEvent("CURRENT_SPELL_CAST_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("CURRENT_SPELL_CAST_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellUpdateCooldown
        {
            add
            {
                RegisterEvent("SPELL_UPDATE_COOLDOWN", value);
            }
            remove
            {
                UnregisterEvent("SPELL_UPDATE_COOLDOWN", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellUpdateUsable
        {
            add
            {
                RegisterEvent("SPELL_UPDATE_USABLE", value);
            }
            remove
            {
                UnregisterEvent("SPELL_UPDATE_USABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CharacterPointsChanged
        {
            add
            {
                RegisterEvent("CHARACTER_POINTS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("CHARACTER_POINTS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> SkillLinesChanged
        {
            add
            {
                RegisterEvent("SKILL_LINES_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("SKILL_LINES_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemPush
        {
            add
            {
                RegisterEvent("ITEM_PUSH", value);
            }
            remove
            {
                UnregisterEvent("ITEM_PUSH", value);
            }
        }
        public event EventHandler<LuaEventArgs> LootOpened
        {
            add
            {
                RegisterEvent("LOOT_OPENED", value);
            }
            remove
            {
                UnregisterEvent("LOOT_OPENED", value);
            }
        }
        public event EventHandler<LuaEventArgs> LootSlotCleared
        {
            add
            {
                RegisterEvent("LOOT_SLOT_CLEARED", value);
            }
            remove
            {
                UnregisterEvent("LOOT_SLOT_CLEARED", value);
            }
        }
        public event EventHandler<LuaEventArgs> LootSlotChanged
        {
            add
            {
                RegisterEvent("LOOT_SLOT_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("LOOT_SLOT_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> LootClosed
        {
            add
            {
                RegisterEvent("LOOT_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("LOOT_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerLogin
        {
            add
            {
                RegisterEvent("PLAYER_LOGIN", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_LOGIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerLogout
        {
            add
            {
                RegisterEvent("PLAYER_LOGOUT", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_LOGOUT", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerEnteringWorld
        {
            add
            {
                RegisterEvent("PLAYER_ENTERING_WORLD", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ENTERING_WORLD", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerLeavingWorld
        {
            add
            {
                RegisterEvent("PLAYER_LEAVING_WORLD", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_LEAVING_WORLD", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerAlive
        {
            add
            {
                RegisterEvent("PLAYER_ALIVE", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ALIVE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerDead
        {
            add
            {
                RegisterEvent("PLAYER_DEAD", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_DEAD", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerCamping
        {
            add
            {
                RegisterEvent("PLAYER_CAMPING", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_CAMPING", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerQuiting
        {
            add
            {
                RegisterEvent("PLAYER_QUITING", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_QUITING", value);
            }
        }
        public event EventHandler<LuaEventArgs> LogoutCancel
        {
            add
            {
                RegisterEvent("LOGOUT_CANCEL", value);
            }
            remove
            {
                UnregisterEvent("LOGOUT_CANCEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ResurrectRequest
        {
            add
            {
                RegisterEvent("RESURRECT_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("RESURRECT_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyInviteRequest
        {
            add
            {
                RegisterEvent("PARTY_INVITE_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("PARTY_INVITE_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyInviteCancel
        {
            add
            {
                RegisterEvent("PARTY_INVITE_CANCEL", value);
            }
            remove
            {
                UnregisterEvent("PARTY_INVITE_CANCEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildInviteRequest
        {
            add
            {
                RegisterEvent("GUILD_INVITE_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("GUILD_INVITE_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildInviteCancel
        {
            add
            {
                RegisterEvent("GUILD_INVITE_CANCEL", value);
            }
            remove
            {
                UnregisterEvent("GUILD_INVITE_CANCEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildMotd
        {
            add
            {
                RegisterEvent("GUILD_MOTD", value);
            }
            remove
            {
                UnregisterEvent("GUILD_MOTD", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeRequest
        {
            add
            {
                RegisterEvent("TRADE_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("TRADE_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeRequestCancel
        {
            add
            {
                RegisterEvent("TRADE_REQUEST_CANCEL", value);
            }
            remove
            {
                UnregisterEvent("TRADE_REQUEST_CANCEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> LootBindConfirm
        {
            add
            {
                RegisterEvent("LOOT_BIND_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("LOOT_BIND_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> EquipBindConfirm
        {
            add
            {
                RegisterEvent("EQUIP_BIND_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("EQUIP_BIND_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> AutoequipBindConfirm
        {
            add
            {
                RegisterEvent("AUTOEQUIP_BIND_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("AUTOEQUIP_BIND_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> UseBindConfirm
        {
            add
            {
                RegisterEvent("USE_BIND_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("USE_BIND_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> DeleteItemConfirm
        {
            add
            {
                RegisterEvent("DELETE_ITEM_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("DELETE_ITEM_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> CursorUpdate
        {
            add
            {
                RegisterEvent("CURSOR_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CURSOR_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemTextBegin
        {
            add
            {
                RegisterEvent("ITEM_TEXT_BEGIN", value);
            }
            remove
            {
                UnregisterEvent("ITEM_TEXT_BEGIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemTextTranslation
        {
            add
            {
                RegisterEvent("ITEM_TEXT_TRANSLATION", value);
            }
            remove
            {
                UnregisterEvent("ITEM_TEXT_TRANSLATION", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemTextReady
        {
            add
            {
                RegisterEvent("ITEM_TEXT_READY", value);
            }
            remove
            {
                UnregisterEvent("ITEM_TEXT_READY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemTextClosed
        {
            add
            {
                RegisterEvent("ITEM_TEXT_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("ITEM_TEXT_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GossipShow
        {
            add
            {
                RegisterEvent("GOSSIP_SHOW", value);
            }
            remove
            {
                UnregisterEvent("GOSSIP_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> GossipConfirm
        {
            add
            {
                RegisterEvent("GOSSIP_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("GOSSIP_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> GossipConfirmCancel
        {
            add
            {
                RegisterEvent("GOSSIP_CONFIRM_CANCEL", value);
            }
            remove
            {
                UnregisterEvent("GOSSIP_CONFIRM_CANCEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> GossipEnterCode
        {
            add
            {
                RegisterEvent("GOSSIP_ENTER_CODE", value);
            }
            remove
            {
                UnregisterEvent("GOSSIP_ENTER_CODE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GossipClosed
        {
            add
            {
                RegisterEvent("GOSSIP_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("GOSSIP_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestGreeting
        {
            add
            {
                RegisterEvent("QUEST_GREETING", value);
            }
            remove
            {
                UnregisterEvent("QUEST_GREETING", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestDetail
        {
            add
            {
                RegisterEvent("QUEST_DETAIL", value);
            }
            remove
            {
                UnregisterEvent("QUEST_DETAIL", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestProgress
        {
            add
            {
                RegisterEvent("QUEST_PROGRESS", value);
            }
            remove
            {
                UnregisterEvent("QUEST_PROGRESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestComplete
        {
            add
            {
                RegisterEvent("QUEST_COMPLETE", value);
            }
            remove
            {
                UnregisterEvent("QUEST_COMPLETE", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestFinished
        {
            add
            {
                RegisterEvent("QUEST_FINISHED", value);
            }
            remove
            {
                UnregisterEvent("QUEST_FINISHED", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestItemUpdate
        {
            add
            {
                RegisterEvent("QUEST_ITEM_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("QUEST_ITEM_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestAutocomplete
        {
            add
            {
                RegisterEvent("QUEST_AUTOCOMPLETE", value);
            }
            remove
            {
                UnregisterEvent("QUEST_AUTOCOMPLETE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TaximapOpened
        {
            add
            {
                RegisterEvent("TAXIMAP_OPENED", value);
            }
            remove
            {
                UnregisterEvent("TAXIMAP_OPENED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TaximapClosed
        {
            add
            {
                RegisterEvent("TAXIMAP_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("TAXIMAP_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestLogUpdate
        {
            add
            {
                RegisterEvent("QUEST_LOG_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("QUEST_LOG_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TrainerShow
        {
            add
            {
                RegisterEvent("TRAINER_SHOW", value);
            }
            remove
            {
                UnregisterEvent("TRAINER_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> TrainerUpdate
        {
            add
            {
                RegisterEvent("TRAINER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRAINER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TrainerDescriptionUpdate
        {
            add
            {
                RegisterEvent("TRAINER_DESCRIPTION_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRAINER_DESCRIPTION_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TrainerClosed
        {
            add
            {
                RegisterEvent("TRAINER_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("TRAINER_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CvarUpdate
        {
            add
            {
                RegisterEvent("CVAR_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CVAR_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeSkillShow
        {
            add
            {
                RegisterEvent("TRADE_SKILL_SHOW", value);
            }
            remove
            {
                UnregisterEvent("TRADE_SKILL_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeSkillUpdate
        {
            add
            {
                RegisterEvent("TRADE_SKILL_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRADE_SKILL_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeSkillNameUpdate
        {
            add
            {
                RegisterEvent("TRADE_SKILL_NAME_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRADE_SKILL_NAME_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeSkillClose
        {
            add
            {
                RegisterEvent("TRADE_SKILL_CLOSE", value);
            }
            remove
            {
                UnregisterEvent("TRADE_SKILL_CLOSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> MerchantShow
        {
            add
            {
                RegisterEvent("MERCHANT_SHOW", value);
            }
            remove
            {
                UnregisterEvent("MERCHANT_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> MerchantUpdate
        {
            add
            {
                RegisterEvent("MERCHANT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("MERCHANT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> MerchantClosed
        {
            add
            {
                RegisterEvent("MERCHANT_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("MERCHANT_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeShow
        {
            add
            {
                RegisterEvent("TRADE_SHOW", value);
            }
            remove
            {
                UnregisterEvent("TRADE_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeClosed
        {
            add
            {
                RegisterEvent("TRADE_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("TRADE_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeUpdate
        {
            add
            {
                RegisterEvent("TRADE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRADE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeAcceptUpdate
        {
            add
            {
                RegisterEvent("TRADE_ACCEPT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRADE_ACCEPT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeTargetItemChanged
        {
            add
            {
                RegisterEvent("TRADE_TARGET_ITEM_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("TRADE_TARGET_ITEM_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradePlayerItemChanged
        {
            add
            {
                RegisterEvent("TRADE_PLAYER_ITEM_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("TRADE_PLAYER_ITEM_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeMoneyChanged
        {
            add
            {
                RegisterEvent("TRADE_MONEY_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("TRADE_MONEY_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerTradeMoney
        {
            add
            {
                RegisterEvent("PLAYER_TRADE_MONEY", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_TRADE_MONEY", value);
            }
        }
        public event EventHandler<LuaEventArgs> BagOpen
        {
            add
            {
                RegisterEvent("BAG_OPEN", value);
            }
            remove
            {
                UnregisterEvent("BAG_OPEN", value);
            }
        }
        public event EventHandler<LuaEventArgs> BagUpdate
        {
            add
            {
                RegisterEvent("BAG_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("BAG_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BagClosed
        {
            add
            {
                RegisterEvent("BAG_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("BAG_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BagUpdateCooldown
        {
            add
            {
                RegisterEvent("BAG_UPDATE_COOLDOWN", value);
            }
            remove
            {
                UnregisterEvent("BAG_UPDATE_COOLDOWN", value);
            }
        }
        public event EventHandler<LuaEventArgs> LocalplayerPetRenamed
        {
            add
            {
                RegisterEvent("LOCALPLAYER_PET_RENAMED", value);
            }
            remove
            {
                UnregisterEvent("LOCALPLAYER_PET_RENAMED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitAttack3
        {
            add
            {
                RegisterEvent("UNIT_ATTACK_3", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ATTACK_3", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitDefense
        {
            add
            {
                RegisterEvent("UNIT_DEFENSE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_DEFENSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetAttackStart
        {
            add
            {
                RegisterEvent("PET_ATTACK_START", value);
            }
            remove
            {
                UnregisterEvent("PET_ATTACK_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetAttackStop
        {
            add
            {
                RegisterEvent("PET_ATTACK_STOP", value);
            }
            remove
            {
                UnregisterEvent("PET_ATTACK_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateMouseoverUnit
        {
            add
            {
                RegisterEvent("UPDATE_MOUSEOVER_UNIT", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_MOUSEOVER_UNIT", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastSent
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_SENT", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_SENT", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastStart
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_START", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastStop
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_STOP", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastFailed
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_FAILED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_FAILED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastFailedQuiet
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_FAILED_QUIET", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_FAILED_QUIET", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastInterrupted
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_INTERRUPTED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_INTERRUPTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastDelayed
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_DELAYED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_DELAYED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastSucceeded
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_SUCCEEDED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_SUCCEEDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastChannelStart
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_CHANNEL_START", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_CHANNEL_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastChannelUpdate
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_CHANNEL_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_CHANNEL_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastChannelStop
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_CHANNEL_STOP", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_CHANNEL_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastInterruptible
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_INTERRUPTIBLE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_INTERRUPTIBLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitSpellcastNotInterruptible
        {
            add
            {
                RegisterEvent("UNIT_SPELLCAST_NOT_INTERRUPTIBLE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_SPELLCAST_NOT_INTERRUPTIBLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerGuildUpdate
        {
            add
            {
                RegisterEvent("PLAYER_GUILD_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_GUILD_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestAcceptConfirm
        {
            add
            {
                RegisterEvent("QUEST_ACCEPT_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("QUEST_ACCEPT_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerbankslotsChanged
        {
            add
            {
                RegisterEvent("PLAYERBANKSLOTS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYERBANKSLOTS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BankframeOpened
        {
            add
            {
                RegisterEvent("BANKFRAME_OPENED", value);
            }
            remove
            {
                UnregisterEvent("BANKFRAME_OPENED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BankframeClosed
        {
            add
            {
                RegisterEvent("BANKFRAME_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("BANKFRAME_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerbankbagslotsChanged
        {
            add
            {
                RegisterEvent("PLAYERBANKBAGSLOTS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYERBANKBAGSLOTS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> FriendlistUpdate
        {
            add
            {
                RegisterEvent("FRIENDLIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("FRIENDLIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> IgnorelistUpdate
        {
            add
            {
                RegisterEvent("IGNORELIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("IGNORELIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> MutelistUpdate
        {
            add
            {
                RegisterEvent("MUTELIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("MUTELIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetBarUpdate
        {
            add
            {
                RegisterEvent("PET_BAR_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PET_BAR_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetBarUpdateCooldown
        {
            add
            {
                RegisterEvent("PET_BAR_UPDATE_COOLDOWN", value);
            }
            remove
            {
                UnregisterEvent("PET_BAR_UPDATE_COOLDOWN", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetBarShowgrid
        {
            add
            {
                RegisterEvent("PET_BAR_SHOWGRID", value);
            }
            remove
            {
                UnregisterEvent("PET_BAR_SHOWGRID", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetBarHidegrid
        {
            add
            {
                RegisterEvent("PET_BAR_HIDEGRID", value);
            }
            remove
            {
                UnregisterEvent("PET_BAR_HIDEGRID", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetBarHide2
        {
            add
            {
                RegisterEvent("PET_BAR_HIDE_2", value);
            }
            remove
            {
                UnregisterEvent("PET_BAR_HIDE_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetBarUpdateUsable
        {
            add
            {
                RegisterEvent("PET_BAR_UPDATE_USABLE", value);
            }
            remove
            {
                UnregisterEvent("PET_BAR_UPDATE_USABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> MinimapPing
        {
            add
            {
                RegisterEvent("MINIMAP_PING", value);
            }
            remove
            {
                UnregisterEvent("MINIMAP_PING", value);
            }
        }
        public event EventHandler<LuaEventArgs> MirrorTimerStart
        {
            add
            {
                RegisterEvent("MIRROR_TIMER_START", value);
            }
            remove
            {
                UnregisterEvent("MIRROR_TIMER_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> MirrorTimerPause
        {
            add
            {
                RegisterEvent("MIRROR_TIMER_PAUSE", value);
            }
            remove
            {
                UnregisterEvent("MIRROR_TIMER_PAUSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> MirrorTimerStop
        {
            add
            {
                RegisterEvent("MIRROR_TIMER_STOP", value);
            }
            remove
            {
                UnregisterEvent("MIRROR_TIMER_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> WorldMapUpdate
        {
            add
            {
                RegisterEvent("WORLD_MAP_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("WORLD_MAP_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> WorldMapNameUpdate
        {
            add
            {
                RegisterEvent("WORLD_MAP_NAME_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("WORLD_MAP_NAME_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AutofollowBegin
        {
            add
            {
                RegisterEvent("AUTOFOLLOW_BEGIN", value);
            }
            remove
            {
                UnregisterEvent("AUTOFOLLOW_BEGIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> AutofollowEnd
        {
            add
            {
                RegisterEvent("AUTOFOLLOW_END", value);
            }
            remove
            {
                UnregisterEvent("AUTOFOLLOW_END", value);
            }
        }
        public event EventHandler<LuaEventArgs> CinematicStart
        {
            add
            {
                RegisterEvent("CINEMATIC_START", value);
            }
            remove
            {
                UnregisterEvent("CINEMATIC_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> CinematicStop
        {
            add
            {
                RegisterEvent("CINEMATIC_STOP", value);
            }
            remove
            {
                UnregisterEvent("CINEMATIC_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateFaction
        {
            add
            {
                RegisterEvent("UPDATE_FACTION", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_FACTION", value);
            }
        }
        public event EventHandler<LuaEventArgs> CloseWorldMap
        {
            add
            {
                RegisterEvent("CLOSE_WORLD_MAP", value);
            }
            remove
            {
                UnregisterEvent("CLOSE_WORLD_MAP", value);
            }
        }
        public event EventHandler<LuaEventArgs> OpenTabardFrame
        {
            add
            {
                RegisterEvent("OPEN_TABARD_FRAME", value);
            }
            remove
            {
                UnregisterEvent("OPEN_TABARD_FRAME", value);
            }
        }
        public event EventHandler<LuaEventArgs> CloseTabardFrame
        {
            add
            {
                RegisterEvent("CLOSE_TABARD_FRAME", value);
            }
            remove
            {
                UnregisterEvent("CLOSE_TABARD_FRAME", value);
            }
        }
        public event EventHandler<LuaEventArgs> TabardCansaveChanged
        {
            add
            {
                RegisterEvent("TABARD_CANSAVE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("TABARD_CANSAVE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildRegistrarShow
        {
            add
            {
                RegisterEvent("GUILD_REGISTRAR_SHOW", value);
            }
            remove
            {
                UnregisterEvent("GUILD_REGISTRAR_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildRegistrarClosed
        {
            add
            {
                RegisterEvent("GUILD_REGISTRAR_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("GUILD_REGISTRAR_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> DuelRequested
        {
            add
            {
                RegisterEvent("DUEL_REQUESTED", value);
            }
            remove
            {
                UnregisterEvent("DUEL_REQUESTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> DuelOutofbounds
        {
            add
            {
                RegisterEvent("DUEL_OUTOFBOUNDS", value);
            }
            remove
            {
                UnregisterEvent("DUEL_OUTOFBOUNDS", value);
            }
        }
        public event EventHandler<LuaEventArgs> DuelInbounds
        {
            add
            {
                RegisterEvent("DUEL_INBOUNDS", value);
            }
            remove
            {
                UnregisterEvent("DUEL_INBOUNDS", value);
            }
        }
        public event EventHandler<LuaEventArgs> DuelFinished
        {
            add
            {
                RegisterEvent("DUEL_FINISHED", value);
            }
            remove
            {
                UnregisterEvent("DUEL_FINISHED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TutorialTrigger
        {
            add
            {
                RegisterEvent("TUTORIAL_TRIGGER", value);
            }
            remove
            {
                UnregisterEvent("TUTORIAL_TRIGGER", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetDismissStart
        {
            add
            {
                RegisterEvent("PET_DISMISS_START", value);
            }
            remove
            {
                UnregisterEvent("PET_DISMISS_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateBindings
        {
            add
            {
                RegisterEvent("UPDATE_BINDINGS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_BINDINGS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateShapeshiftForms
        {
            add
            {
                RegisterEvent("UPDATE_SHAPESHIFT_FORMS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_SHAPESHIFT_FORMS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateShapeshiftForm2
        {
            add
            {
                RegisterEvent("UPDATE_SHAPESHIFT_FORM_2", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_SHAPESHIFT_FORM_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateShapeshiftUsable
        {
            add
            {
                RegisterEvent("UPDATE_SHAPESHIFT_USABLE", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_SHAPESHIFT_USABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateShapeshiftCooldown
        {
            add
            {
                RegisterEvent("UPDATE_SHAPESHIFT_COOLDOWN", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_SHAPESHIFT_COOLDOWN", value);
            }
        }
        public event EventHandler<LuaEventArgs> WhoListUpdate
        {
            add
            {
                RegisterEvent("WHO_LIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("WHO_LIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetitionShow
        {
            add
            {
                RegisterEvent("PETITION_SHOW", value);
            }
            remove
            {
                UnregisterEvent("PETITION_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetitionClosed
        {
            add
            {
                RegisterEvent("PETITION_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("PETITION_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ExecuteChatLine
        {
            add
            {
                RegisterEvent("EXECUTE_CHAT_LINE", value);
            }
            remove
            {
                UnregisterEvent("EXECUTE_CHAT_LINE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateMacros
        {
            add
            {
                RegisterEvent("UPDATE_MACROS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_MACROS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateTicket
        {
            add
            {
                RegisterEvent("UPDATE_TICKET", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_TICKET", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateChatWindows
        {
            add
            {
                RegisterEvent("UPDATE_CHAT_WINDOWS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_CHAT_WINDOWS", value);
            }
        }
        public event EventHandler<LuaEventArgs> ConfirmXpLoss
        {
            add
            {
                RegisterEvent("CONFIRM_XP_LOSS", value);
            }
            remove
            {
                UnregisterEvent("CONFIRM_XP_LOSS", value);
            }
        }
        public event EventHandler<LuaEventArgs> CorpseInRange
        {
            add
            {
                RegisterEvent("CORPSE_IN_RANGE", value);
            }
            remove
            {
                UnregisterEvent("CORPSE_IN_RANGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CorpseInInstance
        {
            add
            {
                RegisterEvent("CORPSE_IN_INSTANCE", value);
            }
            remove
            {
                UnregisterEvent("CORPSE_IN_INSTANCE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CorpseOutOfRange
        {
            add
            {
                RegisterEvent("CORPSE_OUT_OF_RANGE", value);
            }
            remove
            {
                UnregisterEvent("CORPSE_OUT_OF_RANGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateGmStatus
        {
            add
            {
                RegisterEvent("UPDATE_GM_STATUS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_GM_STATUS", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerUnghost
        {
            add
            {
                RegisterEvent("PLAYER_UNGHOST", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_UNGHOST", value);
            }
        }
        public event EventHandler<LuaEventArgs> BindEnchant
        {
            add
            {
                RegisterEvent("BIND_ENCHANT", value);
            }
            remove
            {
                UnregisterEvent("BIND_ENCHANT", value);
            }
        }
        public event EventHandler<LuaEventArgs> ReplaceEnchant
        {
            add
            {
                RegisterEvent("REPLACE_ENCHANT", value);
            }
            remove
            {
                UnregisterEvent("REPLACE_ENCHANT", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeReplaceEnchant
        {
            add
            {
                RegisterEvent("TRADE_REPLACE_ENCHANT", value);
            }
            remove
            {
                UnregisterEvent("TRADE_REPLACE_ENCHANT", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradePotentialBindEnchant
        {
            add
            {
                RegisterEvent("TRADE_POTENTIAL_BIND_ENCHANT", value);
            }
            remove
            {
                UnregisterEvent("TRADE_POTENTIAL_BIND_ENCHANT", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerUpdateResting
        {
            add
            {
                RegisterEvent("PLAYER_UPDATE_RESTING", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_UPDATE_RESTING", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateExhaustion
        {
            add
            {
                RegisterEvent("UPDATE_EXHAUSTION", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_EXHAUSTION", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerFlagsChanged
        {
            add
            {
                RegisterEvent("PLAYER_FLAGS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_FLAGS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildRosterUpdate
        {
            add
            {
                RegisterEvent("GUILD_ROSTER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILD_ROSTER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GmPlayerInfo
        {
            add
            {
                RegisterEvent("GM_PLAYER_INFO", value);
            }
            remove
            {
                UnregisterEvent("GM_PLAYER_INFO", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailShow
        {
            add
            {
                RegisterEvent("MAIL_SHOW", value);
            }
            remove
            {
                UnregisterEvent("MAIL_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailClosed
        {
            add
            {
                RegisterEvent("MAIL_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("MAIL_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> SendMailMoneyChanged
        {
            add
            {
                RegisterEvent("SEND_MAIL_MONEY_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("SEND_MAIL_MONEY_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> SendMailCodChanged
        {
            add
            {
                RegisterEvent("SEND_MAIL_COD_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("SEND_MAIL_COD_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailSendInfoUpdate
        {
            add
            {
                RegisterEvent("MAIL_SEND_INFO_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("MAIL_SEND_INFO_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailSendSuccess
        {
            add
            {
                RegisterEvent("MAIL_SEND_SUCCESS", value);
            }
            remove
            {
                UnregisterEvent("MAIL_SEND_SUCCESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailInboxUpdate
        {
            add
            {
                RegisterEvent("MAIL_INBOX_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("MAIL_INBOX_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailLockSendItems
        {
            add
            {
                RegisterEvent("MAIL_LOCK_SEND_ITEMS", value);
            }
            remove
            {
                UnregisterEvent("MAIL_LOCK_SEND_ITEMS", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailUnlockSendItems
        {
            add
            {
                RegisterEvent("MAIL_UNLOCK_SEND_ITEMS", value);
            }
            remove
            {
                UnregisterEvent("MAIL_UNLOCK_SEND_ITEMS", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldsShow
        {
            add
            {
                RegisterEvent("BATTLEFIELDS_SHOW", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELDS_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldsClosed
        {
            add
            {
                RegisterEvent("BATTLEFIELDS_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELDS_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateBattlefieldStatus
        {
            add
            {
                RegisterEvent("UPDATE_BATTLEFIELD_STATUS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_BATTLEFIELD_STATUS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateBattlefieldScore
        {
            add
            {
                RegisterEvent("UPDATE_BATTLEFIELD_SCORE", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_BATTLEFIELD_SCORE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldQueueTimeout
        {
            add
            {
                RegisterEvent("BATTLEFIELD_QUEUE_TIMEOUT", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_QUEUE_TIMEOUT", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionHouseShow
        {
            add
            {
                RegisterEvent("AUCTION_HOUSE_SHOW", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_HOUSE_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionHouseClosed
        {
            add
            {
                RegisterEvent("AUCTION_HOUSE_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_HOUSE_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> NewAuctionUpdate
        {
            add
            {
                RegisterEvent("NEW_AUCTION_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("NEW_AUCTION_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionItemListUpdate
        {
            add
            {
                RegisterEvent("AUCTION_ITEM_LIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_ITEM_LIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionOwnedListUpdate
        {
            add
            {
                RegisterEvent("AUCTION_OWNED_LIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_OWNED_LIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionBidderListUpdate
        {
            add
            {
                RegisterEvent("AUCTION_BIDDER_LIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_BIDDER_LIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetUiUpdate
        {
            add
            {
                RegisterEvent("PET_UI_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PET_UI_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetUiClose
        {
            add
            {
                RegisterEvent("PET_UI_CLOSE", value);
            }
            remove
            {
                UnregisterEvent("PET_UI_CLOSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AddonLoaded
        {
            add
            {
                RegisterEvent("ADDON_LOADED", value);
            }
            remove
            {
                UnregisterEvent("ADDON_LOADED", value);
            }
        }
        public event EventHandler<LuaEventArgs> VariablesLoaded
        {
            add
            {
                RegisterEvent("VARIABLES_LOADED", value);
            }
            remove
            {
                UnregisterEvent("VARIABLES_LOADED", value);
            }
        }
        public event EventHandler<LuaEventArgs> MacroActionForbidden
        {
            add
            {
                RegisterEvent("MACRO_ACTION_FORBIDDEN", value);
            }
            remove
            {
                UnregisterEvent("MACRO_ACTION_FORBIDDEN", value);
            }
        }
        public event EventHandler<LuaEventArgs> AddonActionForbidden
        {
            add
            {
                RegisterEvent("ADDON_ACTION_FORBIDDEN", value);
            }
            remove
            {
                UnregisterEvent("ADDON_ACTION_FORBIDDEN", value);
            }
        }
        public event EventHandler<LuaEventArgs> MacroActionBlocked
        {
            add
            {
                RegisterEvent("MACRO_ACTION_BLOCKED", value);
            }
            remove
            {
                UnregisterEvent("MACRO_ACTION_BLOCKED", value);
            }
        }
        public event EventHandler<LuaEventArgs> AddonActionBlocked
        {
            add
            {
                RegisterEvent("ADDON_ACTION_BLOCKED", value);
            }
            remove
            {
                UnregisterEvent("ADDON_ACTION_BLOCKED", value);
            }
        }
        public event EventHandler<LuaEventArgs> StartAutorepeatSpell
        {
            add
            {
                RegisterEvent("START_AUTOREPEAT_SPELL", value);
            }
            remove
            {
                UnregisterEvent("START_AUTOREPEAT_SPELL", value);
            }
        }
        public event EventHandler<LuaEventArgs> StopAutorepeatSpell
        {
            add
            {
                RegisterEvent("STOP_AUTOREPEAT_SPELL", value);
            }
            remove
            {
                UnregisterEvent("STOP_AUTOREPEAT_SPELL", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetStableShow
        {
            add
            {
                RegisterEvent("PET_STABLE_SHOW", value);
            }
            remove
            {
                UnregisterEvent("PET_STABLE_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetStableUpdate
        {
            add
            {
                RegisterEvent("PET_STABLE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PET_STABLE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetStableUpdatePaperdoll
        {
            add
            {
                RegisterEvent("PET_STABLE_UPDATE_PAPERDOLL", value);
            }
            remove
            {
                UnregisterEvent("PET_STABLE_UPDATE_PAPERDOLL", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetStableClosed
        {
            add
            {
                RegisterEvent("PET_STABLE_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("PET_STABLE_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> RaidRosterUpdate
        {
            add
            {
                RegisterEvent("RAID_ROSTER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("RAID_ROSTER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdatePendingMail
        {
            add
            {
                RegisterEvent("UPDATE_PENDING_MAIL", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_PENDING_MAIL", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateInventoryAlerts
        {
            add
            {
                RegisterEvent("UPDATE_INVENTORY_ALERTS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_INVENTORY_ALERTS", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateInventoryDurability
        {
            add
            {
                RegisterEvent("UPDATE_INVENTORY_DURABILITY", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_INVENTORY_DURABILITY", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateTradeskillRecast
        {
            add
            {
                RegisterEvent("UPDATE_TRADESKILL_RECAST", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_TRADESKILL_RECAST", value);
            }
        }
        public event EventHandler<LuaEventArgs> OpenMasterLootList
        {
            add
            {
                RegisterEvent("OPEN_MASTER_LOOT_LIST", value);
            }
            remove
            {
                UnregisterEvent("OPEN_MASTER_LOOT_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateMasterLootList
        {
            add
            {
                RegisterEvent("UPDATE_MASTER_LOOT_LIST", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_MASTER_LOOT_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> StartLootRoll
        {
            add
            {
                RegisterEvent("START_LOOT_ROLL", value);
            }
            remove
            {
                UnregisterEvent("START_LOOT_ROLL", value);
            }
        }
        public event EventHandler<LuaEventArgs> CancelLootRoll
        {
            add
            {
                RegisterEvent("CANCEL_LOOT_ROLL", value);
            }
            remove
            {
                UnregisterEvent("CANCEL_LOOT_ROLL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ConfirmLootRoll
        {
            add
            {
                RegisterEvent("CONFIRM_LOOT_ROLL", value);
            }
            remove
            {
                UnregisterEvent("CONFIRM_LOOT_ROLL", value);
            }
        }
        public event EventHandler<LuaEventArgs> ConfirmDisenchantRoll
        {
            add
            {
                RegisterEvent("CONFIRM_DISENCHANT_ROLL", value);
            }
            remove
            {
                UnregisterEvent("CONFIRM_DISENCHANT_ROLL", value);
            }
        }
        public event EventHandler<LuaEventArgs> InstanceBootStart
        {
            add
            {
                RegisterEvent("INSTANCE_BOOT_START", value);
            }
            remove
            {
                UnregisterEvent("INSTANCE_BOOT_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> InstanceBootStop
        {
            add
            {
                RegisterEvent("INSTANCE_BOOT_STOP", value);
            }
            remove
            {
                UnregisterEvent("INSTANCE_BOOT_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> LearnedSpellInTab
        {
            add
            {
                RegisterEvent("LEARNED_SPELL_IN_TAB", value);
            }
            remove
            {
                UnregisterEvent("LEARNED_SPELL_IN_TAB", value);
            }
        }
        public event EventHandler<LuaEventArgs> DisplaySizeChanged
        {
            add
            {
                RegisterEvent("DISPLAY_SIZE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("DISPLAY_SIZE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ConfirmTalentWipe
        {
            add
            {
                RegisterEvent("CONFIRM_TALENT_WIPE", value);
            }
            remove
            {
                UnregisterEvent("CONFIRM_TALENT_WIPE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ConfirmBinder
        {
            add
            {
                RegisterEvent("CONFIRM_BINDER", value);
            }
            remove
            {
                UnregisterEvent("CONFIRM_BINDER", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailFailed
        {
            add
            {
                RegisterEvent("MAIL_FAILED", value);
            }
            remove
            {
                UnregisterEvent("MAIL_FAILED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CloseInboxItem
        {
            add
            {
                RegisterEvent("CLOSE_INBOX_ITEM", value);
            }
            remove
            {
                UnregisterEvent("CLOSE_INBOX_ITEM", value);
            }
        }
        public event EventHandler<LuaEventArgs> ConfirmSummon
        {
            add
            {
                RegisterEvent("CONFIRM_SUMMON", value);
            }
            remove
            {
                UnregisterEvent("CONFIRM_SUMMON", value);
            }
        }
        public event EventHandler<LuaEventArgs> CancelSummon
        {
            add
            {
                RegisterEvent("CANCEL_SUMMON", value);
            }
            remove
            {
                UnregisterEvent("CANCEL_SUMMON", value);
            }
        }
        public event EventHandler<LuaEventArgs> BillingNagDialog
        {
            add
            {
                RegisterEvent("BILLING_NAG_DIALOG", value);
            }
            remove
            {
                UnregisterEvent("BILLING_NAG_DIALOG", value);
            }
        }
        public event EventHandler<LuaEventArgs> IgrBillingNagDialog
        {
            add
            {
                RegisterEvent("IGR_BILLING_NAG_DIALOG", value);
            }
            remove
            {
                UnregisterEvent("IGR_BILLING_NAG_DIALOG", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerSkinned
        {
            add
            {
                RegisterEvent("PLAYER_SKINNED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_SKINNED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TabardSavePending
        {
            add
            {
                RegisterEvent("TABARD_SAVE_PENDING", value);
            }
            remove
            {
                UnregisterEvent("TABARD_SAVE_PENDING", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitQuestLogChanged
        {
            add
            {
                RegisterEvent("UNIT_QUEST_LOG_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("UNIT_QUEST_LOG_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerPvpKillsChanged
        {
            add
            {
                RegisterEvent("PLAYER_PVP_KILLS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_PVP_KILLS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerPvpRankChanged
        {
            add
            {
                RegisterEvent("PLAYER_PVP_RANK_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_PVP_RANK_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> InspectHonorUpdate
        {
            add
            {
                RegisterEvent("INSPECT_HONOR_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("INSPECT_HONOR_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateWorldStates
        {
            add
            {
                RegisterEvent("UPDATE_WORLD_STATES", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_WORLD_STATES", value);
            }
        }
        public event EventHandler<LuaEventArgs> AreaSpiritHealerInRange
        {
            add
            {
                RegisterEvent("AREA_SPIRIT_HEALER_IN_RANGE", value);
            }
            remove
            {
                UnregisterEvent("AREA_SPIRIT_HEALER_IN_RANGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AreaSpiritHealerOutOfRange
        {
            add
            {
                RegisterEvent("AREA_SPIRIT_HEALER_OUT_OF_RANGE", value);
            }
            remove
            {
                UnregisterEvent("AREA_SPIRIT_HEALER_OUT_OF_RANGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlaytimeChanged
        {
            add
            {
                RegisterEvent("PLAYTIME_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYTIME_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateLfgTypes
        {
            add
            {
                RegisterEvent("UPDATE_LFG_TYPES", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_LFG_TYPES", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateLfgList
        {
            add
            {
                RegisterEvent("UPDATE_LFG_LIST", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_LFG_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateLfgListIncremental
        {
            add
            {
                RegisterEvent("UPDATE_LFG_LIST_INCREMENTAL", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_LFG_LIST_INCREMENTAL", value);
            }
        }
        public event EventHandler<LuaEventArgs> StartMinigame
        {
            add
            {
                RegisterEvent("START_MINIGAME", value);
            }
            remove
            {
                UnregisterEvent("START_MINIGAME", value);
            }
        }
        public event EventHandler<LuaEventArgs> MinigameUpdate
        {
            add
            {
                RegisterEvent("MINIGAME_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("MINIGAME_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ReadyCheck
        {
            add
            {
                RegisterEvent("READY_CHECK", value);
            }
            remove
            {
                UnregisterEvent("READY_CHECK", value);
            }
        }
        public event EventHandler<LuaEventArgs> ReadyCheckConfirm
        {
            add
            {
                RegisterEvent("READY_CHECK_CONFIRM", value);
            }
            remove
            {
                UnregisterEvent("READY_CHECK_CONFIRM", value);
            }
        }
        public event EventHandler<LuaEventArgs> ReadyCheckFinished
        {
            add
            {
                RegisterEvent("READY_CHECK_FINISHED", value);
            }
            remove
            {
                UnregisterEvent("READY_CHECK_FINISHED", value);
            }
        }
        public event EventHandler<LuaEventArgs> RaidTargetUpdate
        {
            add
            {
                RegisterEvent("RAID_TARGET_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("RAID_TARGET_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GmsurveyDisplay
        {
            add
            {
                RegisterEvent("GMSURVEY_DISPLAY", value);
            }
            remove
            {
                UnregisterEvent("GMSURVEY_DISPLAY", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateInstanceInfo
        {
            add
            {
                RegisterEvent("UPDATE_INSTANCE_INFO", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_INSTANCE_INFO", value);
            }
        }
        public event EventHandler<LuaEventArgs> SocketInfoUpdate
        {
            add
            {
                RegisterEvent("SOCKET_INFO_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("SOCKET_INFO_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> SocketInfoClose
        {
            add
            {
                RegisterEvent("SOCKET_INFO_CLOSE", value);
            }
            remove
            {
                UnregisterEvent("SOCKET_INFO_CLOSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetitionVendorShow
        {
            add
            {
                RegisterEvent("PETITION_VENDOR_SHOW", value);
            }
            remove
            {
                UnregisterEvent("PETITION_VENDOR_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetitionVendorClosed
        {
            add
            {
                RegisterEvent("PETITION_VENDOR_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("PETITION_VENDOR_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetitionVendorUpdate
        {
            add
            {
                RegisterEvent("PETITION_VENDOR_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PETITION_VENDOR_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CombatTextUpdate
        {
            add
            {
                RegisterEvent("COMBAT_TEXT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("COMBAT_TEXT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestWatchUpdate
        {
            add
            {
                RegisterEvent("QUEST_WATCH_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("QUEST_WATCH_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseSetupLoadSuccess
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_SETUP_LOAD_SUCCESS", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_SETUP_LOAD_SUCCESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseSetupLoadFailure
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_SETUP_LOAD_FAILURE", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_SETUP_LOAD_FAILURE", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseQueryLoadSuccess
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_QUERY_LOAD_SUCCESS", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_QUERY_LOAD_SUCCESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseQueryLoadFailure
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_QUERY_LOAD_FAILURE", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_QUERY_LOAD_FAILURE", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseArticleLoadSuccess
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_ARTICLE_LOAD_SUCCESS", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_ARTICLE_LOAD_SUCCESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseArticleLoadFailure
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_ARTICLE_LOAD_FAILURE", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_ARTICLE_LOAD_FAILURE", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseSystemMotdUpdated
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_SYSTEM_MOTD_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_SYSTEM_MOTD_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnowledgeBaseServerMessage
        {
            add
            {
                RegisterEvent("KNOWLEDGE_BASE_SERVER_MESSAGE", value);
            }
            remove
            {
                UnregisterEvent("KNOWLEDGE_BASE_SERVER_MESSAGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArenaTeamUpdate
        {
            add
            {
                RegisterEvent("ARENA_TEAM_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("ARENA_TEAM_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArenaTeamRosterUpdate
        {
            add
            {
                RegisterEvent("ARENA_TEAM_ROSTER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("ARENA_TEAM_ROSTER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArenaTeamInviteRequest
        {
            add
            {
                RegisterEvent("ARENA_TEAM_INVITE_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("ARENA_TEAM_INVITE_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> KnownTitlesUpdate
        {
            add
            {
                RegisterEvent("KNOWN_TITLES_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("KNOWN_TITLES_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> NewTitleEarned
        {
            add
            {
                RegisterEvent("NEW_TITLE_EARNED", value);
            }
            remove
            {
                UnregisterEvent("NEW_TITLE_EARNED", value);
            }
        }
        public event EventHandler<LuaEventArgs> OldTitleLost
        {
            add
            {
                RegisterEvent("OLD_TITLE_LOST", value);
            }
            remove
            {
                UnregisterEvent("OLD_TITLE_LOST", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgUpdate
        {
            add
            {
                RegisterEvent("LFG_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("LFG_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgProposalUpdate
        {
            add
            {
                RegisterEvent("LFG_PROPOSAL_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("LFG_PROPOSAL_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgProposalShow
        {
            add
            {
                RegisterEvent("LFG_PROPOSAL_SHOW", value);
            }
            remove
            {
                UnregisterEvent("LFG_PROPOSAL_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgProposalFailed
        {
            add
            {
                RegisterEvent("LFG_PROPOSAL_FAILED", value);
            }
            remove
            {
                UnregisterEvent("LFG_PROPOSAL_FAILED", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgProposalSucceeded
        {
            add
            {
                RegisterEvent("LFG_PROPOSAL_SUCCEEDED", value);
            }
            remove
            {
                UnregisterEvent("LFG_PROPOSAL_SUCCEEDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgRoleUpdate
        {
            add
            {
                RegisterEvent("LFG_ROLE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("LFG_ROLE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgRoleCheckUpdate
        {
            add
            {
                RegisterEvent("LFG_ROLE_CHECK_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("LFG_ROLE_CHECK_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgRoleCheckShow
        {
            add
            {
                RegisterEvent("LFG_ROLE_CHECK_SHOW", value);
            }
            remove
            {
                UnregisterEvent("LFG_ROLE_CHECK_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgRoleCheckHide
        {
            add
            {
                RegisterEvent("LFG_ROLE_CHECK_HIDE", value);
            }
            remove
            {
                UnregisterEvent("LFG_ROLE_CHECK_HIDE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgRoleCheckRoleChosen
        {
            add
            {
                RegisterEvent("LFG_ROLE_CHECK_ROLE_CHOSEN", value);
            }
            remove
            {
                UnregisterEvent("LFG_ROLE_CHECK_ROLE_CHOSEN", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgQueueStatusUpdate
        {
            add
            {
                RegisterEvent("LFG_QUEUE_STATUS_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("LFG_QUEUE_STATUS_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgBootProposalUpdate
        {
            add
            {
                RegisterEvent("LFG_BOOT_PROPOSAL_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("LFG_BOOT_PROPOSAL_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgLockInfoReceived
        {
            add
            {
                RegisterEvent("LFG_LOCK_INFO_RECEIVED", value);
            }
            remove
            {
                UnregisterEvent("LFG_LOCK_INFO_RECEIVED", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgUpdateRandomInfo
        {
            add
            {
                RegisterEvent("LFG_UPDATE_RANDOM_INFO", value);
            }
            remove
            {
                UnregisterEvent("LFG_UPDATE_RANDOM_INFO", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgOfferContinue
        {
            add
            {
                RegisterEvent("LFG_OFFER_CONTINUE", value);
            }
            remove
            {
                UnregisterEvent("LFG_OFFER_CONTINUE", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgOpenFromGossip
        {
            add
            {
                RegisterEvent("LFG_OPEN_FROM_GOSSIP", value);
            }
            remove
            {
                UnregisterEvent("LFG_OPEN_FROM_GOSSIP", value);
            }
        }
        public event EventHandler<LuaEventArgs> LfgCompletionReward
        {
            add
            {
                RegisterEvent("LFG_COMPLETION_REWARD", value);
            }
            remove
            {
                UnregisterEvent("LFG_COMPLETION_REWARD", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyLfgRestricted
        {
            add
            {
                RegisterEvent("PARTY_LFG_RESTRICTED", value);
            }
            remove
            {
                UnregisterEvent("PARTY_LFG_RESTRICTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerRolesAssigned
        {
            add
            {
                RegisterEvent("PLAYER_ROLES_ASSIGNED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ROLES_ASSIGNED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CombatRatingUpdate
        {
            add
            {
                RegisterEvent("COMBAT_RATING_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("COMBAT_RATING_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ModifierStateChanged
        {
            add
            {
                RegisterEvent("MODIFIER_STATE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("MODIFIER_STATE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateStealth
        {
            add
            {
                RegisterEvent("UPDATE_STEALTH", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_STEALTH", value);
            }
        }
        public event EventHandler<LuaEventArgs> EnableTaxiBenchmark
        {
            add
            {
                RegisterEvent("ENABLE_TAXI_BENCHMARK", value);
            }
            remove
            {
                UnregisterEvent("ENABLE_TAXI_BENCHMARK", value);
            }
        }
        public event EventHandler<LuaEventArgs> DisableTaxiBenchmark
        {
            add
            {
                RegisterEvent("DISABLE_TAXI_BENCHMARK", value);
            }
            remove
            {
                UnregisterEvent("DISABLE_TAXI_BENCHMARK", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceStart
        {
            add
            {
                RegisterEvent("VOICE_START", value);
            }
            remove
            {
                UnregisterEvent("VOICE_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceStop
        {
            add
            {
                RegisterEvent("VOICE_STOP", value);
            }
            remove
            {
                UnregisterEvent("VOICE_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceStatusUpdate
        {
            add
            {
                RegisterEvent("VOICE_STATUS_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("VOICE_STATUS_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceChannelStatusUpdate
        {
            add
            {
                RegisterEvent("VOICE_CHANNEL_STATUS_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("VOICE_CHANNEL_STATUS_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateFloatingChatWindows
        {
            add
            {
                RegisterEvent("UPDATE_FLOATING_CHAT_WINDOWS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_FLOATING_CHAT_WINDOWS", value);
            }
        }
        public event EventHandler<LuaEventArgs> RaidInstanceWelcome
        {
            add
            {
                RegisterEvent("RAID_INSTANCE_WELCOME", value);
            }
            remove
            {
                UnregisterEvent("RAID_INSTANCE_WELCOME", value);
            }
        }
        public event EventHandler<LuaEventArgs> MovieRecordingProgress
        {
            add
            {
                RegisterEvent("MOVIE_RECORDING_PROGRESS", value);
            }
            remove
            {
                UnregisterEvent("MOVIE_RECORDING_PROGRESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> MovieCompressingProgress
        {
            add
            {
                RegisterEvent("MOVIE_COMPRESSING_PROGRESS", value);
            }
            remove
            {
                UnregisterEvent("MOVIE_COMPRESSING_PROGRESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> MovieUncompressedMovie
        {
            add
            {
                RegisterEvent("MOVIE_UNCOMPRESSED_MOVIE", value);
            }
            remove
            {
                UnregisterEvent("MOVIE_UNCOMPRESSED_MOVIE", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoicePushToTalkStart
        {
            add
            {
                RegisterEvent("VOICE_PUSH_TO_TALK_START", value);
            }
            remove
            {
                UnregisterEvent("VOICE_PUSH_TO_TALK_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoicePushToTalkStop
        {
            add
            {
                RegisterEvent("VOICE_PUSH_TO_TALK_STOP", value);
            }
            remove
            {
                UnregisterEvent("VOICE_PUSH_TO_TALK_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankframeOpened
        {
            add
            {
                RegisterEvent("GUILDBANKFRAME_OPENED", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANKFRAME_OPENED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankframeClosed
        {
            add
            {
                RegisterEvent("GUILDBANKFRAME_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANKFRAME_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankbagslotsChanged
        {
            add
            {
                RegisterEvent("GUILDBANKBAGSLOTS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANKBAGSLOTS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankItemLockChanged
        {
            add
            {
                RegisterEvent("GUILDBANK_ITEM_LOCK_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANK_ITEM_LOCK_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankUpdateTabs
        {
            add
            {
                RegisterEvent("GUILDBANK_UPDATE_TABS", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANK_UPDATE_TABS", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankUpdateMoney
        {
            add
            {
                RegisterEvent("GUILDBANK_UPDATE_MONEY", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANK_UPDATE_MONEY", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbanklogUpdate
        {
            add
            {
                RegisterEvent("GUILDBANKLOG_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANKLOG_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankUpdateWithdrawmoney
        {
            add
            {
                RegisterEvent("GUILDBANK_UPDATE_WITHDRAWMONEY", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANK_UPDATE_WITHDRAWMONEY", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankUpdateText
        {
            add
            {
                RegisterEvent("GUILDBANK_UPDATE_TEXT", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANK_UPDATE_TEXT", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildbankTextChanged
        {
            add
            {
                RegisterEvent("GUILDBANK_TEXT_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("GUILDBANK_TEXT_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChannelUiUpdate
        {
            add
            {
                RegisterEvent("CHANNEL_UI_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CHANNEL_UI_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChannelCountUpdate
        {
            add
            {
                RegisterEvent("CHANNEL_COUNT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CHANNEL_COUNT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChannelRosterUpdate
        {
            add
            {
                RegisterEvent("CHANNEL_ROSTER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CHANNEL_ROSTER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChannelVoiceUpdate
        {
            add
            {
                RegisterEvent("CHANNEL_VOICE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CHANNEL_VOICE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChannelInviteRequest
        {
            add
            {
                RegisterEvent("CHANNEL_INVITE_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("CHANNEL_INVITE_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChannelPasswordRequest
        {
            add
            {
                RegisterEvent("CHANNEL_PASSWORD_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("CHANNEL_PASSWORD_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChannelFlagsUpdated
        {
            add
            {
                RegisterEvent("CHANNEL_FLAGS_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("CHANNEL_FLAGS_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceSessionsUpdate
        {
            add
            {
                RegisterEvent("VOICE_SESSIONS_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("VOICE_SESSIONS_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceChatEnabledUpdate
        {
            add
            {
                RegisterEvent("VOICE_CHAT_ENABLED_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("VOICE_CHAT_ENABLED_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceLeftSession
        {
            add
            {
                RegisterEvent("VOICE_LEFT_SESSION", value);
            }
            remove
            {
                UnregisterEvent("VOICE_LEFT_SESSION", value);
            }
        }
        public event EventHandler<LuaEventArgs> InspectReady
        {
            add
            {
                RegisterEvent("INSPECT_READY", value);
            }
            remove
            {
                UnregisterEvent("INSPECT_READY", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoiceSelfMute
        {
            add
            {
                RegisterEvent("VOICE_SELF_MUTE", value);
            }
            remove
            {
                UnregisterEvent("VOICE_SELF_MUTE", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoicePlateStart
        {
            add
            {
                RegisterEvent("VOICE_PLATE_START", value);
            }
            remove
            {
                UnregisterEvent("VOICE_PLATE_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoicePlateStop
        {
            add
            {
                RegisterEvent("VOICE_PLATE_STOP", value);
            }
            remove
            {
                UnregisterEvent("VOICE_PLATE_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArenaSeasonWorldState
        {
            add
            {
                RegisterEvent("ARENA_SEASON_WORLD_STATE", value);
            }
            remove
            {
                UnregisterEvent("ARENA_SEASON_WORLD_STATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildEventLogUpdate
        {
            add
            {
                RegisterEvent("GUILD_EVENT_LOG_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILD_EVENT_LOG_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildtabardUpdate
        {
            add
            {
                RegisterEvent("GUILDTABARD_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILDTABARD_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> SoundDeviceUpdate
        {
            add
            {
                RegisterEvent("SOUND_DEVICE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("SOUND_DEVICE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CommentatorMapUpdate
        {
            add
            {
                RegisterEvent("COMMENTATOR_MAP_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("COMMENTATOR_MAP_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CommentatorEnterWorld
        {
            add
            {
                RegisterEvent("COMMENTATOR_ENTER_WORLD", value);
            }
            remove
            {
                UnregisterEvent("COMMENTATOR_ENTER_WORLD", value);
            }
        }
        public event EventHandler<LuaEventArgs> CombatLogEvent
        {
            add
            {
                RegisterEvent("COMBAT_LOG_EVENT", value);
            }
            remove
            {
                UnregisterEvent("COMBAT_LOG_EVENT", value);
            }
        }
        public event EventHandler<LuaEventArgs> CombatLogEventUnfiltered
        {
            add
            {
                RegisterEvent("COMBAT_LOG_EVENT_UNFILTERED", value);
            }
            remove
            {
                UnregisterEvent("COMBAT_LOG_EVENT_UNFILTERED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CommentatorPlayerUpdate
        {
            add
            {
                RegisterEvent("COMMENTATOR_PLAYER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("COMMENTATOR_PLAYER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerEnteringBattleground
        {
            add
            {
                RegisterEvent("PLAYER_ENTERING_BATTLEGROUND", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_ENTERING_BATTLEGROUND", value);
            }
        }
        public event EventHandler<LuaEventArgs> BarberShopOpen
        {
            add
            {
                RegisterEvent("BARBER_SHOP_OPEN", value);
            }
            remove
            {
                UnregisterEvent("BARBER_SHOP_OPEN", value);
            }
        }
        public event EventHandler<LuaEventArgs> BarberShopClose
        {
            add
            {
                RegisterEvent("BARBER_SHOP_CLOSE", value);
            }
            remove
            {
                UnregisterEvent("BARBER_SHOP_CLOSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BarberShopSuccess
        {
            add
            {
                RegisterEvent("BARBER_SHOP_SUCCESS", value);
            }
            remove
            {
                UnregisterEvent("BARBER_SHOP_SUCCESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> BarberShopAppearanceApplied
        {
            add
            {
                RegisterEvent("BARBER_SHOP_APPEARANCE_APPLIED", value);
            }
            remove
            {
                UnregisterEvent("BARBER_SHOP_APPEARANCE_APPLIED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarUpdateInviteList
        {
            add
            {
                RegisterEvent("CALENDAR_UPDATE_INVITE_LIST", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_UPDATE_INVITE_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarUpdateEventList
        {
            add
            {
                RegisterEvent("CALENDAR_UPDATE_EVENT_LIST", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_UPDATE_EVENT_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarNewEvent
        {
            add
            {
                RegisterEvent("CALENDAR_NEW_EVENT", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_NEW_EVENT", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarOpenEvent
        {
            add
            {
                RegisterEvent("CALENDAR_OPEN_EVENT", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_OPEN_EVENT", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarCloseEvent
        {
            add
            {
                RegisterEvent("CALENDAR_CLOSE_EVENT", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_CLOSE_EVENT", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarUpdateEvent2
        {
            add
            {
                RegisterEvent("CALENDAR_UPDATE_EVENT_2", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_UPDATE_EVENT_2", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarUpdatePendingInvites
        {
            add
            {
                RegisterEvent("CALENDAR_UPDATE_PENDING_INVITES", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_UPDATE_PENDING_INVITES", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarEventAlarm
        {
            add
            {
                RegisterEvent("CALENDAR_EVENT_ALARM", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_EVENT_ALARM", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarUpdateError
        {
            add
            {
                RegisterEvent("CALENDAR_UPDATE_ERROR", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_UPDATE_ERROR", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarActionPending
        {
            add
            {
                RegisterEvent("CALENDAR_ACTION_PENDING", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_ACTION_PENDING", value);
            }
        }
        public event EventHandler<LuaEventArgs> CalendarUpdateGuildEvents
        {
            add
            {
                RegisterEvent("CALENDAR_UPDATE_GUILD_EVENTS", value);
            }
            remove
            {
                UnregisterEvent("CALENDAR_UPDATE_GUILD_EVENTS", value);
            }
        }
        public event EventHandler<LuaEventArgs> VehicleAngleShow
        {
            add
            {
                RegisterEvent("VEHICLE_ANGLE_SHOW", value);
            }
            remove
            {
                UnregisterEvent("VEHICLE_ANGLE_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> VehicleAngleUpdate
        {
            add
            {
                RegisterEvent("VEHICLE_ANGLE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("VEHICLE_ANGLE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> VehiclePowerShow
        {
            add
            {
                RegisterEvent("VEHICLE_POWER_SHOW", value);
            }
            remove
            {
                UnregisterEvent("VEHICLE_POWER_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitEnteringVehicle
        {
            add
            {
                RegisterEvent("UNIT_ENTERING_VEHICLE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ENTERING_VEHICLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitEnteredVehicle
        {
            add
            {
                RegisterEvent("UNIT_ENTERED_VEHICLE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_ENTERED_VEHICLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitExitingVehicle
        {
            add
            {
                RegisterEvent("UNIT_EXITING_VEHICLE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_EXITING_VEHICLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitExitedVehicle
        {
            add
            {
                RegisterEvent("UNIT_EXITED_VEHICLE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_EXITED_VEHICLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> VehiclePassengersChanged
        {
            add
            {
                RegisterEvent("VEHICLE_PASSENGERS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("VEHICLE_PASSENGERS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerGainsVehicleData
        {
            add
            {
                RegisterEvent("PLAYER_GAINS_VEHICLE_DATA", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_GAINS_VEHICLE_DATA", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerLosesVehicleData
        {
            add
            {
                RegisterEvent("PLAYER_LOSES_VEHICLE_DATA", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_LOSES_VEHICLE_DATA", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetForceNameDeclension
        {
            add
            {
                RegisterEvent("PET_FORCE_NAME_DECLENSION", value);
            }
            remove
            {
                UnregisterEvent("PET_FORCE_NAME_DECLENSION", value);
            }
        }
        public event EventHandler<LuaEventArgs> LevelGrantProposed
        {
            add
            {
                RegisterEvent("LEVEL_GRANT_PROPOSED", value);
            }
            remove
            {
                UnregisterEvent("LEVEL_GRANT_PROPOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> SynchronizeSettings
        {
            add
            {
                RegisterEvent("SYNCHRONIZE_SETTINGS", value);
            }
            remove
            {
                UnregisterEvent("SYNCHRONIZE_SETTINGS", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayMovie
        {
            add
            {
                RegisterEvent("PLAY_MOVIE", value);
            }
            remove
            {
                UnregisterEvent("PLAY_MOVIE", value);
            }
        }
        public event EventHandler<LuaEventArgs> RunePowerUpdate
        {
            add
            {
                RegisterEvent("RUNE_POWER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("RUNE_POWER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> RuneTypeUpdate
        {
            add
            {
                RegisterEvent("RUNE_TYPE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("RUNE_TYPE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AchievementEarned
        {
            add
            {
                RegisterEvent("ACHIEVEMENT_EARNED", value);
            }
            remove
            {
                UnregisterEvent("ACHIEVEMENT_EARNED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CriteriaUpdate
        {
            add
            {
                RegisterEvent("CRITERIA_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CRITERIA_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ReceivedAchievementList
        {
            add
            {
                RegisterEvent("RECEIVED_ACHIEVEMENT_LIST", value);
            }
            remove
            {
                UnregisterEvent("RECEIVED_ACHIEVEMENT_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetRenameable
        {
            add
            {
                RegisterEvent("PET_RENAMEABLE", value);
            }
            remove
            {
                UnregisterEvent("PET_RENAMEABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CurrencyDisplayUpdate
        {
            add
            {
                RegisterEvent("CURRENCY_DISPLAY_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("CURRENCY_DISPLAY_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CompanionLearned
        {
            add
            {
                RegisterEvent("COMPANION_LEARNED", value);
            }
            remove
            {
                UnregisterEvent("COMPANION_LEARNED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CompanionUnlearned
        {
            add
            {
                RegisterEvent("COMPANION_UNLEARNED", value);
            }
            remove
            {
                UnregisterEvent("COMPANION_UNLEARNED", value);
            }
        }
        public event EventHandler<LuaEventArgs> CompanionUpdate
        {
            add
            {
                RegisterEvent("COMPANION_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("COMPANION_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitThreatListUpdate
        {
            add
            {
                RegisterEvent("UNIT_THREAT_LIST_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_THREAT_LIST_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitThreatSituationUpdate
        {
            add
            {
                RegisterEvent("UNIT_THREAT_SITUATION_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_THREAT_SITUATION_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GlyphAdded
        {
            add
            {
                RegisterEvent("GLYPH_ADDED", value);
            }
            remove
            {
                UnregisterEvent("GLYPH_ADDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GlyphRemoved
        {
            add
            {
                RegisterEvent("GLYPH_REMOVED", value);
            }
            remove
            {
                UnregisterEvent("GLYPH_REMOVED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GlyphUpdated
        {
            add
            {
                RegisterEvent("GLYPH_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("GLYPH_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GlyphEnabled
        {
            add
            {
                RegisterEvent("GLYPH_ENABLED", value);
            }
            remove
            {
                UnregisterEvent("GLYPH_ENABLED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GlyphDisabled
        {
            add
            {
                RegisterEvent("GLYPH_DISABLED", value);
            }
            remove
            {
                UnregisterEvent("GLYPH_DISABLED", value);
            }
        }
        public event EventHandler<LuaEventArgs> UseGlyph
        {
            add
            {
                RegisterEvent("USE_GLYPH", value);
            }
            remove
            {
                UnregisterEvent("USE_GLYPH", value);
            }
        }
        public event EventHandler<LuaEventArgs> TrackedAchievementUpdate
        {
            add
            {
                RegisterEvent("TRACKED_ACHIEVEMENT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRACKED_ACHIEVEMENT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArenaOpponentUpdate
        {
            add
            {
                RegisterEvent("ARENA_OPPONENT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("ARENA_OPPONENT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> InspectAchievementReady
        {
            add
            {
                RegisterEvent("INSPECT_ACHIEVEMENT_READY", value);
            }
            remove
            {
                UnregisterEvent("INSPECT_ACHIEVEMENT_READY", value);
            }
        }
        public event EventHandler<LuaEventArgs> RaisedAsGhoul
        {
            add
            {
                RegisterEvent("RAISED_AS_GHOUL", value);
            }
            remove
            {
                UnregisterEvent("RAISED_AS_GHOUL", value);
            }
        }
        public event EventHandler<LuaEventArgs> PartyConvertedToRaid
        {
            add
            {
                RegisterEvent("PARTY_CONVERTED_TO_RAID", value);
            }
            remove
            {
                UnregisterEvent("PARTY_CONVERTED_TO_RAID", value);
            }
        }
        public event EventHandler<LuaEventArgs> PvpqueueAnywhereShow
        {
            add
            {
                RegisterEvent("PVPQUEUE_ANYWHERE_SHOW", value);
            }
            remove
            {
                UnregisterEvent("PVPQUEUE_ANYWHERE_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> PvpqueueAnywhereUpdateAvailable
        {
            add
            {
                RegisterEvent("PVPQUEUE_ANYWHERE_UPDATE_AVAILABLE", value);
            }
            remove
            {
                UnregisterEvent("PVPQUEUE_ANYWHERE_UPDATE_AVAILABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestAccepted
        {
            add
            {
                RegisterEvent("QUEST_ACCEPTED", value);
            }
            remove
            {
                UnregisterEvent("QUEST_ACCEPTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerTalentUpdate
        {
            add
            {
                RegisterEvent("PLAYER_TALENT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_TALENT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ActiveTalentGroupChanged
        {
            add
            {
                RegisterEvent("ACTIVE_TALENT_GROUP_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("ACTIVE_TALENT_GROUP_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetTalentUpdate
        {
            add
            {
                RegisterEvent("PET_TALENT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PET_TALENT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PreviewTalentPointsChanged
        {
            add
            {
                RegisterEvent("PREVIEW_TALENT_POINTS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PREVIEW_TALENT_POINTS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PreviewTalentPrimaryTreeChanged
        {
            add
            {
                RegisterEvent("PREVIEW_TALENT_PRIMARY_TREE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PREVIEW_TALENT_PRIMARY_TREE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PreviewPetTalentPointsChanged
        {
            add
            {
                RegisterEvent("PREVIEW_PET_TALENT_POINTS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PREVIEW_PET_TALENT_POINTS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> WearEquipmentSet
        {
            add
            {
                RegisterEvent("WEAR_EQUIPMENT_SET", value);
            }
            remove
            {
                UnregisterEvent("WEAR_EQUIPMENT_SET", value);
            }
        }
        public event EventHandler<LuaEventArgs> EquipmentSetsChanged
        {
            add
            {
                RegisterEvent("EQUIPMENT_SETS_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("EQUIPMENT_SETS_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> InstanceLockStart
        {
            add
            {
                RegisterEvent("INSTANCE_LOCK_START", value);
            }
            remove
            {
                UnregisterEvent("INSTANCE_LOCK_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> InstanceLockStop
        {
            add
            {
                RegisterEvent("INSTANCE_LOCK_STOP", value);
            }
            remove
            {
                UnregisterEvent("INSTANCE_LOCK_STOP", value);
            }
        }
        public event EventHandler<LuaEventArgs> InstanceLockWarning
        {
            add
            {
                RegisterEvent("INSTANCE_LOCK_WARNING", value);
            }
            remove
            {
                UnregisterEvent("INSTANCE_LOCK_WARNING", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerEquipmentChanged
        {
            add
            {
                RegisterEvent("PLAYER_EQUIPMENT_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_EQUIPMENT_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemLocked
        {
            add
            {
                RegisterEvent("ITEM_LOCKED", value);
            }
            remove
            {
                UnregisterEvent("ITEM_LOCKED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ItemUnlocked
        {
            add
            {
                RegisterEvent("ITEM_UNLOCKED", value);
            }
            remove
            {
                UnregisterEvent("ITEM_UNLOCKED", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeSkillFilterUpdate
        {
            add
            {
                RegisterEvent("TRADE_SKILL_FILTER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("TRADE_SKILL_FILTER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> EquipmentSwapPending
        {
            add
            {
                RegisterEvent("EQUIPMENT_SWAP_PENDING", value);
            }
            remove
            {
                UnregisterEvent("EQUIPMENT_SWAP_PENDING", value);
            }
        }
        public event EventHandler<LuaEventArgs> EquipmentSwapFinished
        {
            add
            {
                RegisterEvent("EQUIPMENT_SWAP_FINISHED", value);
            }
            remove
            {
                UnregisterEvent("EQUIPMENT_SWAP_FINISHED", value);
            }
        }
        public event EventHandler<LuaEventArgs> NpcPvpqueueAnywhere
        {
            add
            {
                RegisterEvent("NPC_PVPQUEUE_ANYWHERE", value);
            }
            remove
            {
                UnregisterEvent("NPC_PVPQUEUE_ANYWHERE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateMultiCastActionbar
        {
            add
            {
                RegisterEvent("UPDATE_MULTI_CAST_ACTIONBAR", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_MULTI_CAST_ACTIONBAR", value);
            }
        }
        public event EventHandler<LuaEventArgs> EnableXpGain
        {
            add
            {
                RegisterEvent("ENABLE_XP_GAIN", value);
            }
            remove
            {
                UnregisterEvent("ENABLE_XP_GAIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> DisableXpGain
        {
            add
            {
                RegisterEvent("DISABLE_XP_GAIN", value);
            }
            remove
            {
                UnregisterEvent("DISABLE_XP_GAIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldMgrEntryInvite
        {
            add
            {
                RegisterEvent("BATTLEFIELD_MGR_ENTRY_INVITE", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_MGR_ENTRY_INVITE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldMgrEntered
        {
            add
            {
                RegisterEvent("BATTLEFIELD_MGR_ENTERED", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_MGR_ENTERED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldMgrQueueRequestResponse
        {
            add
            {
                RegisterEvent("BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldMgrEjectPending
        {
            add
            {
                RegisterEvent("BATTLEFIELD_MGR_EJECT_PENDING", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_MGR_EJECT_PENDING", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldMgrEjected
        {
            add
            {
                RegisterEvent("BATTLEFIELD_MGR_EJECTED", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_MGR_EJECTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldMgrQueueInvite
        {
            add
            {
                RegisterEvent("BATTLEFIELD_MGR_QUEUE_INVITE", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_MGR_QUEUE_INVITE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BattlefieldMgrStateChange
        {
            add
            {
                RegisterEvent("BATTLEFIELD_MGR_STATE_CHANGE", value);
            }
            remove
            {
                UnregisterEvent("BATTLEFIELD_MGR_STATE_CHANGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PvpTypesEnabled
        {
            add
            {
                RegisterEvent("PVP_TYPES_ENABLED", value);
            }
            remove
            {
                UnregisterEvent("PVP_TYPES_ENABLED", value);
            }
        }
        public event EventHandler<LuaEventArgs> WorldStateUiTimerUpdate
        {
            add
            {
                RegisterEvent("WORLD_STATE_UI_TIMER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("WORLD_STATE_UI_TIMER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> EndBoundTradeable
        {
            add
            {
                RegisterEvent("END_BOUND_TRADEABLE", value);
            }
            remove
            {
                UnregisterEvent("END_BOUND_TRADEABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UpdateChatColorNameByClass
        {
            add
            {
                RegisterEvent("UPDATE_CHAT_COLOR_NAME_BY_CLASS", value);
            }
            remove
            {
                UnregisterEvent("UPDATE_CHAT_COLOR_NAME_BY_CLASS", value);
            }
        }
        public event EventHandler<LuaEventArgs> GmresponseReceived
        {
            add
            {
                RegisterEvent("GMRESPONSE_RECEIVED", value);
            }
            remove
            {
                UnregisterEvent("GMRESPONSE_RECEIVED", value);
            }
        }
        public event EventHandler<LuaEventArgs> VehicleUpdate
        {
            add
            {
                RegisterEvent("VEHICLE_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("VEHICLE_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> WowMouseNotFound
        {
            add
            {
                RegisterEvent("WOW_MOUSE_NOT_FOUND", value);
            }
            remove
            {
                UnregisterEvent("WOW_MOUSE_NOT_FOUND", value);
            }
        }
        public event EventHandler<LuaEventArgs> MailSuccess
        {
            add
            {
                RegisterEvent("MAIL_SUCCESS", value);
            }
            remove
            {
                UnregisterEvent("MAIL_SUCCESS", value);
            }
        }
        public event EventHandler<LuaEventArgs> TalentsInvoluntarilyReset
        {
            add
            {
                RegisterEvent("TALENTS_INVOLUNTARILY_RESET", value);
            }
            remove
            {
                UnregisterEvent("TALENTS_INVOLUNTARILY_RESET", value);
            }
        }
        public event EventHandler<LuaEventArgs> InstanceEncounterEngageUnit
        {
            add
            {
                RegisterEvent("INSTANCE_ENCOUNTER_ENGAGE_UNIT", value);
            }
            remove
            {
                UnregisterEvent("INSTANCE_ENCOUNTER_ENGAGE_UNIT", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestQueryComplete
        {
            add
            {
                RegisterEvent("QUEST_QUERY_COMPLETE", value);
            }
            remove
            {
                UnregisterEvent("QUEST_QUERY_COMPLETE", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestPoiUpdate
        {
            add
            {
                RegisterEvent("QUEST_POI_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("QUEST_POI_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerDifficultyChanged
        {
            add
            {
                RegisterEvent("PLAYER_DIFFICULTY_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_DIFFICULTY_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgPartyLeader
        {
            add
            {
                RegisterEvent("CHAT_MSG_PARTY_LEADER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_PARTY_LEADER", value);
            }
        }
        public event EventHandler<LuaEventArgs> VoteKickReasonNeeded
        {
            add
            {
                RegisterEvent("VOTE_KICK_REASON_NEEDED", value);
            }
            remove
            {
                UnregisterEvent("VOTE_KICK_REASON_NEEDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> EnableLowLevelRaid
        {
            add
            {
                RegisterEvent("ENABLE_LOW_LEVEL_RAID", value);
            }
            remove
            {
                UnregisterEvent("ENABLE_LOW_LEVEL_RAID", value);
            }
        }
        public event EventHandler<LuaEventArgs> DisableLowLevelRaid
        {
            add
            {
                RegisterEvent("DISABLE_LOW_LEVEL_RAID", value);
            }
            remove
            {
                UnregisterEvent("DISABLE_LOW_LEVEL_RAID", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgTargeticons
        {
            add
            {
                RegisterEvent("CHAT_MSG_TARGETICONS", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_TARGETICONS", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionHouseDisabled
        {
            add
            {
                RegisterEvent("AUCTION_HOUSE_DISABLED", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_HOUSE_DISABLED", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionMultisellStart
        {
            add
            {
                RegisterEvent("AUCTION_MULTISELL_START", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_MULTISELL_START", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionMultisellUpdate
        {
            add
            {
                RegisterEvent("AUCTION_MULTISELL_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_MULTISELL_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> AuctionMultisellFailure
        {
            add
            {
                RegisterEvent("AUCTION_MULTISELL_FAILURE", value);
            }
            remove
            {
                UnregisterEvent("AUCTION_MULTISELL_FAILURE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PetSpellPowerUpdate
        {
            add
            {
                RegisterEvent("PET_SPELL_POWER_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PET_SPELL_POWER_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnConnected
        {
            add
            {
                RegisterEvent("BN_CONNECTED", value);
            }
            remove
            {
                UnregisterEvent("BN_CONNECTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnDisconnected
        {
            add
            {
                RegisterEvent("BN_DISCONNECTED", value);
            }
            remove
            {
                UnregisterEvent("BN_DISCONNECTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnSelfOnline
        {
            add
            {
                RegisterEvent("BN_SELF_ONLINE", value);
            }
            remove
            {
                UnregisterEvent("BN_SELF_ONLINE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnSelfOffline
        {
            add
            {
                RegisterEvent("BN_SELF_OFFLINE", value);
            }
            remove
            {
                UnregisterEvent("BN_SELF_OFFLINE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendListSizeChanged
        {
            add
            {
                RegisterEvent("BN_FRIEND_LIST_SIZE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_LIST_SIZE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendInviteListInitialized
        {
            add
            {
                RegisterEvent("BN_FRIEND_INVITE_LIST_INITIALIZED", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_INVITE_LIST_INITIALIZED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendInviteSendResult
        {
            add
            {
                RegisterEvent("BN_FRIEND_INVITE_SEND_RESULT", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_INVITE_SEND_RESULT", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendInviteAdded
        {
            add
            {
                RegisterEvent("BN_FRIEND_INVITE_ADDED", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_INVITE_ADDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendInviteRemoved
        {
            add
            {
                RegisterEvent("BN_FRIEND_INVITE_REMOVED", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_INVITE_REMOVED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendInfoChanged
        {
            add
            {
                RegisterEvent("BN_FRIEND_INFO_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_INFO_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnCustomMessageChanged
        {
            add
            {
                RegisterEvent("BN_CUSTOM_MESSAGE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("BN_CUSTOM_MESSAGE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnCustomMessageLoaded
        {
            add
            {
                RegisterEvent("BN_CUSTOM_MESSAGE_LOADED", value);
            }
            remove
            {
                UnregisterEvent("BN_CUSTOM_MESSAGE_LOADED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnWhisper
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_WHISPER", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_WHISPER", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnWhisperInform
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_WHISPER_INFORM", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_WHISPER_INFORM", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatWhisperUndeliverable
        {
            add
            {
                RegisterEvent("BN_CHAT_WHISPER_UNDELIVERABLE", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_WHISPER_UNDELIVERABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelJoined
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_JOINED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_JOINED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelLeft
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_LEFT", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_LEFT", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelClosed
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnConversation
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_CONVERSATION", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_CONVERSATION", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnConversationNotice
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_CONVERSATION_NOTICE", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_CONVERSATION_NOTICE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnConversationList
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_CONVERSATION_LIST", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_CONVERSATION_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelMessageUndeliverable
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_MESSAGE_UNDELIVERABLE", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_MESSAGE_UNDELIVERABLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelMessageBlocked
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_MESSAGE_BLOCKED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_MESSAGE_BLOCKED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelMemberJoined
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_MEMBER_JOINED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_MEMBER_JOINED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelMemberLeft
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_MEMBER_LEFT", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_MEMBER_LEFT", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelMemberUpdated
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_MEMBER_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_MEMBER_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelCreateSucceeded
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_CREATE_SUCCEEDED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_CREATE_SUCCEEDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelCreateFailed
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_CREATE_FAILED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_CREATE_FAILED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelInviteSucceeded
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_INVITE_SUCCEEDED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_INVITE_SUCCEEDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnChatChannelInviteFailed
        {
            add
            {
                RegisterEvent("BN_CHAT_CHANNEL_INVITE_FAILED", value);
            }
            remove
            {
                UnregisterEvent("BN_CHAT_CHANNEL_INVITE_FAILED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnBlockListUpdated
        {
            add
            {
                RegisterEvent("BN_BLOCK_LIST_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("BN_BLOCK_LIST_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnSystemMessage
        {
            add
            {
                RegisterEvent("BN_SYSTEM_MESSAGE", value);
            }
            remove
            {
                UnregisterEvent("BN_SYSTEM_MESSAGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnRequestFofSucceeded
        {
            add
            {
                RegisterEvent("BN_REQUEST_FOF_SUCCEEDED", value);
            }
            remove
            {
                UnregisterEvent("BN_REQUEST_FOF_SUCCEEDED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnRequestFofFailed
        {
            add
            {
                RegisterEvent("BN_REQUEST_FOF_FAILED", value);
            }
            remove
            {
                UnregisterEvent("BN_REQUEST_FOF_FAILED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnNewPresence
        {
            add
            {
                RegisterEvent("BN_NEW_PRESENCE", value);
            }
            remove
            {
                UnregisterEvent("BN_NEW_PRESENCE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnToonNameUpdated
        {
            add
            {
                RegisterEvent("BN_TOON_NAME_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("BN_TOON_NAME_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendAccountOnline
        {
            add
            {
                RegisterEvent("BN_FRIEND_ACCOUNT_ONLINE", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_ACCOUNT_ONLINE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendAccountOffline
        {
            add
            {
                RegisterEvent("BN_FRIEND_ACCOUNT_OFFLINE", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_ACCOUNT_OFFLINE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendToonOnline
        {
            add
            {
                RegisterEvent("BN_FRIEND_TOON_ONLINE", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_TOON_ONLINE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnFriendToonOffline
        {
            add
            {
                RegisterEvent("BN_FRIEND_TOON_OFFLINE", value);
            }
            remove
            {
                UnregisterEvent("BN_FRIEND_TOON_OFFLINE", value);
            }
        }
        public event EventHandler<LuaEventArgs> BnMatureLanguageFilter
        {
            add
            {
                RegisterEvent("BN_MATURE_LANGUAGE_FILTER", value);
            }
            remove
            {
                UnregisterEvent("BN_MATURE_LANGUAGE_FILTER", value);
            }
        }
        public event EventHandler<LuaEventArgs> MasteryUpdate
        {
            add
            {
                RegisterEvent("MASTERY_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("MASTERY_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> CommentatorSkirmishQueueRequest
        {
            add
            {
                RegisterEvent("COMMENTATOR_SKIRMISH_QUEUE_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("COMMENTATOR_SKIRMISH_QUEUE_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> CommentatorSkirmishModeRequest
        {
            add
            {
                RegisterEvent("COMMENTATOR_SKIRMISH_MODE_REQUEST", value);
            }
            remove
            {
                UnregisterEvent("COMMENTATOR_SKIRMISH_MODE_REQUEST", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnInlineToastAlert
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_INLINE_TOAST_ALERT", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_INLINE_TOAST_ALERT", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnInlineToastBroadcast
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_INLINE_TOAST_BROADCAST", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_INLINE_TOAST_BROADCAST", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnInlineToastBroadcastInform
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_INLINE_TOAST_BROADCAST_INFORM", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_INLINE_TOAST_BROADCAST_INFORM", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgBnInlineToastConversation
        {
            add
            {
                RegisterEvent("CHAT_MSG_BN_INLINE_TOAST_CONVERSATION", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_BN_INLINE_TOAST_CONVERSATION", value);
            }
        }
        public event EventHandler<LuaEventArgs> ForgeMasterOpened
        {
            add
            {
                RegisterEvent("FORGE_MASTER_OPENED", value);
            }
            remove
            {
                UnregisterEvent("FORGE_MASTER_OPENED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ForgeMasterClosed
        {
            add
            {
                RegisterEvent("FORGE_MASTER_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("FORGE_MASTER_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ForgeMasterSetItem
        {
            add
            {
                RegisterEvent("FORGE_MASTER_SET_ITEM", value);
            }
            remove
            {
                UnregisterEvent("FORGE_MASTER_SET_ITEM", value);
            }
        }
        public event EventHandler<LuaEventArgs> ForgeMasterItemChanged
        {
            add
            {
                RegisterEvent("FORGE_MASTER_ITEM_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("FORGE_MASTER_ITEM_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerTradeCurrency
        {
            add
            {
                RegisterEvent("PLAYER_TRADE_CURRENCY", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_TRADE_CURRENCY", value);
            }
        }
        public event EventHandler<LuaEventArgs> TradeCurrencyChanged
        {
            add
            {
                RegisterEvent("TRADE_CURRENCY_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("TRADE_CURRENCY_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> WeightedSpellUpdated
        {
            add
            {
                RegisterEvent("WEIGHTED_SPELL_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("WEIGHTED_SPELL_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildXpUpdate
        {
            add
            {
                RegisterEvent("GUILD_XP_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILD_XP_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildPerkUpdate
        {
            add
            {
                RegisterEvent("GUILD_PERK_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILD_PERK_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildTradeskillUpdate
        {
            add
            {
                RegisterEvent("GUILD_TRADESKILL_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILD_TRADESKILL_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPower
        {
            add
            {
                RegisterEvent("UNIT_POWER", value);
            }
            remove
            {
                UnregisterEvent("UNIT_POWER", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitMaxpower
        {
            add
            {
                RegisterEvent("UNIT_MAXPOWER", value);
            }
            remove
            {
                UnregisterEvent("UNIT_MAXPOWER", value);
            }
        }
        public event EventHandler<LuaEventArgs> EnableDeclineGuildInvite
        {
            add
            {
                RegisterEvent("ENABLE_DECLINE_GUILD_INVITE", value);
            }
            remove
            {
                UnregisterEvent("ENABLE_DECLINE_GUILD_INVITE", value);
            }
        }
        public event EventHandler<LuaEventArgs> DisableDeclineGuildInvite
        {
            add
            {
                RegisterEvent("DISABLE_DECLINE_GUILD_INVITE", value);
            }
            remove
            {
                UnregisterEvent("DISABLE_DECLINE_GUILD_INVITE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildRecipeKnownByMembers
        {
            add
            {
                RegisterEvent("GUILD_RECIPE_KNOWN_BY_MEMBERS", value);
            }
            remove
            {
                UnregisterEvent("GUILD_RECIPE_KNOWN_BY_MEMBERS", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArtifactUpdate
        {
            add
            {
                RegisterEvent("ARTIFACT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("ARTIFACT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArtifactHistoryReady
        {
            add
            {
                RegisterEvent("ARTIFACT_HISTORY_READY", value);
            }
            remove
            {
                UnregisterEvent("ARTIFACT_HISTORY_READY", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArtifactComplete
        {
            add
            {
                RegisterEvent("ARTIFACT_COMPLETE", value);
            }
            remove
            {
                UnregisterEvent("ARTIFACT_COMPLETE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArtifactDigSiteUpdated
        {
            add
            {
                RegisterEvent("ARTIFACT_DIG_SITE_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("ARTIFACT_DIG_SITE_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArchaeologyToggle
        {
            add
            {
                RegisterEvent("ARCHAEOLOGY_TOGGLE", value);
            }
            remove
            {
                UnregisterEvent("ARCHAEOLOGY_TOGGLE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ArchaeologyClosed
        {
            add
            {
                RegisterEvent("ARCHAEOLOGY_CLOSED", value);
            }
            remove
            {
                UnregisterEvent("ARCHAEOLOGY_CLOSED", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellFlyoutUpdate
        {
            add
            {
                RegisterEvent("SPELL_FLYOUT_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("SPELL_FLYOUT_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitConnection
        {
            add
            {
                RegisterEvent("UNIT_CONNECTION", value);
            }
            remove
            {
                UnregisterEvent("UNIT_CONNECTION", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitHealPrediction
        {
            add
            {
                RegisterEvent("UNIT_HEAL_PREDICTION", value);
            }
            remove
            {
                UnregisterEvent("UNIT_HEAL_PREDICTION", value);
            }
        }
        public event EventHandler<LuaEventArgs> EnteredDifferentInstanceFromParty
        {
            add
            {
                RegisterEvent("ENTERED_DIFFERENT_INSTANCE_FROM_PARTY", value);
            }
            remove
            {
                UnregisterEvent("ENTERED_DIFFERENT_INSTANCE_FROM_PARTY", value);
            }
        }
        public event EventHandler<LuaEventArgs> UiScaleChanged
        {
            add
            {
                RegisterEvent("UI_SCALE_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("UI_SCALE_CHANGED", value);
            }
        }
        public event EventHandler<LuaEventArgs> RoleChangedInform
        {
            add
            {
                RegisterEvent("ROLE_CHANGED_INFORM", value);
            }
            remove
            {
                UnregisterEvent("ROLE_CHANGED_INFORM", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildRewardsList
        {
            add
            {
                RegisterEvent("GUILD_REWARDS_LIST", value);
            }
            remove
            {
                UnregisterEvent("GUILD_REWARDS_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> RolePollBegin
        {
            add
            {
                RegisterEvent("ROLE_POLL_BEGIN", value);
            }
            remove
            {
                UnregisterEvent("ROLE_POLL_BEGIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> RequestCemeteryListResponse
        {
            add
            {
                RegisterEvent("REQUEST_CEMETERY_LIST_RESPONSE", value);
            }
            remove
            {
                UnregisterEvent("REQUEST_CEMETERY_LIST_RESPONSE", value);
            }
        }
        public event EventHandler<LuaEventArgs> WargameRequested
        {
            add
            {
                RegisterEvent("WARGAME_REQUESTED", value);
            }
            remove
            {
                UnregisterEvent("WARGAME_REQUESTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildNewsUpdate
        {
            add
            {
                RegisterEvent("GUILD_NEWS_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILD_NEWS_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatServerDisconnected
        {
            add
            {
                RegisterEvent("CHAT_SERVER_DISCONNECTED", value);
            }
            remove
            {
                UnregisterEvent("CHAT_SERVER_DISCONNECTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatServerReconnected
        {
            add
            {
                RegisterEvent("CHAT_SERVER_RECONNECTED", value);
            }
            remove
            {
                UnregisterEvent("CHAT_SERVER_RECONNECTED", value);
            }
        }
        public event EventHandler<LuaEventArgs> StreamingIcon
        {
            add
            {
                RegisterEvent("STREAMING_ICON", value);
            }
            remove
            {
                UnregisterEvent("STREAMING_ICON", value);
            }
        }
        public event EventHandler<LuaEventArgs> ReceivedAchievementMemberList
        {
            add
            {
                RegisterEvent("RECEIVED_ACHIEVEMENT_MEMBER_LIST", value);
            }
            remove
            {
                UnregisterEvent("RECEIVED_ACHIEVEMENT_MEMBER_LIST", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellActivationOverlayShow
        {
            add
            {
                RegisterEvent("SPELL_ACTIVATION_OVERLAY_SHOW", value);
            }
            remove
            {
                UnregisterEvent("SPELL_ACTIVATION_OVERLAY_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellActivationOverlayHide
        {
            add
            {
                RegisterEvent("SPELL_ACTIVATION_OVERLAY_HIDE", value);
            }
            remove
            {
                UnregisterEvent("SPELL_ACTIVATION_OVERLAY_HIDE", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellActivationOverlayGlowShow
        {
            add
            {
                RegisterEvent("SPELL_ACTIVATION_OVERLAY_GLOW_SHOW", value);
            }
            remove
            {
                UnregisterEvent("SPELL_ACTIVATION_OVERLAY_GLOW_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> SpellActivationOverlayGlowHide
        {
            add
            {
                RegisterEvent("SPELL_ACTIVATION_OVERLAY_GLOW_HIDE", value);
            }
            remove
            {
                UnregisterEvent("SPELL_ACTIVATION_OVERLAY_GLOW_HIDE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPhase
        {
            add
            {
                RegisterEvent("UNIT_PHASE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_PHASE", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPowerBarShow
        {
            add
            {
                RegisterEvent("UNIT_POWER_BAR_SHOW", value);
            }
            remove
            {
                UnregisterEvent("UNIT_POWER_BAR_SHOW", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitPowerBarHide
        {
            add
            {
                RegisterEvent("UNIT_POWER_BAR_HIDE", value);
            }
            remove
            {
                UnregisterEvent("UNIT_POWER_BAR_HIDE", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildRanksUpdate
        {
            add
            {
                RegisterEvent("GUILD_RANKS_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("GUILD_RANKS_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> PvpRatedStatsUpdate
        {
            add
            {
                RegisterEvent("PVP_RATED_STATS_UPDATE", value);
            }
            remove
            {
                UnregisterEvent("PVP_RATED_STATS_UPDATE", value);
            }
        }
        public event EventHandler<LuaEventArgs> ChatMsgCombatGuildXpGain
        {
            add
            {
                RegisterEvent("CHAT_MSG_COMBAT_GUILD_XP_GAIN", value);
            }
            remove
            {
                UnregisterEvent("CHAT_MSG_COMBAT_GUILD_XP_GAIN", value);
            }
        }
        public event EventHandler<LuaEventArgs> UnitGuildLevel
        {
            add
            {
                RegisterEvent("UNIT_GUILD_LEVEL", value);
            }
            remove
            {
                UnregisterEvent("UNIT_GUILD_LEVEL", value);
            }
        }
        public event EventHandler<LuaEventArgs> GuildPartyStateUpdated
        {
            add
            {
                RegisterEvent("GUILD_PARTY_STATE_UPDATED", value);
            }
            remove
            {
                UnregisterEvent("GUILD_PARTY_STATE_UPDATED", value);
            }
        }
        public event EventHandler<LuaEventArgs> PlayerAvgItemLevelReady
        {
            add
            {
                RegisterEvent("PLAYER_AVG_ITEM_LEVEL_READY", value);
            }
            remove
            {
                UnregisterEvent("PLAYER_AVG_ITEM_LEVEL_READY", value);
            }
        }
        public event EventHandler<LuaEventArgs> EclipseDirectionChange
        {
            add
            {
                RegisterEvent("ECLIPSE_DIRECTION_CHANGE", value);
            }
            remove
            {
                UnregisterEvent("ECLIPSE_DIRECTION_CHANGE", value);
            }
        }
        public event EventHandler<LuaEventArgs> QuestAutocompleteSound
        {
            add
            {
                RegisterEvent("QUEST_AUTOCOMPLETE_SOUND", value);
            }
            remove
            {
                UnregisterEvent("QUEST_AUTOCOMPLETE_SOUND", value);
            }
        }
        public event EventHandler<LuaEventArgs> GetItemInfoReceived
        {
            add
            {
                RegisterEvent("GET_ITEM_INFO_RECEIVED", value);
            }
            remove
            {
                UnregisterEvent("GET_ITEM_INFO_RECEIVED", value);
            }
        }
        public event EventHandler<LuaEventArgs> MaxSpellStartRecoveryOffsetChanged
        {
            add
            {
                RegisterEvent("MAX_SPELL_START_RECOVERY_OFFSET_CHANGED", value);
            }
            remove
            {
                UnregisterEvent("MAX_SPELL_START_RECOVERY_OFFSET_CHANGED", value);
            }
        }
    }
}