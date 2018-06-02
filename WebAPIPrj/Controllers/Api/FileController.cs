using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WebAPIPrj.Controllers.Api {
    public class FileController : ApiController {

        //http://localhost:53404/api/File/
        public HttpResponseMessage PostFormData() {
            HttpRequest req = HttpContext.Current.Request;
            try {
                HttpPostedFile f = null;
				string fileName = "";
				string url = "";

                if (req.Files.Count > 0) {
                    string FilePath = req.MapPath("~/upload/");
                    if (!Directory.Exists(FilePath)) {
                        Directory.CreateDirectory(FilePath);
                    }

                    foreach (string FileName in req.Files.Keys) {
                        f = req.Files[FileName];
                        f.SaveAs(FilePath + f.FileName);

						fileName = f.FileName;
						url = "/upload/" + fileName;
                    }
                }

				StringBuilder sbJson = new StringBuilder(4000);

				HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];
				string CKEditorFuncNum = req["CKEditorFuncNum"];

				var myJson = new {
					fileName = fileName,
					uploaded = int.Parse(CKEditorFuncNum ?? "99"),
					url = url,
					message = req["message"]
				};

                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
				response.Content = new StringContent(JsonConvert.SerializeObject(myJson), Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
