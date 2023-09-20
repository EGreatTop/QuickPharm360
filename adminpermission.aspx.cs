using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuickPharm360.Model;

namespace QuickPharm360
{
    public partial class adminpermission : System.Web.UI.Page
    {
        private string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private SqlDataAdapter da;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["denyurl"].ToString() == "gYUg73637&?&!__Ggbjkbn*^7564G")
                    {
                        LblAdminUsername.Text = Session["username"].ToString();
                        ddlUsername.Items.Clear();
                        using (con = new SqlConnection(conn))
                        {
                            con.Open();
                            using (cmd = new SqlCommand("Select count (distinct username) from adminlogin", con))
                            {
                                using (dr = cmd.ExecuteReader())
                                {
                                    if (dr.Read() && !dr.IsDBNull(0))
                                    {
                                        int result = int.Parse(dr.GetValue(0).ToString());
                                        if (result > 1)
                                        {
                                            dr.Dispose();
                                            using (cmd = new SqlCommand("Select distinct username from adminlogin", con))
                                            {
                                                using (dr = cmd.ExecuteReader())
                                                {
                                                    ddlUsername.Items.Add("- Select User -");
                                                    while (dr.Read() && !dr.IsDBNull(0))
                                                    {
                                                        ddlUsername.Items.Add(dr.GetValue(0).ToString());
                                                    }
                                                }
                                            }
                                        }
                                        else if (result == 1)
                                        {
                                            dr.Dispose();
                                            using (cmd = new SqlCommand("Select distinct username from adminlogin", con))
                                            {
                                                using (dr = cmd.ExecuteReader())
                                                {
                                                    if (dr.Read() && !dr.IsDBNull(0))
                                                    {
                                                        ddlUsername.Items.Add("- Select User -");
                                                        ddlUsername.Items.Add(dr.GetValue(0).ToString());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("adminlogin");
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("adminlogin");
            }
        }

        protected void BtnSetAccess_Click(object sender, EventArgs e)
        {
            if (ddlUsername.Text != "- Select User -" && ddlAccess.Text != "- Pls Select -")
            {
                QuickPharm qp = new QuickPharm();
                qp.AdminUser = LblAdminUsername.Text;
                qp.username = ddlUsername.Text;
                if (ddlAccess.Text == "Allow")
                {
                    qp.AdminUserEnable();
                }
                else if (ddlAccess.Text == "Deny")
                {
                    qp.AdminUserDisable();
                }
                else if (ddlAccess.Text == "Delete")
                {
                    qp.AdminUserDelete();
                }
                else if (ddlAccess.Text == "Make Admin")
                {
                    qp.AdminMakeAdmin();
                }
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = qp.ResponseMsg;
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
                Response.Redirect("admintester");
            }
        }

        protected void BtnSetEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.email = txtEmail.Text;
                qp.AdminSetEmail();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = qp.ResponseMsg;
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s).";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s).";

            }
        }

        protected void BtnYes_Click(object sender, EventArgs e)
        {

        }

        protected void BtnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.username = LblAdminUsername.Text;
                qp.password = txtNewPassword.Text;
                qp.AdminUpdatePassword();
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else
            {
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s).";

            }
        }
    }
}