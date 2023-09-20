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
    public partial class adminch : System.Web.UI.Page
    {
        private string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private SqlDataAdapter da;
        private SqlDataAdapter daa;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlCommand cmdd;
        private SqlDataReader dr;
        public DataTable dt;
        public string message;
        public string messagemode;
        public string maxSN;
        public string phonechecker;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LblUsername.Text = Session["username"].ToString();

                //PlaceHolderChatList.Controls.Clear();
                //using (con = new SqlConnection(conn))
                //{
                //    con.Open();//DESC - Sql ordering descending

                //    //dr.Dispose();
                //    using (daa = new SqlDataAdapter())
                //    {
                //        DataSet dss = new DataSet();
                //        string sqll = null;
                //        sqll = "Select DISTINCT phone from chats where status=@status";
                //        //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                //        using (cmd = new SqlCommand(sqll, con))
                //        {
                //            daa.SelectCommand = cmd;
                //            cmd.Parameters.AddWithValue("@status", "On");
                //            //cmd.Parameters.AddWithValue("@beinghandled", "0");
                //            //cmd.Parameters.AddWithValue("@phone", phone);
                //            //using (dr = cmd.ExecuteReader())
                //            //{
                //            daa.Fill(dss);
                //                int ii; int countingg = 0;
                //                //Load Messages
                //                //while (dr.Read())
                //                for (ii = 0; ii <= dss.Tables[0].Rows.Count - 1; ii++)
                //                {
                //                    //phonechecker = dr.GetValue(0).ToString();
                //                    phonechecker = dss.Tables[0].Rows[ii].ItemArray[0].ToString();
                //                    using (cmd = new SqlCommand("Select Max(SN) from Chats where phone = @phone", con))
                //                    {
                //                        cmd.Parameters.AddWithValue("@phone", phonechecker);
                //                        using (dr = cmd.ExecuteReader())
                //                        {
                //                            if (dr.Read())
                //                            {
                //                                maxSN = dr.GetValue(0).ToString();
                //                            }
                //                        }
                //                    }
                //                    using (da = new SqlDataAdapter())
                //                    {
                //                        DataSet ds = new DataSet();
                //                        string sql = null;
                //                        sql = "Select tblname,message,time,phone,date,name from chats where status=@status and phone=@phone and sn=@maxsn ORDER BY [SN] ASC";
                //                        //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                //                        using (cmd = new SqlCommand(sql, con))
                //                        {
                //                            da.SelectCommand = cmd;
                //                            cmd.Parameters.AddWithValue("@status", "On");
                //                            cmd.Parameters.AddWithValue("@phone", phonechecker);
                //                            cmd.Parameters.AddWithValue("@maxsn", maxSN);
                //                            //cmd.Parameters.AddWithValue("@beinghandled", "0");
                //                            //cmd.Parameters.AddWithValue("@phone", phone);
                //                            da.Fill(ds);

                //                            int i; int counting = 0;
                //                            //Load Messages
                //                            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                //                            {
                //                                string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                //                                message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //                                string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                //                                string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                //                                string date = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                //                                string name = ds.Tables[0].Rows[i].ItemArray[5].ToString();

                //                                var html = "";
                //                                html += "<a href='#' class='filterDiscussions all unread single active' id='list-chat-list' data-toggle='list' role='tab'>";
                //                                html += "<div class='data'>";
                //                                html += "<h5>" + name + "</h5>";
                //                                html += "<span>" + date + "</span>";
                //                                html += "<p>" + message + "</p>";
                //                                html += "</div>";
                //                                html += "</a>";
                //                                html += "<asp:Button ID='BtnView" + phone + "' CssClass='btn-success' runat='server' Text='View " + name + "' OnClientClick='SetSource(this.id)'></asp:Button>";

                //                                PlaceHolderChatList.Controls.Add(new Literal { Text = html.ToString() });

                //                            }
                //                            counting++;
                //                        }
                //                    }
                //                }
                //            //}
                //        }
                //    }
                //}
            }
            else
            {
                string CtrlID = string.Empty;

                if (Request.Form[hidSourceID.UniqueID] != null && Request.Form[hidSourceID.UniqueID] != string.Empty)
                {
                    CtrlID = Request.Form[hidSourceID.UniqueID];

                    string phoneNO = CtrlID.Replace("BtnView", "");
                    string nameSELECT = "";
                    //Load Data
                    PlaceHolderChat.Controls.Clear();
                    using (con = new SqlConnection(conn))
                    {
                        con.Open();//DESC - Sql ordering descending
                        using(cmd = new SqlCommand("Select name from login where phone=@phone", con))
                        {
                            cmd.Parameters.AddWithValue("@phone", phoneNO);
                            using(dr = cmd.ExecuteReader())
                            {
                                if(dr.Read() && !dr.IsDBNull(0))
                                {
                                    nameSELECT = dr.GetValue(0).ToString();
                                    LblSelectName.Text = nameSELECT;
                                }
                            }
                        }


                        using (da = new SqlDataAdapter())
                        {
                            DataSet ds = new DataSet();
                            string sql = null;
                            sql = "Select tblname,message,time,phone,date,name from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                            //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                            using (cmd = new SqlCommand(sql, con))
                            {
                                da.SelectCommand = cmd;
                                cmd.Parameters.AddWithValue("@status", "On");
                                cmd.Parameters.AddWithValue("@phone", phoneNO);
                                //cmd.Parameters.AddWithValue("@beinghandled", "0");
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
                                        html += "<div class='message me'>";
                                        html += "<div class='text-main'>";
                                        html += "<div class='text-group me'>";
                                        html += "<div class='text me'>";
                                        html += "<p>"+message+"</p><p>("+phone+")</p>";
                                        html += "</div>";
                                        html += "</div>";
                                        html += "<span>"+date+" - "+time+"</span>";
                                        html += "</div>";
                                        html += "</div>";
                                        //var html = "";
                                        //html += "<a href='#' class='filterDiscussions all unread single active' id='list-chat-list' data-toggle='list' role='tab'>";
                                        //html += "<div class='data'>";
                                        //html += "<h5>" + name + "</h5>";
                                        //html += "<span>" + date + "</span>";
                                        //html += "<p>" + message + "</p>";
                                        //html += "</div>";
                                        //html += "</a>";
                                        //html += "<asp:Button ID='BtnView" + phone + "' CssClass='btn-success' runat='server' Text='View " + name + "' OnClientClick='SetSource(this.id)'></asp:Button>";

                                        PlaceHolderChat.Controls.Add(new Literal { Text = html.ToString() });
                                    }
                                    else
                                    {
                                        var html = "";
                                        html += "<div class='message'>";
                                        html += "<div class='text-main'>";
                                        html += "<div class='text-group'>";
                                        html += "<div class='text'>";
                                        html += "<p>" + message + "</p><p>(" + phone + ")</p>";
                                        html += "</div>";
                                        html += "</div>";
                                        html += "<span>" + date + " - " + time + "</span>";
                                        html += "</div>";
                                        html += "</div>";

                                        PlaceHolderChat.Controls.Add(new Literal { Text = html.ToString() });
                                    }

                                }
                                counting++;
                            }
                        }
                    }
                }
            }
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            //BtnView07055995767.id
        }

        protected void BtnLoadAll_Click(object sender, EventArgs e)
        {
            PlaceHolderChatList.Controls.Clear();
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending

                //dr.Dispose();
                using (daa = new SqlDataAdapter())
                {
                    DataSet dss = new DataSet();
                    string sqll = null;
                    sqll = "Select DISTINCT phone from chats where status=@status ORDER BY [SN] ASC";
                    //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                    using (cmd = new SqlCommand(sqll, con))
                    {
                        daa.SelectCommand = cmd;
                        cmd.Parameters.AddWithValue("@status", "On");
                        //cmd.Parameters.AddWithValue("@beinghandled", "0");
                        //cmd.Parameters.AddWithValue("@phone", phone);
                        daa.Fill(dss);

                        int ii; int countingg = 0;
                        //Load Messages
                        for (ii = 0; ii <= dss.Tables[0].Rows.Count - 1; ii++)
                        {
                            phonechecker = dss.Tables[0].Rows[ii].ItemArray[0].ToString();
                            using(cmd = new SqlCommand("Select Max(SN) from Chats where phone = @phone", con))
                            {
                                cmd.Parameters.AddWithValue("@phone", phonechecker);
                                using(dr = cmd.ExecuteReader())
                                {
                                    if(dr.Read())
                                    {
                                        maxSN = dr.GetValue(0).ToString();
                                    }
                                }
                            }
                            using (da = new SqlDataAdapter())
                            {
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,phone,date,name from chats where status=@status and phone=@phone and sn=@maxsn ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@phone", phonechecker);
                                    cmd.Parameters.AddWithValue("@maxsn", maxSN);
                                    //cmd.Parameters.AddWithValue("@beinghandled", "0");
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
                                        
                                        var html = "";
                                        html += "<a href='#' class='filterDiscussions all unread single active' id='list-chat-list' data-toggle='list' role='tab'>";
                                        html += "<div class='data'>";
                                        html += "<h5>" + name + "</h5>";
                                        html += "<span>" + date + "</span>";
                                        html += "<p>" + message + "</p>";
                                        html += "</div>";
                                        html += "</a>";
                                        html += "<asp:Button ID='BtnView" + phone + "' CssClass='btn-success' runat='server' Text='View " + name + "' OnClientClick='SetSource(this.id)'></asp:Button>";

                                        PlaceHolderChatList.Controls.Add(new Literal { Text = html.ToString() });                                                                                   
                                         
                                    }
                                    counting++;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void BtnLoadNew_Click(object sender, EventArgs e)
        {
            PlaceHolderChatList.Controls.Clear();
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending

                //dr.Dispose();
                using (daa = new SqlDataAdapter())
                {
                    DataSet dss = new DataSet();
                    string sqll = null;
                    sqll = "Select DISTINCT phone from chats where status=@status ORDER BY [SN] ASC";
                    //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                    using (cmd = new SqlCommand(sqll, con))
                    {
                        daa.SelectCommand = cmd;
                        cmd.Parameters.AddWithValue("@status", "On");
                        //cmd.Parameters.AddWithValue("@beinghandled", "0");
                        //cmd.Parameters.AddWithValue("@phone", phone);
                        daa.Fill(dss);

                        int ii; int countingg = 0;
                        //Load Messages
                        for (ii = 0; ii <= dss.Tables[0].Rows.Count - 1; ii++)
                        {
                            phonechecker = dss.Tables[0].Rows[ii].ItemArray[0].ToString();
                            using (cmd = new SqlCommand("Select Max(SN) from Chats where phone = @phone", con))
                            {
                                cmd.Parameters.AddWithValue("@phone", phonechecker);
                                using (dr = cmd.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        maxSN = dr.GetValue(0).ToString();
                                    }
                                }
                            }
                            using (da = new SqlDataAdapter())
                            {
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,phone,date,name from chats where status=@status and phone=@phone and sn=@maxsn and beinghandled=@beinghandled ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@phone", phonechecker);
                                    cmd.Parameters.AddWithValue("@maxsn", maxSN);
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

                                        var html = "";
                                        html += "<a href='#' class='filterDiscussions all unread single active' id='list-chat-list' data-toggle='list' role='tab'>";
                                        html += "<div class='data'>";
                                        html += "<h5>" + name + "</h5>";
                                        html += "<span>" + date + "</span>";
                                        html += "<p>" + message + "</p>";
                                        html += "</div>";
                                        html += "</a>";
                                        html += "<asp:Button ID='BtnView" + phone + "' CssClass='btn-success' runat='server' Text='View " + name + "' OnClientClick='SetSource(this.id)'></asp:Button>";

                                        PlaceHolderChatList.Controls.Add(new Literal { Text = html.ToString() });

                                    }
                                    counting++;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void BtnLoadOngoing_Click(object sender, EventArgs e)
        {
            PlaceHolderChatList.Controls.Clear();
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending

                //dr.Dispose();
                using (daa = new SqlDataAdapter())
                {
                    DataSet dss = new DataSet();
                    string sqll = null;
                    sqll = "Select DISTINCT phone from chats where status=@status ORDER BY [SN] ASC";
                    //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                    using (cmd = new SqlCommand(sqll, con))
                    {
                        daa.SelectCommand = cmd;
                        cmd.Parameters.AddWithValue("@status", "On");
                        //cmd.Parameters.AddWithValue("@beinghandled", "0");
                        //cmd.Parameters.AddWithValue("@phone", phone);
                        daa.Fill(dss);

                        int ii; int countingg = 0;
                        //Load Messages
                        for (ii = 0; ii <= dss.Tables[0].Rows.Count - 1; ii++)
                        {
                            phonechecker = dss.Tables[0].Rows[ii].ItemArray[0].ToString();
                            using (cmd = new SqlCommand("Select Max(SN) from Chats where phone = @phone", con))
                            {
                                cmd.Parameters.AddWithValue("@phone", phonechecker);
                                using (dr = cmd.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        maxSN = dr.GetValue(0).ToString();
                                    }
                                }
                            }
                            using (da = new SqlDataAdapter())
                            {
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,phone,date,name from chats where status=@status and phone=@phone and sn=@maxsn and beinghandled=@beinghandled ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@phone", phonechecker);
                                    cmd.Parameters.AddWithValue("@maxsn", maxSN);
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

                                        var html = "";
                                        html += "<a href='#' class='filterDiscussions all unread single active' id='list-chat-list' data-toggle='list' role='tab'>";
                                        html += "<div class='data'>";
                                        html += "<h5>" + name + "</h5>";
                                        html += "<span>" + date + "</span>";
                                        html += "<p>" + message + "</p>";
                                        html += "</div>";
                                        html += "</a>";
                                        html += "<asp:Button ID='BtnView" + phone + "' CssClass='btn-success' runat='server' Text='View " + name + "' OnClientClick='SetSource(this.id)'></asp:Button>";

                                        PlaceHolderChatList.Controls.Add(new Literal { Text = html.ToString() });

                                    }
                                    counting++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}