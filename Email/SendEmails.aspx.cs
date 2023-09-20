using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConnectMagnetNew.Office.Email
{
    public partial class SendEmails : System.Web.UI.Page
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        int counter;
        private string conn = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (con = new SqlConnection(conn))
                {
                    con.Open();
                    using (cmd = new SqlCommand("Select COUNT(email) from emailsafe", con))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                if (!dr.IsDBNull(0))
                                {
                                    txtTotEmails.Text = dr.GetValue(0).ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        private string PopulateBody(string headertext, string bodytext) //string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/Office/Email/announcement.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{HeaderText}", headertext);
            body = body.Replace("{BodyText}", bodytext);
            //body = body.Replace("{Title}", title);
            //body = body.Replace("{Url}", url);
            //body = body.Replace("{Description}", description);
            return body;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            //Send Email
            //create the mail message
            MailMessage mail = new MailMessage();
            //set the FROM address
            mail.From = new MailAddress(txtSender.Text);
            //set the RECIPIENTS
            mail.To.Add(recepientEmail);
            //enter a SUBJECT
            mail.Subject = subject;
            //Enter the message BODY
            mail.Body = body;
            //Set to HTML true
            mail.IsBodyHtml = true;
            //set the mail server (default should be smtp.1and1.com)
            SmtpClient smtp = new SmtpClient("smtp.1and1.com");
            //Enter your full e-mail address and password
	//Test Credentials
            smtp.Credentials = new NetworkCredential("no-reply@quickpharm360.com", "AdamawaJalingo2017!");
            //send the message 
            smtp.Send(mail);
        }

        protected void BtnSendEmails_Click(object sender, EventArgs e)
        {
            try
            {
                using (con = new SqlConnection(conn))
                {
                    con.Open();
                    int MinSN = int.Parse(txtStartEmailNo.Text);
                    int MaxSN = int.Parse(txtEndEmailNo.Text);
                    for (int i = MinSN; i <= MaxSN; i++)
                    {
                        using (cmd = new SqlCommand("Select Email from EmailSafe where SN=@SN", con))
                        {
                            cmd.Parameters.AddWithValue("@SN", i);
                            using (dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    string getEmail = dr.GetValue(0).ToString();
                                    string headertextMail = txtHeaderText.Text;
                                    string bodytextMail = txtBodyText.Text;
                                    string body = this.PopulateBody(headertextMail, bodytextMail);
                                    this.SendHtmlFormattedEmail("" + getEmail + "", txtEmailTitle.Text, body);
                                    counter++;
                                }
                            }
                        }
                    }
                    Response.Write("<script>alert('" + counter + " messages sent.')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}