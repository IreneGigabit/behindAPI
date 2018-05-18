using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCall {
	public partial class WebForm1 : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void Button1_Click(object sender, EventArgs e) {
			ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();
			string tmpstr = null;
			tmpstr = ws.teach(TextBox1.Text, TextBox2.Text);
			ws.Close();
			Label1.Text = tmpstr;
		}
	}
}