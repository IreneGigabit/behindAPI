using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WebServicePrj {
	/// <summary>
	///WebService5DS 的摘要描述
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
	// [System.Web.Script.Services.ScriptService]
	public class WebService5DS : System.Web.Services.WebService {

		[WebMethod]
		public DataSet Get_Title(string ap_sqlno) {
			DataSet u_DataSet = new DataSet();

			SqlConnection _conn = new SqlConnection("Server=web08;Database=sindbs;User ID=web_usr;Password=web1823");
			_conn.Open();

			SqlDataAdapter myAdapter = new SqlDataAdapter("select top 50 ap_cname1 from apcust where apsqlno='" + ap_sqlno + "'", _conn);
			myAdapter.Fill(u_DataSet);
			if (_conn != null) {
				_conn.Close(); _conn.Dispose();
			}
			return u_DataSet;
		}
	}
}
