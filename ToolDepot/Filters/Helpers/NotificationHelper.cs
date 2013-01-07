using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Models;

namespace ToolDepot.Filters.Helpers
{
    public static class NotificationHelper
    {

        public static void SuccessNotification(this Controller context, string message, bool persistForTheNextRequest = true)
        {
            AddNotification(context, NotifyType.Success, message, persistForTheNextRequest);
        }

        public static void ErrorNotification(this Controller context, string message, bool persistForTheNextRequest = true)
        {
            AddNotification(context, NotifyType.Error, message, persistForTheNextRequest);
        }

        public static void InfoNotification(this Controller context, string message, bool persistForTheNextRequest = true)
        {
            AddNotification(context, NotifyType.Info, message, persistForTheNextRequest);
        }


        public static void AddNotification(this Controller context, NotifyType type, string message, bool persistForTheNextRequest)
        {

            string dataKey = string.Format("tooldepot.notifications.{0}", type);
            if (persistForTheNextRequest)
            {
                if (context.TempData[dataKey] == null)
                    context.TempData[dataKey] = new List<string>();
                ((List<string>)context.TempData[dataKey]).Add(message);
            }
            else
            {
                if (context.ViewData[dataKey] == null)
                    context.ViewData[dataKey] = new List<string>();
                ((List<string>)context.ViewData[dataKey]).Add(message);
            }

        }

        public static string AvailabilitySetMessage = "Availability set";
    }
}
