using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCall {
	public partial class WebForm4DB : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void Button1_Click(object sender, EventArgs e) {
			ServiceReferenceDB.WebService4SoapClient ws = new ServiceReferenceDB.WebService4SoapClient();
			string tmpstr = null;
			tmpstr = ws.Get_Title(TextBox1.Text);
			ws.Close();
			Label1.Text = tmpstr;
		}
	}
}