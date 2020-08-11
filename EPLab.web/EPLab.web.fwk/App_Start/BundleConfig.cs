﻿using System.Web;
using System.Web.Optimization;

namespace EPLab.web.fwk
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"
                      ,"~/Content/site.css"
                      //,"~/Content/css/site.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                      "~/Content/ckeditor/ckeditor.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapnotify").Include(
                      "~/Content/bootstrap-notify-3.1.3/bootstrap-notify.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Content/js/site.js"));

        }
    }
}
