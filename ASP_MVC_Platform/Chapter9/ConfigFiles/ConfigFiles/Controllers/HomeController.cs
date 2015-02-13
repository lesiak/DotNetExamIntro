using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using ConfigFiles.Infrastructure;

namespace ConfigFiles.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Dictionary<string, string> configData = new Dictionary<string, string>();
            foreach (string key in WebConfigurationManager.AppSettings) {
                configData.Add(key, WebConfigurationManager.AppSettings[key]);
            }

            foreach (ConnectionStringSettings cs in WebConfigurationManager.ConnectionStrings) {
                configData.Add(cs.Name, cs.ProviderName + " " + cs.ConnectionString);
            }
            CustomDefaults customDefaults =
                (CustomDefaults) WebConfigurationManager.OpenWebConfiguration("/").GetSectionGroup("customDefaults");

           // NewUserDefaultsSection nuDefaults = WebConfigurationManager.GetWebApplicationSection("newUserDefaults") as NewUserDefaultsSection;
            //PlaceSection placeSection = WebConfigurationManager.GetWebApplicationSection("places") as PlaceSection;
            if (customDefaults != null)
            {
                NewUserDefaultsSection nuDefaults = customDefaults.NewUserDefaults;
                if (nuDefaults != null)
                {
                    configData.Add("City", nuDefaults.City);
                    configData.Add("Country", nuDefaults.Country);
                    configData.Add("Language", nuDefaults.Language);
                    configData.Add("Region", nuDefaults.Region.ToString());
                }

                foreach (Place place in customDefaults.Places.Places) {
                    configData.Add(place.Code, string.Format("{0} ({1})", place.City, place.Country));
                }
            }

            SystemWebSectionGroup sysWeb =
                 (SystemWebSectionGroup)WebConfigurationManager.OpenWebConfiguration("/").GetSectionGroup("system.web");
            configData.Add("debug", sysWeb.Compilation.Debug.ToString());
            configData.Add("targetFramework", sysWeb.Compilation.TargetFramework);
          	

            return View(configData);
        }


        public ActionResult OtherAction() {
            AppSettingsSection appSettings = WebConfigurationManager.OpenWebConfiguration("~/Views/Home").AppSettings;
            Dictionary<string, string> configData = appSettings.Settings.AllKeys.ToDictionary(key => key, key => appSettings.Settings[key].Value);

            return View("Index", configData);
        }

        public ActionResult DisplaySingle() {                      
            //return View((object)WebConfigurationManager.AppSettings["defaultLanguage"]);
            //PlaceSection placeSection = WebConfigurationManager.GetWebApplicationSection("places") as PlaceSection;
            PlaceSection placeSection = WebConfigurationManager.GetWebApplicationSection("customDefaults/places") as PlaceSection;
            Place defaultPlace = placeSection.Places[placeSection.Default];
            return View((object)string.Format("The default place is {0} ({1})", defaultPlace.City, defaultPlace.Country));

        }
    }
}