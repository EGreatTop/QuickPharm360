using QuickPharm360.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickPharm360
{
    public partial class clientdashboard : System.Web.UI.Page
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
                    Lblusername.Text = Session["username"].ToString();
                    LblName.Text = Session["name"].ToString();


                    using (con = new SqlConnection(conn))
                    {
                        con.Open();//DESC - Sql ordering descending

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

                        //Advise
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

                    PlaceHolderDrugChat.Controls.Clear();
                    using (con = new SqlConnection(conn))
                    {
                        con.Open();//DESC - Sql ordering descending

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

                        //Advise
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
            }
            catch (Exception)
            {
                Response.Redirect("Index");
            }
        }

        protected void BtnSubmitDrug_Click(object sender, EventArgs e)
        {
            Response.Redirect("getdrug");
        }

        protected void BtnChat_Click(object sender, EventArgs e)
        {
            Response.Redirect("getadvise");
        }

        protected void BtnClearChats_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            //this.LblMessage.Text = "Clear chat history?";
            //BtnYes.Visible = true;
            //BtnYes.Enabled = false;
            QuickPharm qp = new QuickPharm();
            qp.phone = Lblusername.Text;
            qp.ClearChats();
            PanelMessage.Visible = true;
            BtnMessage.Text = qp.ResponseMsg;
            Response.Redirect("clientdashboard");
        }

        protected void BtnYes_Click(object sender, EventArgs e)
        {
            //BtnYes.Enabled = false;
            //QuickPharm qp = new QuickPharm();
            //qp.phone = Lblusername.Text;
            //qp.ClearChats();
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            //this.LblMessage.Text = qp.ResponseMsg;
            //BtnYes.Visible = true;
            //PanelMessage.Visible = true;
            //BtnMessage.Text = qp.ResponseMsg;
        }
    }
}