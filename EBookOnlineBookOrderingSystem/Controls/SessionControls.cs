using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Controls
{
    public static class SessionControls<T>
    {
        public static T GetValue(string key)
        {
            if (System.Web.HttpContext.Current.Session[key] != null)
            {
                return JsonConvert.DeserializeObject<T>(System.Web.HttpContext.Current.Session[key].ToString());
            }

            return default;
        }

        public static void ClearValue(string key)
        {
            if (System.Web.HttpContext.Current.Session[key] != null)
            {
                System.Web.HttpContext.Current.Session[key] = null;
            }
        }

        public static void SetValue(string key,T value)
        {
            System.Web.HttpContext.Current.Session[key] = JsonConvert.SerializeObject(value);
        }
    }
}