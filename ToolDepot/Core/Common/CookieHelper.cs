using System;
using System.Collections.Generic;
using System.Web;

namespace ToolDepot.Core.Common
{
    public partial class CookieHelper
    {

        public static string MeetingScheduleUrl = "c_schedule";

        public static string UtmSource = "utm_source";
        public static string UtmType = "utm_type";
        public static string UtmLink = "utm_link";

        private CookieHelper()
        { }

        public static void SetCookieSecure(string cookieName, string value, int? expirationMinutes = null)
        {

            SetCookie(cookieName, EncryptionHelper.Encrypt(value), expirationMinutes);
        }

        public static string GetCookieSecure(string cookieName)
        {
            string value = GetCookie(cookieName);
            return EncryptionHelper.Decrypt(value);
        }

        public static string GetCookie(string cookieName)
        {
            if (string.IsNullOrEmpty(cookieName))
                throw new Exception("Cookie name not specified.");

            string cookieVal = String.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
                cookieVal = cookie.Value;
            return cookieVal;
        }


        public static void SetCookie(string cookieName, string value, int? expirationMinutes = null)
        {

            if (string.IsNullOrEmpty(cookieName))
                throw new Exception("Cookie name not specified.");

            HttpCookie cookie = new HttpCookie(cookieName, value);
            if (expirationMinutes.HasValue)
                cookie.Expires = DateTime.Now.AddMinutes(expirationMinutes.Value);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }




        /// <summary>
        /// Delete the Cookie from the cache
        /// </summary>
        public static void DeleteCookie(string cookieName)
        {
            if (string.IsNullOrEmpty(cookieName))
                throw new Exception("Cookie name not specified.");

            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static bool CookieExists(string cookieName)
        {
            bool exists = false;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
                exists = true;
            return exists;
        }

        public static Dictionary<string, string> GetAllCookies()
        {
            Dictionary<string, string> cookies = new Dictionary<string, string>();
            foreach (string key in HttpContext.Current.Request.Cookies.AllKeys)
            {
                cookies.Add(key, HttpContext.Current.Request.Cookies[key].Value);
            }
            return cookies;
        }

        public static void DeleteAllCookies()
        {
            var cookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (var cookie in cookies)
            {
                DeleteCookie(cookie);
            }
        }
    }

}