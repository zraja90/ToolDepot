using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToolDepot.Helpers
{
    public class TimeRange
    {
        public static SelectList GetFutureDates()
        {
            var list = new List<string>();
            var today = DateTime.Now.ToLocalTime();
            for (int i = 1; i < 14; i++)
            {
                DateTime tmpDate = today.AddDays(i);
                if (tmpDate.DayOfWeek != DayOfWeek.Saturday && tmpDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    list.Add(tmpDate.ToString("MMMM dd, yyyy"));
                }
            }
            
            var dates = new SelectList(list, 0);
            return dates;
        }

        public static SelectList GetWorkHours()
        {
            var list = new List<string>();
            var start = new DateTime(2012,01,02,8,0,0,0);
            const int duration = 30;

            for (int i = 0; i <= 18; i++)
            {
                var newTime = new TimeSpan(0, duration*i, 0);
                var tmpData = start.Add(newTime);
                list.Add(tmpData.ToShortTimeString());
            }
            var times = new SelectList(list, 0);
            return times;
        }
    }
}