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
    public partial class ongoingchat : System.Web.UI.Page
    {
        private string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private SqlDataAdapter da;
        private SqlDataAdapter daa;
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        public DataTable dt;
        public string message;
        public string messagemode;
        public int minSN;
        public string phonechecker;
        public int maxSN;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["denyurl"].ToString() == "gYUg73637&?&!__Ggbjkbn*^7564G")
                    {
                        Lblusername.Text = Session["username"].ToString();

                        using(con = new SqlConnection(conn))
                        {
                            con.Open();

                            using (daa = new SqlDataAdapter())
                            {
                                DataSet dss = new DataSet();
                                string sqll = null;
                                sqll = "Select DISTINCT phone from chats where status=@status and beinghandled=@beinghandled and messagemode=@messagemode";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sqll, con))
                                {
                                    daa.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                                    cmd.Parameters.AddWithValue("@messagemode", "Get Drug");
                                    //using (dr = cmd.ExecuteReader())
                                    //{
                                    daa.Fill(dss);
                                    int ii; int countingg = 0;
                                    //Load Messages
                                    //while (dr.Read())
                                    for (ii = 0; ii <= dss.Tables[0].Rows.Count - 1; ii++)
                                    {
                                        //phonechecker = dr.GetValue(0).ToString();
                                        phonechecker = dss.Tables[0].Rows[ii].ItemArray[0].ToString();
                                        using (cmd = new SqlCommand("Select Max(SN) from Chats where phone = @phone and tblname!=@tblname and status=@status and beinghandled=@beinghandled and messagemode=@messagemode", con))
                                        {
                                            cmd.Parameters.AddWithValue("@phone", phonechecker);
                                            cmd.Parameters.AddWithValue("@tblname", "360QP"); 
                                            cmd.Parameters.AddWithValue("@status", "On");
                                            cmd.Parameters.AddWithValue("@beinghandled", "1");
                                            cmd.Parameters.AddWithValue("@messagemode", "Get Drug");
                                            using (dr = cmd.ExecuteReader())
                                            {
                                                if (dr.Read())
                                                {
                                                    maxSN = int.Parse(dr.GetValue(0).ToString());
                                                }
                                            }
                                        }
                                        using (da = new SqlDataAdapter())
                                        {
                                            DataSet ds = new DataSet();
                                            string sql = null;
                                            sql = "Select name from chats where status=@status and phone=@phone and beinghandled=@beinghandled and tblname!=@tblname and messagemode=@messagemode and sn=@maxsn ORDER BY [SN] ASC";
                                            //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                            using (cmd = new SqlCommand(sql, con))
                                            {
                                                da.SelectCommand = cmd;
                                                cmd.Parameters.AddWithValue("@status", "On");
                                                cmd.Parameters.AddWithValue("@phone", phonechecker);
                                                cmd.Parameters.AddWithValue("@maxsn", maxSN);
                                                cmd.Parameters.AddWithValue("@beinghandled", "1");
                                                cmd.Parameters.AddWithValue("@tblname", "360QP");
                                                cmd.Parameters.AddWithValue("@messagemode", "Get Drug");
                                                da.Fill(ds);

                                                int i; int counting = 0;
                                                //Load Messages
                                                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                                {
                                                    string name = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                                    ddlNames.Items.Add(name);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            /////////////////////////////////////////////////////////////////////////
                            using (daa = new SqlDataAdapter())
                            {
                                DataSet dss = new DataSet();
                                string sqll = null;
                                sqll = "Select DISTINCT phone from chats where status=@status and beinghandled=@beinghandled and messagemode=@messagemode";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sqll, con))
                                {
                                    daa.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                                    cmd.Parameters.AddWithValue("@messagemode", "Get Advise");
                                    //using (dr = cmd.ExecuteReader())
                                    //{
                                    daa.Fill(dss);
                                    int ii; int countingg = 0;
                                    //Load Messages
                                    //while (dr.Read())
                                    for (ii = 0; ii <= dss.Tables[0].Rows.Count - 1; ii++)
                                    {
                                        //phonechecker = dr.GetValue(0).ToString();
                                        phonechecker = dss.Tables[0].Rows[ii].ItemArray[0].ToString();
                                        using (cmd = new SqlCommand("Select Max(SN) from Chats where phone = @phone and tblname!=@tblname and status=@status and beinghandled=@beinghandled and messagemode=@messagemode", con))
                                        {
                                            cmd.Parameters.AddWithValue("@phone", phonechecker);
                                            cmd.Parameters.AddWithValue("@tblname", "360QP");
                                            cmd.Parameters.AddWithValue("@status", "On");
                                            cmd.Parameters.AddWithValue("@beinghandled", "1");
                                            cmd.Parameters.AddWithValue("@messagemode", "Get Advise");
                                            using (dr = cmd.ExecuteReader())
                                            {
                                                if (dr.Read())
                                                {
                                                    maxSN = int.Parse(dr.GetValue(0).ToString());
                                                }
                                            }
                                        }
                                        using (da = new SqlDataAdapter())
                                        {
                                            DataSet ds = new DataSet();
                                            string sql = null;
                                            sql = "Select name from chats where status=@status and phone=@phone and beinghandled=@beinghandled and tblname!=@tblname and messagemode=@messagemode and sn=@maxsn ORDER BY [SN] ASC";
                                            //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                            using (cmd = new SqlCommand(sql, con))
                                            {
                                                da.SelectCommand = cmd;
                                                cmd.Parameters.AddWithValue("@status", "On");
                                                cmd.Parameters.AddWithValue("@phone", phonechecker);
                                                cmd.Parameters.AddWithValue("@maxsn", maxSN);
                                                cmd.Parameters.AddWithValue("@beinghandled", "1");
                                                cmd.Parameters.AddWithValue("@tblname", "360QP");
                                                cmd.Parameters.AddWithValue("@messagemode", "Get Advise");
                                                da.Fill(ds);

                                                int i; int counting = 0;
                                                //Load Messages
                                                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                                {
                                                    string name = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                                    ddlConsultationName.Items.Add(name);
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
                else
                {
                 
                }
            }
            catch (Exception)
            {
                Response.Redirect("adminlogin");
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.username = Lblusername.Text;
                qp.message = txtMessage.Text;
                qp.phone = LblPhone.Text;
                qp.messagemode = LblMessageMode.Text;
                qp.SaveChatAdmin();
                qp.phone = LblPhone.Text;
                qp.SetToBeingHandled();
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else
            {
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)";
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                //this.LblMessage.Text = "Empty field(s)";
                //BtnYes.Visible = false;
            }
        }

        protected void BtnCloseEnq_Click(object sender, EventArgs e)
        {
            PanelMessage.Visible = false;
            BtnMessage.Text = "";
            if (LblPhone.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.phone = LblPhone.Text;
                qp.CloseEnquiry();
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else
            {
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s)";
            }
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {
            PanelMessage.Visible = false;
            BtnMessage.Text = "";
            if (LblPhone.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.phone = LblPhone.Text;
                qp.message = txtMessage.Text;
                qp.CloseSale();
                PanelMessage.Visible = true;
                BtnMessage.Text = qp.ResponseMsg;
            }
            else
            {
                PanelMessage.Visible = true;
                BtnMessage.Text = "Empty field(s).";
            }
        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            //PlaceHolderChatOngoing.Controls.Clear();
            //using (con = new SqlConnection(conn))
            //{
            //    con.Open();//DESC - Sql ordering descending
            //    using (cmd = new SqlCommand("Select Min(SN) from chats where status=@status and beinghandled=@beinghandled and name=@name", con))
            //    {
            //        cmd.Parameters.AddWithValue("@status", "On");
            //        cmd.Parameters.AddWithValue("@beinghandled", "1");
            //        cmd.Parameters.AddWithValue("@name", ddlNames.Text);
            //        using (dr = cmd.ExecuteReader())
            //        {
            //            if (dr.Read() && !dr.IsDBNull(0))
            //            {
            //                minSN = int.Parse(dr.GetValue(0).ToString());

            //                dr.Dispose();
            //                using(cmd = new SqlCommand("Select phone from chats where sn=@sn", con))
            //                {
            //                    cmd.Parameters.AddWithValue("@sn", minSN);
            //                    using(dr = cmd.ExecuteReader())
            //                    {
            //                        if(dr.Read())
            //                        {
            //                            LblPhoneTrace.Text = dr.GetValue(0).ToString();
            //                        }
            //                    }
            //                }
            //                //continue processing
            //                using (da = new SqlDataAdapter())
            //                {
            //                    dr.Dispose();
            //                    DataSet ds = new DataSet();
            //                    string sql = null;
            //                    sql = "Select tblname,message,time,phone,date,name from chats where status=@status and beinghandled=@beinghandled and sn>=@sn and phone=@phone ORDER BY [SN] ASC";
            //                    //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
            //                    using (cmd = new SqlCommand(sql, con))
            //                    {
            //                        da.SelectCommand = cmd;
            //                        cmd.Parameters.AddWithValue("@status", "On");
            //                        cmd.Parameters.AddWithValue("@phone", LblPhoneTrace.Text);
            //                        cmd.Parameters.AddWithValue("@sn", minSN);
            //                        cmd.Parameters.AddWithValue("@beinghandled", "1");
            //                        //cmd.Parameters.AddWithValue("@phone", phone);
            //                        da.Fill(ds);

            //                        int i; int counting = 0;
            //                        //Load Messages
            //                        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //                        {
            //                            string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            //                            message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            //                            string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            //                            string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            //                            LblPhone.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            //                            string date = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            //                            string name = ds.Tables[0].Rows[i].ItemArray[5].ToString();

            //                            if (tblname == "360QP")
            //                            {
            //                                var html = "";
            //                                html += "<tr>";
            //                                html += "<td>";
            //                                html += "<div class='form-check'>";
            //                                html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-5.png' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
            //                                html += "<span class='check'>" + name + "</span>";
            //                                html += "</div>";
            //                                html += "</td>";
            //                                html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
            //                                html += "</tr>";

            //                                PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
            //                            }
            //                            else
            //                            {
            //                                var html = "";
            //                                html += "<tr>";
            //                                html += "<td>";
            //                                html += "<div class='form-check'>";
            //                                html += "<img class='avatar-md' src='dist/img/avatars/avatar-female-55.jpg' data-toggle='tooltip' data-placement='top' title='Keith' alt='avatar'>";
            //                                html += "<span class='check'>" + name + "</span>";
            //                                html += "</div>";
            //                                html += "</td>";
            //                                html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
            //                                html += "</tr>";
            //                                PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
            //                            }
            //                        }
            //                        counting++;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            //                //this.LblMessage.Text = "No ongoing chats to retrieve, check for new chats.";
            //                //BtnYes.Visible = false;
            //                PanelMessage.Visible = true;
            //                BtnMessage.Text = "No ongoing chats.";
            //            }
            //        }
            //    }                
            //}
        }

        protected void ddlNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlaceHolderChatOngoing.Controls.Clear();
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending
                using (cmd = new SqlCommand("Select Min(SN) from chats where status=@status and beinghandled=@beinghandled and name=@name and messagemode=@messagemode", con))
                {
                    cmd.Parameters.AddWithValue("@status", "On");
                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                    cmd.Parameters.AddWithValue("@name", ddlNames.Text);
                    cmd.Parameters.AddWithValue("@messagemode", "Get Drug");
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            minSN = int.Parse(dr.GetValue(0).ToString());

                            dr.Dispose();
                            using (cmd = new SqlCommand("Select phone from chats where sn=@sn", con))
                            {
                                cmd.Parameters.AddWithValue("@sn", minSN);
                                using (dr = cmd.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        LblPhoneTrace.Text = dr.GetValue(0).ToString();
                                    }
                                }
                            }
                            //continue processing
                            using (da = new SqlDataAdapter())
                            {
                                dr.Dispose();
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,phone,date,name from chats where status=@status and beinghandled=@beinghandled and sn>=@sn and messagemode=@messagemode and phone=@phone ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@phone", LblPhoneTrace.Text);
                                    cmd.Parameters.AddWithValue("@sn", minSN);
                                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                                    cmd.Parameters.AddWithValue("@messagemode", "Get Drug");
                                    da.Fill(ds);

                                    LblMessageMode.Text = "Get Drug";
                                    int i; int counting = 0;
                                    //Load Messages
                                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                    {
                                        string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                        message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                        string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                        string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                        LblPhone.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
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

                                            PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
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
                                            html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                            html += "</tr>";
                                            PlaceHolderChatOngoing.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                    }
                                    counting++;
                                }
                            }
                        }
                        else
                        {
                            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                            //this.LblMessage.Text = "No ongoing chats to retrieve, check for new chats.";
                            //BtnYes.Visible = false;
                            PanelMessage.Visible = true;
                            BtnMessage.Text = "No ongoing chats.";
                        }
                    }
                }
            }
        }

        protected void ddlConsultationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlaceHolderConsultation.Controls.Clear();
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending
                using (cmd = new SqlCommand("Select Min(SN) from chats where status=@status and beinghandled=@beinghandled and name=@name and messagemode=@messagemode", con))
                {
                    cmd.Parameters.AddWithValue("@status", "On");
                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                    cmd.Parameters.AddWithValue("@name", ddlNames.Text);
                    cmd.Parameters.AddWithValue("@messagemode", "Get Advise");
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            minSN = int.Parse(dr.GetValue(0).ToString());

                            dr.Dispose();
                            using (cmd = new SqlCommand("Select phone from chats where sn=@sn", con))
                            {
                                cmd.Parameters.AddWithValue("@sn", minSN);
                                using (dr = cmd.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        LblPhoneTrace.Text = dr.GetValue(0).ToString();
                                    }
                                }
                            }
                            //continue processing
                            using (da = new SqlDataAdapter())
                            {
                                dr.Dispose();
                                DataSet ds = new DataSet();
                                string sql = null;
                                sql = "Select tblname,message,time,phone,date,name from chats where status=@status and beinghandled=@beinghandled and sn>=@sn and messagemode=@messagemode and phone=@phone ORDER BY [SN] ASC";
                                //sqlClick = "Select tblname as Name,message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC";
                                using (cmd = new SqlCommand(sql, con))
                                {
                                    da.SelectCommand = cmd;
                                    cmd.Parameters.AddWithValue("@status", "On");
                                    cmd.Parameters.AddWithValue("@phone", LblPhoneTrace.Text);
                                    cmd.Parameters.AddWithValue("@sn", minSN);
                                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                                    cmd.Parameters.AddWithValue("@messagemode", "Get Advise");
                                    da.Fill(ds);

                                    LblMessageMode.Text = "Get Advise";
                                    int i; int counting = 0;
                                    //Load Messages
                                    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                    {
                                        string tblname = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                                        message = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                                        string time = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                                        string phone = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                                        LblPhone.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
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

                                            PlaceHolderConsultation.Controls.Add(new Literal { Text = html.ToString() });
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
                                            html += "<td><strong><h5>" + message + " (" + phone + ")</h5></strong><p><span><strong><em>" + date + "</strong></em></span></p><p><span><strong><em>" + time + "</strong></em></span></p></td>";
                                            html += "</tr>";
                                            PlaceHolderConsultation.Controls.Add(new Literal { Text = html.ToString() });
                                        }
                                    }
                                    counting++;
                                }
                            }
                        }
                        else
                        {
                            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                            //this.LblMessage.Text = "No ongoing chats to retrieve, check for new chats.";
                            //BtnYes.Visible = false;
                            PanelConsultMessage.Visible = true;
                            BtnConsultMessage.Text = "No ongoing chats.";
                        }
                    }
                }
            }
        }

        protected void BtnSubmitMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.username = Lblusername.Text;
                qp.message = txtMessage.Text;
                qp.phone = LblPhone.Text;
                qp.messagemode = LblMessageMode.Text;
                qp.SaveChatAdmin();
                qp.phone = LblPhone.Text;
                qp.SetToBeingHandled();
                PanelConsultMessage.Visible = true;
                BtnConsultMessage.Text = qp.ResponseMsg;
            }
            else
            {
                PanelConsultMessage.Visible = true;
                BtnConsultMessage.Text = "Empty field(s)";
            }
        }

        protected void BtnConsultCloseEnq_Click(object sender, EventArgs e)
        {
            PanelConsultMessage.Visible = false;
            BtnConsultMessage.Text = "";
            if (LblPhone.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.phone = LblPhone.Text;
                qp.CloseEnquiry();
                PanelConsultMessage.Visible = true;
                BtnConsultMessage.Text = qp.ResponseMsg;
            }
            else
            {
                PanelConsultMessage.Visible = true;
                BtnConsultMessage.Text = "Empty field(s)";
            }
        }

        protected void BtnConsultClose_Click(object sender, EventArgs e)
        {
            PanelConsultMessage.Visible = false;
            BtnConsultMessage.Text = "";
            if (LblPhone.Text != "")
            {
                QuickPharm qp = new QuickPharm();
                qp.phone = LblPhone.Text;
                qp.message = txtMessage.Text;
                qp.CloseSale();
                PanelConsultMessage.Visible = true;
                BtnConsultMessage.Text = qp.ResponseMsg;
            }
            else
            {
                PanelConsultMessage.Visible = true;
                BtnConsultMessage.Text = "Empty field(s).";
            }
        }

        protected void BtnPanelDrug_Click(object sender, EventArgs e)
        {
            PanelDrugPurchase.Visible = true;
            PanelConsultation.Visible = false;
        }

        protected void BtnPanelConsultation_Click(object sender, EventArgs e)
        {
            PanelDrugPurchase.Visible = false;
            PanelConsultation.Visible = true;
        }
    }
}