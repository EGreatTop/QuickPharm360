using QuickPharm360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickPharm360
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            QuickPharm qp = new QuickPharm();
            qp.phone = txtPhone.Text;
            qp.ClientLogin();
            if (qp.ResponseMsg == "1")
            {
                Session["username"] = txtPhone.Text;
                Session["name"] = qp.name;
                Session["denyurl"] = "gYUg73637&?&!__Ggbjkbn*^7564G";
                Response.Redirect("clientdashboard");
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Invalid login.";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Invalid Login.";
            }
        }
    }
}