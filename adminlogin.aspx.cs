using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuickPharm360.Model;

namespace QuickPharm360
{
    public partial class adminlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.username = txtUsername.Text;
                qp.password = txtPassword.Text;
                qp.AdminLogin();
                if (qp.ResponseMsg == "Success!")
                {
                    Session["username"] = txtUsername.Text;
                    Session["denyurl"] = "gYUg73637&?&!__Ggbjkbn*^7564G";
                    Response.Redirect("admindashboard");
                }
                else
                {
                    PanelMessage.Visible = true;
                    BtnMessage.Text = qp.ResponseMsg;
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                    //this.LblMessage.Text = qp.ResponseMsg;
                    //BtnYes.Visible = false;

                }
            }
            else
            {
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)!";
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s)!";
                //BtnYes.Visible = false;
            }
        }
    }
}