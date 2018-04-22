using System.Web;
using System.Web.Optimization;

namespace UI
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					   "~/Scripts/move-top.js",
                      "~/Scripts/easing.js",
                      "~/Scripts/respond.js",
                    
                      "~/Scripts/jquery.flexslider.js",
                     
                       "~/Scripts/API.js",
                       "~/Scripts/_Layout.js"
                       , "~/Scripts/angular.min.js",
                       "~/Scripts/angular-resource.min.js",
                       "~/Scripts/angular-route.min.js"
                      ));
            //Devextreme Js File
            bundles.Add(new ScriptBundle("~/bundles/dx").Include(
                    "~/Scripts/dx/dx.all.js"));

            bundles.Add(new ScriptBundle("~/bundles/minicart").Include(
                     
                        "~/Scripts/minicart.min.js"
                      
                      ));
            bundles.Add(new ScriptBundle("~/bundles/items").Include(

                     "~/Scripts/AngularController/ItemsController.js"

                   ));
            bundles.Add(new ScriptBundle("~/bundles/products").Include(

                        "~/Scripts/Products.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/font-awesome.css",
                      "~/Content/flexslider.css",
                        "~/Content/dx/dx.common.css",
                      "~/Content/dx/dx.light.css"
                      ));
          
        }
    }
}
