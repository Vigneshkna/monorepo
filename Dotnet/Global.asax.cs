using Mis.Core;
using MisLibrary.Utils;
using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NdcPlanning
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetupMiniProfiler();
        }

        private void SetupMiniProfiler()
        {
            Misc.GetOpenConnectionFromConnectionString = (c) =>
            {
                return new StackExchange.Profiling.Data.ProfiledDbConnection(Misc.PlainGetOpenConnectionFromConnectionString(c), MiniProfiler.Current);
            };

            //MiniProfiler.Settings.Results_Authorize = x => false;

            MiniProfiler.Settings.MaxJsonResponseSize = int.MaxValue;

            /*
             * Uncomment to enable profiling of view rendering. However this can cause a lot of traffic and javascript activity on some screens.
             * Also note that the results are unrepresentative of live running if debug is set in the web.config.
            var copy = ViewEngines.Engines.ToList();
            ViewEngines.Engines.Clear();
            foreach (var item in copy)
            {
                ViewEngines.Engines.Add(new ProfilingViewEngine(item));
            }
             */
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}