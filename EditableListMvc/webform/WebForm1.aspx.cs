using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EditableListMvc.webform
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            for (int i = 0; i <= 3; i++) {
                Response.Write("list=" + Request["list[" + i + "]"] + "<BR>");
            }
                
        }
    }
}