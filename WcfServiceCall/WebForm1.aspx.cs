using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfServiceCall.ServiceReference1;

namespace WcfServiceCall {
	public partial class WebForm1 : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			Service2Client wcfTest = new Service2Client();
			Label1.Text = wcfTest.DoWork();
			wcfTest.Close();
		}
	}
}