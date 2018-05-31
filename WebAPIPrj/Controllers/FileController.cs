using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;

namespace WebAPIPrj.Controllers {
    public class FileController : ApiController {

        //http://localhost:53404/api/File/
        public HttpResponseMessage PostFormData() {
            HttpRequest req = HttpContext.Current.Request;
            try {
                HttpPostedFile f = null;

                if (req.Files.Count > 0) {
                    string FilePath = req.MapPath("~/upload/");
                    if (!Directory.Exists(FilePath)) {
                        Directory.CreateDirectory(FilePath);
                    }

                    foreach (string FileName in req.Files.Keys) {
                        f = req.Files[FileName];
                        f.SaveAs(FilePath + f.FileName);
                    }
                }

                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, "<script>alert('上傳成功" + req["CKEditorFuncNum"] + "');</script>");
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-javascript");
                return response;
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
