using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebAPIPrj.Controllers {
    public class CKExtController : Controller {
		[HttpPost]
		public ActionResult UploadImage(HttpPostedFileBase upload, string CKEditorFuncNum) {
			if (upload.ContentLength <= 0)
				return null;

			//上傳目錄
			var uploadFolder = "~/upload/";

			//獲取圖片文件名
			var fileAsset = Path.GetFileNameWithoutExtension(upload.FileName);
			var fileExt = Path.GetExtension(upload.FileName);
			var fileName = string.Format(@"{0}_{1}{2}", fileAsset, DateTime.Now.Ticks, fileExt);

			var filePhysicalPath = Server.MapPath(uploadFolder + fileName);
			upload.SaveAs(filePhysicalPath);  //上傳圖片到指定文件夾

			var url = uploadFolder.Replace("~", "") + fileName;
			//string CKEditorFuncNum = Request["CKEditorFuncNum"];

			//上傳成功後，回傳json
			return Json(new {
				fileName = filePhysicalPath,
				uploaded = int.Parse(Request["CKEditorFuncNum"] ?? "99"),
				//url = url.Replace("/", "\\/"),
				url = url,
				message = "上傳成功"
			});
		}

    }
}
