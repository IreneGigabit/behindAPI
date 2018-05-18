using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WebServicePrj {
	/// <summary>
	///WebService4 的摘要描述
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
	// [System.Web.Script.Services.ScriptService]
	public class WebService4 : System.Web.Services.WebService {

		[WebMethod]
		public string Get_Title(string ap_sqlno) {
			string u_Title = "";

			SqlConnection _conn = new SqlConnection("Server=web08;Database=sindbs;User ID=web_usr;Password=web1823");
			SqlCommand _cmd = new SqlCommand("select top 50 ap_cname1 from apcust where apsqlno='" + ap_sqlno + "'", _conn);
			try {
				_conn.Open();

				SqlDataReader dr = _cmd.ExecuteReader();
				if (dr.Read()) {
					u_Title = dr["ap_cname1"].ToString();
				}
				dr.Close();
			}
			catch (Exception ex) {
				u_Title = "Exception(錯誤訊息)----   " + ex.ToString();
			}
			finally {
				if (_conn != null) {
					_conn.Close(); _conn.Dispose();
				}
				_cmd.Dispose();
			}

			return u_Title;
		}
	}
}
