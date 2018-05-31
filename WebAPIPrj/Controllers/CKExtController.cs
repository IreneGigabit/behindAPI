using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebAPIPrj.Controllers {
    public class CKExtController : Controller {
        //
        // GET: /CKExt/
        /*
        const string filesavepath = "~/App_Data/";
        const string baseUrl = "~/App_Data/";

        //const string scriptTag = "<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction({0}, '{1}', '{2}')</script>";
        const string scriptTag = "<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction({0}, '{1}')</script>";

        public ActionResult Index() {
            var funcNum = 0;
            int.TryParse(Request["CKEditorFuncNum"], out funcNum);

            if (Request.Files == null || Request.Files.Count < 1)
                return BuildReturnScript(funcNum, null, "No file has been sent");

            string fileName = string.Empty;
            SaveAttatchedFile(filesavepath, Request, ref fileName);
            var url = baseUrl + fileName;

            return BuildReturnScript(funcNum, url, null);
        }

        private ContentResult BuildReturnScript(int functionNumber, string url, string errorMessage) {
            return Content(
                string.Format(scriptTag, functionNumber, HttpUtility.JavaScriptStringEncode(url ?? ""), 
                "text/html")
                );
        }

        private void SaveAttatchedFile(string filepath, HttpRequestBase Request, ref string fileName) {
            for (int i = 0; i < Request.Files.Count; i++) {
                var file = Request.Files[i];
                if (file != null && file.ContentLength > 0) {
                    fileName = Path.GetFileName(file.FileName);
                    string targetPath = Server.MapPath(filepath);
                    if (!Directory.Exists(targetPath)) {
                        Directory.CreateDirectory(targetPath);
                    }
                    fileName = Guid.NewGuid() + fileName;
                    string fileSavePath = Path.Combine(targetPath, fileName);
                    file.SaveAs(fileSavePath);
                }
            }
        }
        */

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload) {
            if (upload.ContentLength <= 0)
                return null;

            //獲取圖片文件名
            var fileName = System.IO.Path.GetFileName(upload.FileName);
            var filePhysicalPath = Server.MapPath("~/upload/" + fileName);

            upload.SaveAs(filePhysicalPath);  //上傳圖片到指定文件夾

            var url = "/upload/" + fileName;
            //string CKEditorFuncNum = Request["CKEditorFuncNum"];

            //上傳成功後，回傳json
            return Json(new{
                fileName=fileName,
                uploaded = 1,
                url=url.Replace("/","\\/"),
                message="上傳成功"
            });
        }
    }
}
