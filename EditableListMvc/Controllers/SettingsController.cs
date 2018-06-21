using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EditableListMvc.Models;

namespace EditableListMvc.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index() {
            var model = new MyViewModel();

            // you will probably wanna call your database here to 
            // retrieve those values, but for the purpose of my example that
            // should be fine
            model.Settings = Enumerable.Range(1, 5).Select(x => new Setting
            {
                SettingId = x,
                Name = "setting " + x,
                Value = "value " + x
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(IList<Setting> setting) {
            // Currently for testing purposes only. Breakpoint is set to setting.Count
            return Content(setting.Count.ToString());
        }
    }
}
