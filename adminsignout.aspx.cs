using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickPharm360
{
    public partial class adminsignout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("adminlogin");
        }
    }
}