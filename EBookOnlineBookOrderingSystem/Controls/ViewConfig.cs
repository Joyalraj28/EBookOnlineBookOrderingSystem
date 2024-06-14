using EBookOnlineBookOrderingSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Controls
{
    public static class ViewConfig
    {
        public static bool IsShowNavigationBar { get; set; }

        public static bool IsUserLogin => SessionControls<Users>.GetValue("LoginUser") != null;
    }
}