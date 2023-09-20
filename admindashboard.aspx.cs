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

namespace QuickPharm360
{
    public partial class admindashboard : System.Web.UI.Page
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

                        QuickPharm qp = new QuickPharm();
                        qp.LoadAdminDashboard();
                        LblRunningChats.Text = qp.runningchats;
                        LblClosedChats.Text = qp.closedchats;
                        LblAllUsers.Text = qp.allusers;
                        LblClosedSales.Text = qp.closedsales;
                        LblUnattendedChats.Text = qp.unattendedchats;

                        using (con = new SqlConnection(conn))
                        {
                            con.Open();//DESC - Sql ordering descending
                            using (da = new SqlDataAdapter())
                            {
                                //dr.Dispose();
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,phone,date,name from chats where status=@status and beinghandled=@beinghandled ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@beinghandled", "0");
                                    //cmd.Parameters.AddWithValue("@phone", phone);
                                    da.Fill(ds);

                                    int i; int counting = 0;
                                    //Load Messages
                                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                    {
                                        string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                        message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                        string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                        string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                        string date = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                                        string name = ds.Tables[0].Rows[i].ItemArray[5].ToString();

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
                                            html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
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

                                            PlaceHolderChatResponse.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                        else
                                        {
                                            var html = "";
                                            html += "<tr>";
                                            html += "<td>";
                                            html += "<div class='form-check'>";
                                            html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            html += "<span class='check'>" + name + "</span>";
                                            html += "</div>";
                                            html += "</td>";
                                            html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                            html += "</tr>";
                                            html += "<hr/>";
                                            //var html = "";
                                            //html += "<div class='message'>";
                                            //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            //html += "<div class='text-main'>";
                                            //html += "<div class='text-group>";
                                            //html += "<div class='text'>";
                                            //html += "<p>" + message + "<p>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<span>" + time + "</span>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<hr/>";
                                            PlaceHolderChatResponse.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                    }
                                    counting++;
                                }
                            }
                            //Ongoing Chats
                            using (da = new SqlDataAdapter())
                            {
                                //dr.Dispose();
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,phone,date,name from chats where status=@status and beinghandled=@beinghandled ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                                    //cmd.Parameters.AddWithValue("@phone", phone);
                                    da.Fill(ds);

                                    int i; int counting = 0;
                                    //Load Messages
                                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                    {
                                        string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                        message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                        string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                        string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                        string date = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                                        string name = ds.Tables[0].Rows[i].ItemArray[5].ToString();

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
                                            html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
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

                                            PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                        else
                                        {
                                            var html = "";
                                            html += "<tr>";
                                            html += "<td>";
                                            html += "<div class='form-check'>";
                                            html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            html += "<span class='check'>" + name + "</span>";
                                            html += "</div>";
                                            html += "</td>";
                                            html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                            html += "</tr>";
                                            html += "<hr/>";
                                            //var html = "";
                                            //html += "<div class='message'>";
                                            //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                            //html += "<div class='text-main'>";
                                            //html += "<div class='text-group>";
                                            //html += "<div class='text'>";
                                            //html += "<p>" + message + "<p>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<span>" + time + "</span>";
                                            //html += "</div>";
                                            //html += "</div>";
                                            //html += "<hr/>";
                                            PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                    }
                                    counting++;
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("adminlogin");
                    }
                }
                else
                {
                    Lblusername.Text = Session["username"].ToString();

                    QuickPharm qp = new QuickPharm();
                    qp.LoadAdminDashboard();
                    LblRunningChats.Text = qp.runningchats;
                    LblClosedChats.Text = qp.closedchats;
                    LblAllUsers.Text = qp.allusers;
                    LblClosedSales.Text = qp.closedsales;
                    LblUnattendedChats.Text = qp.unattendedchats;

                    using (con = new SqlConnection(conn))
                    {
                        con.Open();//DESC - Sql ordering descending
                        using (da = new SqlDataAdapter())
                        {
                            //dr.Dispose();
                            DataSet ds = new DataSet();
                            string sql = null;
                            sql = "Select tblname,message,time,phone,date,name from chats where status=@status and beinghandled=@beinghandled ORDER BY [SN] ASC";
                            //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                            using (cmd = new SqlCommand(sql, con))
                            {
                                da.SelectCommand = cmd;
                                cmd.Parameters.AddWithValue("@status", "On");
                                cmd.Parameters.AddWithValue("@beinghandled", "0");
                                //cmd.Parameters.AddWithValue("@phone", phone);
                                da.Fill(ds);

                                int i; int counting = 0;
                                //Load Messages
                                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                    message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                    string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                    string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                    string date = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                                    string name = ds.Tables[0].Rows[i].ItemArray[56].ToString();

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
                                        html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
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

                                        PlaceHolderChatResponse.Controls.Add(new Literal { Text = html.ToString() });
                                    }
                                    else
                                    {
                                        var html = "";
                                        html += "<tr>";
                                        html += "<td>";
                                        html += "<div class='form-check'>";
                                        html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        html += "<span class='check'>" + name + "</span>";
                                        html += "</div>";
                                        html += "</td>";
                                        html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                        html += "</tr>";
                                        html += "<hr/>";

                                        //var html = "";
                                        //html += "<div class='message'>";
                                        //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        //html += "<div class='text-main'>";
                                        //html += "<div class='text-group>";
                                        //html += "<div class='text'>";
                                        //html += "<p>" + message + "<p>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<span>" + time + "</span>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<hr/>";
                                        PlaceHolderChatResponse.Controls.Add(new Literal { Text = html.ToString() });
                                    }
                                }
                                counting++;
                            }
                        }
                        //Ongoing Chats
                        using (da = new SqlDataAdapter())
                        {
                            //dr.Dispose();
                            DataSet ds = new DataSet();
                            string sql = null;
                            sql = "Select tblname,message,time,phone,date,name from chats where status=@status and beinghandled=@beinghandled ORDER BY [SN] ASC";
                            //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                            using (cmd = new SqlCommand(sql, con))
                            {
                                da.SelectCommand = cmd;
                                cmd.Parameters.AddWithValue("@status", "On");
                                cmd.Parameters.AddWithValue("@beinghandled", "1");
                                //cmd.Parameters.AddWithValue("@phone", phone);
                                da.Fill(ds);

                                int i; int counting = 0;
                                //Load Messages
                                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                {
                                    string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                    message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                    string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                    string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                    string date = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                                    string name = ds.Tables[0].Rows[i].ItemArray[5].ToString();

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
                                        html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
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

                                        PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
                                    }
                                    else
                                    {
                                        var html = "";
                                        html += "<tr>";
                                        html += "<td>";
                                        html += "<div class='form-check'>";
                                        html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        html += "<span class='check'>" + name + "</span>";
                                        html += "</div>";
                                        html += "</td>";
                                        html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                        html += "</tr>";
                                        html += "<hr/>";

                                        //var html = "";
                                        //html += "<div class='message'>";
                                        //html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
                                        //html += "<div class='text-main'>";
                                        //html += "<div class='text-group>";
                                        //html += "<div class='text'>";
                                        //html += "<p>" + message + "<p>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<span>" + time + "</span>";
                                        //html += "</div>";
                                        //html += "</div>";
                                        //html += "<hr/>";
                                        PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
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
                Response.Redirect("adminlogin");
            }
        }
    }
}