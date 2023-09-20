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
    public partial class drugrecord : System.Web.UI.Page
    {
        private string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private SqlDataAdapter da;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Lblusername.Text = Session["username"].ToString();
                    ddlCategories.Items.Clear();
                    using (con = new SqlConnection(conn))
                    {
                        con.Open();
                        using (cmd = new SqlCommand("Select count (distinct category) from drugcategory", con))
                        {
                            using (dr = cmd.ExecuteReader())
                            {
                                if (dr.Read() && !dr.IsDBNull(0))
                                {
                                    int result = int.Parse(dr.GetValue(0).ToString());
                                    if (result > 1)
                                    {
                                        dr.Dispose();
                                        using (cmd = new SqlCommand("Select distinct category from drugcategory", con))
                                        {
                                            using (dr = cmd.ExecuteReader())
                                            {
                                                ddlCategories.Items.Add("- Pls Select -");
                                                while (dr.Read() && !dr.IsDBNull(0))
                                                {
                                                    ddlCategories.Items.Add(dr.GetValue(0).ToString());
                                                }
                                            }
                                        }
                                    }
                                    else if (result == 1)
                                    {
                                        dr.Dispose();
                                        using (cmd = new SqlCommand("Select distinct category from drugcategory", con))
                                        {
                                            using (dr = cmd.ExecuteReader())
                                            {
                                                if (dr.Read() && !dr.IsDBNull(0))
                                                {
                                                    ddlCategories.Items.Add("- Pls Select -");
                                                    ddlCategories.Items.Add(dr.GetValue(0).ToString());
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
                    //ddlCategories.Items.Clear();
                    //using (con = new SqlConnection(conn))
                    //{
                    //    con.Open();
                    //    using (cmd = new SqlCommand("Select count (distinct category) from drugcategory", con))
                    //    {
                    //        using (dr = cmd.ExecuteReader())
                    //        {
                    //            if (dr.Read() && !dr.IsDBNull(0))
                    //            {
                    //                int result = int.Parse(dr.GetValue(0).ToString());
                    //                if (result > 1)
                    //                {
                    //                    dr.Dispose();
                    //                    using (cmd = new SqlCommand("Select distinct category from drugcategory", con))
                    //                    {
                    //                        using (dr = cmd.ExecuteReader())
                    //                        {
                    //                            ddlCategories.Items.Add("- Pls Select -");
                    //                            while (dr.Read() && !dr.IsDBNull(0))
                    //                            {
                    //                                ddlCategories.Items.Add(dr.GetValue(0).ToString());
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //                else if (result == 1)
                    //                {
                    //                    dr.Dispose();
                    //                    using (cmd = new SqlCommand("Select distinct category from drugcategory", con))
                    //                    {
                    //                        using (dr = cmd.ExecuteReader())
                    //                        {
                    //                            if (dr.Read() && !dr.IsDBNull(0))
                    //                            {
                    //                                ddlCategories.Items.Add("- Pls Select -");
                    //                                ddlCategories.Items.Add(dr.GetValue(0).ToString());
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception)
            {
                Response.Redirect("adminlogin");
            }
        }

        protected void BtnSaveDrug_Click(object sender, EventArgs e)
        {
            if (ddlCategories.Text != "- Pls Select -" && txtDrugName.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.category = ddlCategories.Text;
                qp.drug = txtDrugName.Text;
                qp.AddDrugs();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = qp.ResponseMsg;
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else 
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s)";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)!";
            }
        }

        protected void BtnCategory_Click(object sender, EventArgs e)
        {
            if(txtCategories.Text !="")
            {
                QuickPharm qp = new QuickPharm();
                qp.category = txtCategories.Text;
                qp.AddDrugCategory();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = qp.ResponseMsg;
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s)";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)!";
            }
        }
    }
}