﻿using System.Web;
using System.Web.Optimization;

namespace AdminDashboard
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/LoginJavaScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/CommonStyles/DashbordStyleSheet.css",
                      "~/Content/CommonStyles/FormStyleSheet.css",
                      "~/Content/fontawesome_5.15.4/css/all.min.css",
                      "~/Content/Login_StyleSheet.css",
                      "~/Content/CommonStyles/TableStyleSheet.css"));

            bundles.Add(new StyleBundle("~/Content/Home/css").Include(
                      "~/Content/CommonStyles/HomeStyleSheet.css"));
        }
    }
}
