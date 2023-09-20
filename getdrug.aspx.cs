using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuickPharm360.Model;
using System.Drawing;
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using System.IO;

namespace QuickPharm360
{
    public partial class getdrug : System.Web.UI.Page
    {
        private string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private SqlDataAdapter da;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        public DataTable dt;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["denyurl"].ToString() == "gYUg73637&?&!__Ggbjkbn*^7564G")
                    {
                        Lblusername.Text = Session["username"].ToString();
                        LblName.Text = Session["name"].ToString();

                        using (con = new SqlConnection(conn))
                        {
                            con.Open();//DESC - Sql ordering descending

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
                                            using (cmd = new SqlCommand("Select distinct category from drugcategory order by category", con))
                                            {
                                                using (dr = cmd.ExecuteReader())
                                                {
                                                    ddlCategory.Items.Clear();
                                                    ddlCategory.Items.Add("- Select Product Group -");
                                                    while (dr.Read() && !dr.IsDBNull(0))
                                                    {
                                                        ddlCategory.Items.Add(dr.GetValue(0).ToString());
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
                                                        ddlCategory.Items.Clear();
                                                        ddlCategory.Items.Add("- Select Product Group -");
                                                        ddlCategory.Items.Add(dr.GetValue(0).ToString());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            //Ongoing Chats
                            PlaceHolderDrugChat.Controls.Clear();
                            using (da = new SqlDataAdapter())
                            {
                                //dr.Dispose();
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,date,name from chats where status=@status and phone=@phone and messagemode=@messagemode ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@phone", Lblusername.Text);
                                    cmd.Parameters.AddWithValue("@messagemode", "Get Drug");
                                    //cmd.Parameters.AddWithValue("@phone", phone);
                                    da.Fill(ds);

                                    int i; int counting = 0;

                                    //Load Messages
                                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                    {
                                        string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                        message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                        string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                        string date = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                        string name = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                                        if (tblname == "360QP")
                                        {
                                            var html = "";
                                            html += "<tr>";
                                            html += "<td>";
                                            html += "<div class='form-check'>";
                                            html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-5.png' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            html += "<span class='check'>" + name + "</span>";
                                            html += "</div>";
                                            html += "</td>";
                                            html += "<td><strong><h5>" + message + "</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                            //html += "<td class='td-actions text-right'>";
                                            //html += "<span>" + time + "</span>";
                                            //html += "</td>";
                                            html += "</tr>";
                                            html += "<hr/>";


                                            //html += "<div class='message'>";
                                            //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-5.png' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            //html += "<div class='text-main'>";
                                            //html += "<div class='text-group>";
                                            //html += "<div class='text'>";
                                            //html += "<p><strong>" + message + "</strong><p>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<span>" + time + "</span>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<hr/>";

                                            PlaceHolderDrugChat.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                        else
                                        {
                                            var html = "";
                                            html += "<tr>";
                                            html += "<td>";
                                            html += "<div class='form-check'>";
                                            //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            html += "<span class='check'>" + name + "</span>";
                                            html += "</div>";
                                            html += "</td>";
                                            html += "<td><strong><h5>" + message + "</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                            //html += "<td class='td-actions text-right'>";
                                            //html += "<span>" + time + "</span>";
                                            //html += "</td>";
                                            html += "</tr>";
                                            html += "<hr/>";

                                            //var html = "";
                                            //html += "<div class='message'>";
                                            //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            //html += "<div class='text-main'>";
                                            //html += "<div class='text-group>";
                                            //html += "<div class='text'>";
                                            //html += "<p><strong>" + message + "</strong><p>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<span>" + time + "</span>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<hr/>";
                                            PlaceHolderDrugChat.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                    }
                                    counting++;
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("index");
                    }
                }
                else
                {

                    PlaceHolderDrugChat.Controls.Clear();
                    using (con = new SqlConnection(conn))
                    {
                        con.Open();//DESC - Sql ordering descending

                        //using (cmd = new SqlCommand("Select count (distinct category) from drugcategory", con))
                        //{
                        //    using (dr = cmd.ExecuteReader())
                        //    {
                        //        if (dr.Read() && !dr.IsDBNull(0))
                        //        {
                        //            int result = int.Parse(dr.GetValue(0).ToString());
                        //            if (result > 1)
                        //            {
                        //                dr.Dispose();
                        //                using (cmd = new SqlCommand("Select distinct category from drugcategory order by category", con))
                        //                {
                        //                    using (dr = cmd.ExecuteReader())
                        //                    {
                        //                        ddlCategory.Items.Clear();
                        //                        ddlCategory.Items.Add("- Select Product Group -");
                        //                        while (dr.Read() && !dr.IsDBNull(0))
                        //                        {
                        //                            ddlCategory.Items.Add(dr.GetValue(0).ToString());
                        //                        }
                        //                    }
                        //                }
                        //            }
                        //            else if (result == 1)
                        //            {
                        //                dr.Dispose();
                        //                using (cmd = new SqlCommand("Select distinct category from drugcategory", con))
                        //                {
                        //                    using (dr = cmd.ExecuteReader())
                        //                    {
                        //                        if (dr.Read() && !dr.IsDBNull(0))
                        //                        {
                        //                            ddlCategory.Items.Clear();
                        //                            ddlCategory.Items.Add("- Select Product Group -");
                        //                            ddlCategory.Items.Add(dr.GetValue(0).ToString());
                        //                        }
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}

                        //Ongoing Chats
                        using (da = new SqlDataAdapter())
                        {
                            //dr.Dispose();
                            DataSet ds = new DataSet();
                            string sql = null;
                            sql = "Select tblname,message,time,date,name from chats where status=@status and phone=@phone and messagemode=@messagemode ORDER BY [SN] ASC";
                            //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                            using (cmd = new SqlCommand(sql, con))
                            {
                                da.SelectCommand = cmd;
                                cmd.Parameters.AddWithValue("@status", "On");
                                cmd.Parameters.AddWithValue("@phone", Lblusername.Text);
                                cmd.Parameters.AddWithValue("@messagemode", "Get Drug");
                                //cmd.Parameters.AddWithValue("@phone", phone);
                                da.Fill(ds);

                                int i; int counting = 0;
                                //Load Messages
                                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                    message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                    string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                    string date = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                    string name = ds.Tables[0].Rows[i].ItemArray[4].ToString();

                                    if (tblname == "360QP")
                                    {
                                        var html = "";
                                        html += "<tr>";
                                        html += "<td>";
                                        html += "<div class='form-check'>";
                                        html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-5.png' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        html += "<span class='check'>" + name + "</span>";
                                        html += "</div>";
                                        html += "</td>";
                                        html += "<td><strong><h5>" + message + "</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                        //html += "<td class='td-actions text-right'>";
                                        //html += "<span>" + time + "</span>";
                                        //html += "</td>";
                                        html += "</tr>";
                                        html += "<hr/>";


                                        //var html = "";
                                        //html += "<div class='message'>";
                                        //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-5.png' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        //html += "<div class='text-main'>";
                                        //html += "<div class='text-group>";
                                        //html += "<div class='text'>";
                                        //html += "<p><strong>" + message + "</strong><p>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<span>" + time + "</span>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<hr/>";

                                        PlaceHolderDrugChat.Controls.Add(new Literal { Text = html.ToString() });
                                    }
                                    else
                                    {
                                        var html = "";
                                        html += "<tr>";
                                        html += "<td>";
                                        html += "<div class='form-check'>";
                                        //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        html += "<span class='check'>" + name + "</span>";
                                        html += "</div>";
                                        html += "</td>";
                                        html += "<td><strong><h5>" + message + "</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                        //html += "<td class='td-actions text-right'>";
                                        //html += "<span>" + time + "</span>";
                                        //html += "</td>";
                                        html += "</tr>";
                                        html += "<hr/>";

                                        //var html = "";
                                        //html += "<div class='message'>";
                                        //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        //html += "<div class='text-main'>";
                                        //html += "<div class='text-group>";
                                        //html += "<div class='text'>";
                                        //html += "<p><strong>" + message + "</strong><p>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<span>" + time + "</span>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<hr/>";
                                        PlaceHolderDrugChat.Controls.Add(new Literal { Text = html.ToString() });
                                    }
                                }
                                counting++;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Index");
            }
        }

        private string PopulateBody(string headertext, string bodytext, string text) //string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("Email/announcement.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{HeaderText}", headertext);
            body = body.Replace("{BodyText}", bodytext);
            body = body.Replace("{Text}", text);
            //body = body.Replace("{Title}", title);
            //body = body.Replace("{Url}", url);
            //body = body.Replace("{Description}", description);
            return body;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.Text != "- Select Product Group -")
            {
                //LblMessages.Text += "Hello " + LblName.Text + ",";
                //LblCategory.Text = ddlCategory.Text;
                ////LblCategory.Visible = true;
                //txtMsgContent.Text = LblMessages.Text;
                //txtMsgContent.Visible = true;
                PanelDrug.BackColor = Color.LimeGreen;
                PanelProductGroup.BackColor = Color.White;
                
                using (con = new SqlConnection(conn))
                {
                    con.Open();//DESC - Sql ordering descending
                    //ddlCategory.Items.Clear();
                    using (cmd = new SqlCommand("Select count (distinct drug) from drugs where category=@category", con))
                    {
                        cmd.Parameters.AddWithValue("@category", ddlCategory.Text);
                        using (dr = cmd.ExecuteReader())
                        {
                            if (dr.Read() && !dr.IsDBNull(0))
                            {
                                int result = int.Parse(dr.GetValue(0).ToString());
                                if (result > 1)
                                {
                                    dr.Dispose();
                                    using (cmd = new SqlCommand("Select distinct drug from drugs where category=@category order by drug", con))
                                    {
                                        cmd.Parameters.AddWithValue("@category", ddlCategory.Text);
                                        using (dr = cmd.ExecuteReader())
                                        {
                                            ddlDrug.Items.Clear();
                                            ddlDrug.Items.Add("- Select Product -");
                                            while (dr.Read() && !dr.IsDBNull(0))
                                            {
                                                ddlDrug.Items.Add(dr.GetValue(0).ToString());
                                            }
                                        }
                                    }
                                }
                                else if (result == 1)
                                {
                                    dr.Dispose();
                                    using (cmd = new SqlCommand("Select distinct drug from drugs where category=@category order by drug", con))
                                    {
                                        cmd.Parameters.AddWithValue("@category", ddlCategory.Text);
                                        using (dr = cmd.ExecuteReader())
                                        {
                                            if (dr.Read() && !dr.IsDBNull(0))
                                            {
                                                ddlDrug.Items.Add("- Select Product -");
                                                ddlDrug.Items.Add(dr.GetValue(0).ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void ddlDrug_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.Text != "- Select Product Group -" && ddlDrug.Text != "- Select Product -")
            {
                if (LblMessage.Text != "")
                {
                    LblMessages.Text += ", " + ddlDrug.Text + "(" + ddlCategory.Text + ").";
                }
                else
                {
                    LblMessages.Text += ddlDrug.Text + "(" + ddlCategory.Text + ").";                    
                }
                //LblDrug.Text = ddlDrug.Text;
                ////LblDrug.Visible = true;
                //txtMsgContent.Text = LblMessages.Text;
                //txtMsgContent.Visible = true;
                txtQuantity.Visible = true;
                txtQuantity.Text = "";
                PanelDrug.BackColor = Color.White;
                PanelQty.BackColor = Color.LimeGreen;
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Please enter the quantity.";
            }
        }
        
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (BtnSubmit.Text == "Proceed ?")
            {
                PanelMessage.Visible = true;
                BtnMessage.Text = "Click Send or add more products.";
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Do you want to send your order now?";
                BtnSubmit.Text = "Send";
            }
            else if (BtnSubmit.Text == "Send")
            {
                if (txtQuantity.Text != "")
                {
                    if (ddlCategory.Text != "- Select Product Group -" && ddlDrug.Text != "- Select Product -")
                    {
                        LblMessages.Text = "Order Details: " + LblRunningMessages.Text + ". Your message has been sent, you will get a reply shortly.";
                        txtMsgContent.Text = LblMessages.Text;
                        txtMsgContent.Visible = true;

                        QuickPharm qp = new QuickPharm();
                        qp.name = LblName.Text;
                        qp.tblname = LblName.Text;
                        qp.phone = Lblusername.Text;
                        qp.message = LblMessages.Text;
                        qp.messagemode = "Get Drug";
                        qp.SaveChat();
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        //this.LblMessage.Text = qp.ResponseMsg;
                        //BtnYes.Text = "OK";
                        PanelMessage.Visible = true;
                        BtnMessage.Text = qp.ResponseMsg;

                        //Send Email
                        string headertextMail = "Drug Purchase Request";
                        //"<p>Thank you for registering on WinningLife International. <p><p>Your User ID is - <strong>" + txtUserID.Text + "</strong>. <p><p>Your Email Confirmation Code is - <strong>" + code + "</strong>. <p>To complete your registration kindly fund your wallet.</p> <p><p>-&nbsp; WinningLife International Team"; ;
                        string bodytextMail = "You have a drug purchase request from " + LblName.Text + ". Kindly attend to it asap.";
                        string bodyEnd = "360QuickPharm.";
                        string body = this.PopulateBody(headertextMail, bodytextMail, bodyEnd);
                        string plainbodytextMail = headertextMail + " " + bodytextMail + " " + bodyEnd;
                        string plainbody = this.PopulateBody(headertextMail, bodytextMail, bodyEnd);

                        //try
                        //{
                        var serverId = 26372;
                        var injectionApiKey = "Hf94Mns7L2XaZx85Gpo6";

                        var client = new SocketLabsClient(serverId, injectionApiKey);

                        var message = new BasicMessage();

                        message.Subject = "New Message Alert from 360QuickPharm Client!";
                        message.HtmlBody = body;
                        message.PlainTextBody = plainbody;
                        message.From.Email = "no-reply@360quickpharm.com";
                        qp.AdminGetEmail();
                        string getEmail = qp.ResponseMsg;
                        message.To.Add(getEmail);
                        //client.Send(message);
                        if (getEmail != "0")
                        {
                            var response = client.Send(message);
                        }

                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        //this.lblMessage.Text = "Email Sent!";

                        //}
                        //catch (Exception)
                        //{
                        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        //    this.lblMessage.Text = "Mail Sending Failed.";
                        //}
                    }
                    else
                    {
                        PanelMessage.Visible = true;
                        BtnMessage.Text = "Select a category and product.";
                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        //this.LblMessage.Text = "Select a product category and a product/drug.";
                        //BtnYes.Text = "OK";
                    }
                }
                else
                {
                    PanelMessage.Visible = true;
                    //PanelMessage.BackColor = Color.Blue;
                    BtnMessage.Text = "Please enter a quantity.";
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                    //this.LblMessage.Text = "Please enter a quantity.";
                    //BtnYes.Text = "OK";
                }
            }
        }

        protected void BtnYes_Click(object sender, EventArgs e)
        {
            if(BtnSubmit.Text == "Checking...")
            {
                BtnSubmit.Text = "Send";
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Please click on Send.";
                //BtnYes.Text = "OK";
                PanelMessage.Visible = true;
                BtnMessage.Text = "Please click on Send.";
            }
        }

        protected void SetColour()
        {
            PanelSubmit.BackColor = Color.LimeGreen;
            PanelDrug.BackColor = Color.White;
            PanelQty.BackColor = Color.White;
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            SetColour();
            LblMessages.Text = "(" + txtQuantity.Text + ")" + ddlDrug.Text;
            if(LblRunningMessages.Text != "")
            {
                LblRunningMessages.Text += ", "+ LblMessages.Text;
            }
            else
            {
                LblRunningMessages.Text = LblMessages.Text;
            }
            txtMsgContent.Text = LblRunningMessages.Text;
            txtMsgContent.Visible = true;
        }
    }
}