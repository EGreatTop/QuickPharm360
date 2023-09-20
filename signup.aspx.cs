using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuickPharm360.Model;

namespace QuickPharm360
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.name = txtName.Text;
                qp.phone = txtPhone.Text;
                qp.ClientSignUp();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s)!";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)";
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s)!";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)";
            }
        }
    }
}