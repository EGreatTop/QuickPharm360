using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuickPharm360.Model;

namespace QuickPharm360
{
    public partial class adminsignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.username = txtUsername.Text;
                qp.password = txtPassword.Text;
                qp.AdminCreateAccount();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = qp.ResponseMsg;
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s)!";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)!";
            }
        }
    }
}