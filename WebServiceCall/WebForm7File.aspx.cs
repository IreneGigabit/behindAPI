using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceCall {
	public partial class WebForm7File : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void Button1_Click(object sender, EventArgs e) {
			ServiceReferenceFile.WebServiceFileSoapClient ws = new ServiceReferenceFile.WebServiceFileSoapClient();
			if (FileUpload1.HasFile) {
				Response.Write(ws.UploadFile(FileUpload1.FileBytes, FileUpload1.FileName));
			}
		}
	}
}