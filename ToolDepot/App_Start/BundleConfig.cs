using System.Web;
using System.Web.Optimization;
using ToolDepot.Filters.Helpers;

namespace ToolDepot
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/html5").Include("~/Scripts/html5.js"));

            //File Upload
            bundles.Add(new ScriptBundle("~/bundles/fileupload")
                .Include(
                    "~/Scripts/FileUpload/tmpl.min.js",
                    "~/Scripts/FileUpload/canvas-to-blob.min.js",
                    "~/Scripts/FileUpload/canvas-to-blob.min.js",
                    "~/Scripts/FileUpload/load-image.min.js",
                    "~/Scripts/FileUpload/bootstrap-image-gallery.min.js",
                    "~/Scripts/FileUpload/jquery.iframe-transport.js",
                    "~/Scripts/FileUpload/jquery.fileupload.js",
                    "~/Scripts/FileUpload/jquery.fileupload-ip.js",
                    "~/Scripts/FileUpload/jquery.fileupload-ui.js",
                    "~/Scripts/FileUpload/locale.js",
                    "~/Scripts/FileUpload/main.js"
                    ));
            bundles.Add(new StyleBundle("~/Content/fileupload").Include("~/Content/FileUpload/*.css"));

            bundles.Add(new ScriptBundle("~/bundles/validation").Include("~/Scripts/bootstrap.validation.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            //bundles.Add(new StyleBundle("~/Content/assets/bootstrap").Include("~/assets/css/bootstrap.min.css"));

          
            var less = new StyleBundle("~/Content/less").Include("~/Content/css/site.less", "~/Content/bootstrap/bootstrap.less",
                "~/Content/css/alignment.less");

            less.Transforms.Add(new LessMinify());

            bundles.Add(less);

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


        }
    }
}