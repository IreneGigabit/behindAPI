using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EditableListMvc.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index()
        {
            var model = new Models.MyViewModel();

            // No idea why you are using ViewBag instead of view model
            // but I am really sick of repeating this so will leave it just that way
            model.Settings = Enumerable.Range(1, 5).Select(x => new Models.Setting {
                SettingId = x,
                Name = "setting " + x,
                Value = "value " + x
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(IList<Models.Setting> setting) {
            // Currently for testing purposes only. Breakpoint is set to setting.Count
            return Content(setting.Count.ToString());
        }
    }
}
