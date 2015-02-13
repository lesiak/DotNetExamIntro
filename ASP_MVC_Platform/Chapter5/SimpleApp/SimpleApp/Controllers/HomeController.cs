﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
          //  return View(HttpContext.Application["events"]);
            return View(GetTimeStamps());
        }

        [HttpPost]
        public ActionResult Index(Color color) {
            Color? oldColor = Session["color"] as Color?;
            HttpContextBase cb = HttpContext;
            if (oldColor != null) {
                Votes.ChangeVote(color, (Color)oldColor);
            } else {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
           // return View(HttpContext.Application["events"]);
            return View(GetTimeStamps());
        }

        public ActionResult Modules() {            
            //"__DynamicModule_CommonModules.InfoModule, CommonModules, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4dc99975-8944-465f-bb69-3a930625ef0d"
            var modules = HttpContext.ApplicationInstance.Modules;
            Tuple<string, string>[] data = modules.AllKeys
                .Select(x => new Tuple<string, string>(
                    x.StartsWith("__Dynamic") ? x.Split('_', ',')[3] : x,
                    modules[x].GetType().Name))
               .OrderBy(x => x.Item1).ToArray();
            return View(data);
        }

        private List<string> GetTimeStamps() {
            return new List<string> {
                string.Format("App timestamp: {0}", 
                    HttpContext.Application["app_timestamp"]),
                string.Format("Request timestamp: {0}", Session["request_timestamp"]),
            };
        }
    }
}