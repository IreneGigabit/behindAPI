using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace WebServicePrj {
	/// <summary>
	///WebServiceFile 的摘要描述
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
	// [System.Web.Script.Services.ScriptService]
	public class WebServiceFile : System.Web.Services.WebService {

		[WebMethod]
		public string UploadFile(byte[] fs,string fileName) {
			try {
				if (!Directory.Exists(Server.MapPath(@"~\upload\"))) {
					Directory.CreateDirectory(Server.MapPath(@"~\upload\"));
				}

				MemoryStream memoryStream = new MemoryStream(fs);
				FileStream fileStream = new FileStream(Server.MapPath(@"~\upload\" + fileName), FileMode.Create);
				memoryStream.WriteTo(fileStream);
				memoryStream.Close();
				fileStream.Close();
				fileStream = null;
				memoryStream = null;
				
				return "上傳成功";
			}
			catch (Exception ex) {
				return ex.Message;
			}
		}
	}
}
