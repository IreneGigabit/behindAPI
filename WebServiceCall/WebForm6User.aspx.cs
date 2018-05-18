using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCall {
	public partial class WebForm6User : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void Button1_Click(object sender, EventArgs e) {
			ServiceReferenceLogin.WebService6UserSoapClient ws = new ServiceReferenceLogin.WebService6UserSoapClient();
			
			string tmpstr = null;
			tmpstr = ws.User_Login(TextBox1.Text, TextBox2.Text);
			ws.Close();
			Label1.Text = tmpstr;
		}
	}
}