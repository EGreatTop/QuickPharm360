using QuickPharm360.Model;
using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickPharm360
{
    public partial class getadvise : System.Web.UI.Page
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

                            //Ongoing Chats
                            PlaceHolderAdviseChat.Controls.Clear();
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
                                    cmd.Parameters.AddWithValue("@messagemode", "Get Advise");
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

                                            PlaceHolderAdviseChat.Controls.Add(new Literal { Text = html.ToString() });
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
                                            PlaceHolderAdviseChat.Controls.Add(new Literal { Text = html.ToString() });
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
                    PlaceHolderAdviseChat.Controls.Clear();
                    using (con = new SqlConnection(conn))
                    {
                        con.Open();//DESC - Sql ordering descending

                        //Ongoing Chats
                        using (da = new SqlDataAdapter())
                        {
                            //dr.Dispose();
                            DataSet ds = new DataSet();
                            string sql = null;
                            sql = "Select tblname,message,time,date,time,name from chats where status=@status and phone=@phone and messagemode=@messagemode ORDER BY [SN] ASC";
                            //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                            using (cmd = new SqlCommand(sql, con))
                            {
                                da.SelectCommand = cmd;
                                cmd.Parameters.AddWithValue("@status", "On");
                                cmd.Parameters.AddWithValue("@phone", Lblusername.Text);
                                cmd.Parameters.AddWithValue("@messagemode", "Get Advise");
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

                                        PlaceHolderAdviseChat.Controls.Add(new Literal { Text = html.ToString() });
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
                                        PlaceHolderAdviseChat.Controls.Add(new Literal { Text = html.ToString() });
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
                Response.Redirect("index");
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

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.name = LblName.Text;
                qp.tblname = LblName.Text;
                qp.phone = Lblusername.Text;
                qp.message = txtMessage.Text;
                qp.messagemode = "Get Advise";
                qp.SaveChat();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = qp.ResponseMsg;
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;

                //Send Email
                string headertextMail = "Consultation Request";
                //"<p>Thank you for registering on WinningLife International. <p><p>Your User ID is - <strong>" + txtUserID.Text + "</strong>. <p><p>Your Email Confirmation Code is - <strong>" + code + "</strong>. <p>To complete your registration kindly fund your wallet.</p> <p><p>-&nbsp; WinningLife International Team"; ;
                string bodytextMail = "You have a consultation request from " + LblName.Text + ". Kindly attend to it asap.";
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
                LblAdminEmail.Text = getEmail;
                message.To.Add(getEmail);
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
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s).";
                //BtnYes.Visible = false;
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s).";
            }
        }

        protected void BtnSendWhatsApp_Click(object sender, EventArgs e)
        {
            //Send Email
            string headertextMail = "Image Consultation Info";
            //"<p>Thank you for registering on WinningLife International. <p><p>Your User ID is - <strong>" + txtUserID.Text + "</strong>. <p><p>Your Email Confirmation Code is - <strong>" + code + "</strong>. <p>To complete your registration kindly fund your wallet.</p> <p><p>-&nbsp; WinningLife International Team"; ;
            string bodytextMail = "You have an Image Sent from " + LblName.Text + ". Kindly attend to it asap.";
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

            message.Subject = "New Image Alert from 360QuickPharm Client!";
            message.HtmlBody = body;
            message.PlainTextBody = plainbody;
            message.From.Email = "no-reply@360quickpharm.com";
            string getEmail = LblAdminEmail.Text;
            message.To.Add(getEmail);
            if (getEmail != "0")
            {
                var response = client.Send(message);
            }

            Response.Redirect("https://api.whatsapp.com/send?phone=2348034980104&text=Hello,%20My%20name%20is%20John,%20I%20just%20sent%20a%20message.%20Kindly%20find%20the%20picture%20below.");
        }
    }
}