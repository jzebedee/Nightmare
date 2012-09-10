using System;
using System.Collections.Generic;
using Bloodstream.Interfaces;

namespace Bloodstream.Lib
{
    public class BlackList : Dictionary<ulong, BlackListItem>
    {
        public void Add(IWowObject target, int durationSeconds = 5* 60)
        {
            if (target.Valid())
            {
                if (this.ContainsKey(target.GUID))
                {
                    var item = this[target.GUID];
                    item.Count = ++item.Count;
                    item.Time = DateTime.Now;
                    //double the time
                    item.Duration = item.Duration.Add(item.Duration);
                }
                else
                {
                    var item = new BlackListItem()
                    {
                        Id = target.GUID
                        ,
                        Time = DateTime.Now
                        ,
                        Duration = new TimeSpan(0, 0, durationSeconds)
                        ,
                        Count = 1

                    };
                    this.Add(item.Id, item);

                }
            }
        }

        public bool Check(IWowObject target)
        {
            if (!this.ContainsKey(target.GUID))
                return true;

            var item = this[target.GUID];

            if (item.Count > 10)
                return false;

            var since = DateTime.Now - item.Time;

            if (since < item.Duration)
                return false;

            return true;
        }
    }

    public class BlackListItem
    {
        public ulong Id { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan Duration { get; set; }
        public int Count { get; set; }
    }
}