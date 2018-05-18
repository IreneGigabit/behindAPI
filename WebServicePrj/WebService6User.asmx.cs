using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WebServicePrj {
	/// <summary>
	///WebServiceUser 的摘要描述
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
	// [System.Web.Script.Services.ScriptService]
	public class WebService6User : System.Web.Services.WebService {

		[WebMethod]
		public string User_Login(string Login_Id, string Login_Pass) {
			string return_str = "";

			SqlConnection _conn = new SqlConnection("Server=web08;Database=sindbs;User ID=web_usr;Password=web1823");
			_conn.Open();

			SqlDataAdapter myAdapter = new SqlDataAdapter("select * from sysctrl.dbo.scode where scode='" + Login_Id + "'", _conn);

			DataTable DT = new DataTable();
			myAdapter.Fill(DT);

			return_str = "<br>" + DT.Rows[0]["sys_pwd"].ToString() + "<BR>" + GetMD5(Login_Pass);

			if (_conn != null) {
				_conn.Close(); _conn.Dispose();
			}
			return return_str;
		}

		public static string GetMD5(string data) {
			if (data.Length != 0) {
				System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();//建立一個MD5
				byte[] source = System.Text.Encoding.ASCII.GetBytes(data);//將字串轉為Byte[]
				byte[] crypto = md5.ComputeHash(source);//進行MD5加密
				System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
				for (int i = 0; i < crypto.Length; i++) {
					sBuilder.Append(crypto[i].ToString("x2"));
				}
				return sBuilder.ToString();
			} else {
				return "";
			}
		}
	}
}
