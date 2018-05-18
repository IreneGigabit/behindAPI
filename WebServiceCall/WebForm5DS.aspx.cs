using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebServiceCall {
	public partial class WebForm5DS : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void Button1_Click(object sender, EventArgs e) {
			ServiceReferenceDS.WebService5DSSoapClient ws = new ServiceReferenceDS.WebService5DSSoapClient();
			DataSet tmpstr = ws.Get_Title(TextBox1.Text);
			ws.Close();
			Label1.Text = tmpstr.Tables[0].Rows[0]["ap_cname1"].ToString();
		}
	}
}