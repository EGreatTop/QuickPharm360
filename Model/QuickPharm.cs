using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuickPharm360.Model
{
    public class QuickPharm
    {
        private string conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private int day = DateTime.Now.Day;
        private int month = DateTime.Now.Month;
        private int year = DateTime.Now.Year;
        private string currentdate = DateTime.Now.ToShortDateString();
        private double currentdayofweek = (double)DateTime.Now.Day;
        private SqlDataAdapter da;
        private SqlConnection con;
        private SqlConnection con1;
        private SqlConnection con2;
        private SqlCommand cmd;
        private SqlCommand cmd1;
        private SqlDataReader dr;
        private SqlDataReader dr1;
        public DataTable dt;
        public int dd = DateTime.Now.Day;
        public int mm = DateTime.Now.Month;
        public int yy = DateTime.Now.Year;
        public string date = DateTime.Now.ToShortDateString();
        public string ResponseMsg;
        public string name;
        public string phone;
        public string category;
        public string drug; 
        public string message;
        public string messageid;
        public string messagemode;
        public string status;
        public string salescomplete;
        public string beinghandled;
        public string MaxSN;
        public string username;
        public string password;
        public string access;
        public string AdminUser;
        public string tblname;
        public string runningchats;
        public string closedsales;
        public string closedchats;
        public string allusers;
        public string email;
        public string unattendedchats;

        public void ClientSignUp()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using(cmd = new SqlCommand("Select phone from Login where phone=@phone", con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using(dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            ResponseMsg = "Phone number already exists!";
                        }
                        else
                        {
                            dr.Dispose();
                            using(cmd = new SqlCommand("Insert into Login (name,phone) values (@name,@phone)", con))
                            {
                                cmd.Parameters.AddWithValue("@name", name);
                                cmd.Parameters.AddWithValue("@phone", phone);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Success!";
                            }
                        }
                    }
                }
            }
        }

        public void ClientLogin()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using(cmd = new SqlCommand("Select phone,name from login where phone=@phone", con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using(dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            name = dr.GetValue(1).ToString();
                            ResponseMsg = "1";
                        }
                        else
                        {
                            ResponseMsg = "0";
                        }
                    }
                }
            }
        }

        public void AdminCreateAccount()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select username from AdminLogin where username=@username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ResponseMsg = "Username already exists.";
                        }
                        else
                        {
                            dr.Dispose();
                            using (cmd = new SqlCommand("Insert into AdminLogin(username,password,access) values (@username,@password,@access)", con))
                            {
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@password", password);
                                cmd.Parameters.AddWithValue("@access", "0");
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Success!";
                            }
                        }
                    }
                }
            }
        }

        public void AdminLogin()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select username,access from AdminLogin where username=@username and password=@password", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            access = dr.GetValue(1).ToString();
                            if (access == "1")
                            {
                                ResponseMsg = "Success!";
                            }
                            else if (access == "3")
                            {
                                ResponseMsg = "Success!";
                            }
                            else
                            {
                                ResponseMsg = "Access Denied!";
                            }
                        }
                        else
                        {
                            ResponseMsg = "Invalid Login Details!";
                        }
                    }
                }
            }
        }

        public void AdminMakeAdmin()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select username,access from AdminLogin where username=@username", con))
                {
                    cmd.Parameters.AddWithValue("@username", AdminUser);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string access = dr.GetValue(1).ToString();
                            if (access == "3")
                            {
                                dr.Dispose();
                                using (cmd = new SqlCommand("Select username,access from AdminLogin where username=@username", con))
                                {
                                    cmd.Parameters.AddWithValue("@username", username);
                                    using (dr = cmd.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            string adminAccess = dr.GetValue(1).ToString();
                                            if (adminAccess == "3")
                                            {
                                                ResponseMsg = username + " has been set as an Admin previously.";
                                            }
                                            else
                                            {
                                                dr.Dispose();
                                                using (cmd = new SqlCommand("Update AdminLogin set access=@access where username=@username", con))
                                                {
                                                    cmd.Parameters.AddWithValue("@username", username);
                                                    cmd.Parameters.AddWithValue("@access", "3");
                                                    cmd.ExecuteNonQuery();
                                                    ResponseMsg = username + " upgraded as an Admin.";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ResponseMsg = "You cannot perform this operation!";
                            }
                        }
                        else
                        {
                            ResponseMsg = "Invalid Username";
                        }
                    }
                }
            }
        }

        public void AdminUserEnable()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select username,access from AdminLogin where username=@username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string access = dr.GetValue(1).ToString();
                            if (access == "3")
                            {
                                ResponseMsg = username + "is already a Super Admin.";
                            }
                            else
                            {
                                dr.Dispose();
                                using (cmd = new SqlCommand("Select username from AdminLogin where username=@username", con))
                                {
                                    cmd.Parameters.AddWithValue("@username", username);
                                    using (dr = cmd.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            dr.Dispose();
                                            using (cmd = new SqlCommand("Update AdminLogin set access=@access where username=@username", con))
                                            {
                                                cmd.Parameters.AddWithValue("@username", username);
                                                cmd.Parameters.AddWithValue("@access", "1");
                                                cmd.ExecuteNonQuery();
                                                ResponseMsg = username + " enabled.";
                                            }
                                        }
                                        else
                                        {
                                            ResponseMsg = "Invalid Username";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AdminUserDisable()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select username,access from AdminLogin where username=@username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string access = dr.GetValue(1).ToString();
                            if (access == "3")
                            {
                                ResponseMsg = "INVALID: You cannot disable " + username;
                            }
                            else
                            {
                                dr.Dispose();
                                using (cmd = new SqlCommand("Select username from AdminLogin where username=@username", con))
                                {
                                    cmd.Parameters.AddWithValue("@username", username);
                                    using (dr = cmd.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            dr.Dispose();
                                            using (cmd = new SqlCommand("Update AdminLogin set access=@access where username=@username", con))
                                            {
                                                cmd.Parameters.AddWithValue("@username", username);
                                                cmd.Parameters.AddWithValue("@access", "0");
                                                cmd.ExecuteNonQuery();
                                                ResponseMsg = username + " disabled.";
                                            }
                                        }
                                        else
                                        {
                                            ResponseMsg = "Invalid Username";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AdminUpdatePassword()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select username,access from AdminLogin where username=@username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string access = dr.GetValue(1).ToString();
                            if (access == "3")
                            {
                                dr.Dispose();
                                using(cmd = new SqlCommand("Update AdminLogin set password=@password where username=@username", con))
                                {
                                    cmd.Parameters.AddWithValue("@username", username);
                                    cmd.Parameters.AddWithValue("@password", password);
                                    cmd.ExecuteNonQuery();
                                    ResponseMsg = "Done!";
                                }
                            }
                            else
                            {
                                ResponseMsg = "INVALID OPERATION";
                            }
                        }
                    }
                }
            }
        }

        public void AdminUserDelete()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select username,access from AdminLogin where username=@username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string access = dr.GetValue(1).ToString();
                            if (access == "3")
                            {
                                ResponseMsg = "INVALID: You cannot delete " + username;
                            }
                            else
                            {
                                dr.Dispose();
                                using (cmd = new SqlCommand("Select username from AdminLogin where username=@username", con))
                                {
                                    cmd.Parameters.AddWithValue("@username", username);
                                    using (dr = cmd.ExecuteReader())
                                    {
                                        if (dr.Read())
                                        {
                                            dr.Dispose();
                                            using (cmd = new SqlCommand("Delete AdminLogin where username=@username", con))
                                            {
                                                cmd.Parameters.AddWithValue("@username", username);
                                                cmd.ExecuteNonQuery();
                                                ResponseMsg = username + " deleted.";
                                            }
                                        }
                                        else
                                        {
                                            ResponseMsg = "Invalid Username";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void AdminSetEmail()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select email from adminemail", con))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        if(dr.Read() && !dr.IsDBNull(0))
                        {
                            dr.Dispose();
                            using (cmd = new SqlCommand("Update adminemail set email=@email", con))
                            {
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Update Success!";
                            }
                        }
                        else if(email != "")
                        {
                            dr.Dispose();
                            using(cmd = new SqlCommand("Insert into adminemail(email) values (@email)", con))
                            {
                                cmd.Parameters.AddWithValue("@email", email);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Success!";
                            }
                        }
                    }                
                }
            }
        }

        public void AdminGetEmail()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select email from adminemail", con))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            ResponseMsg = dr.GetValue(0).ToString();
                        }
                        else
                        {
                            ResponseMsg = "0";                            
                        }
                    }
                }
            }
        }

        public void AddDrugCategory()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using(cmd = new SqlCommand("Select category from drugcategory where category=@category", con))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    using(dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            ResponseMsg = "This category already exists!";
                        }
                        else
                        {
                            dr.Dispose();
                            using(cmd = new SqlCommand("Insert into drugcategory (category) values (@category)", con))
                            {
                                cmd.Parameters.AddWithValue("@category", category);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Success!";
                            }
                        }
                    }
                }
            }
        }

        public void UpdateDrugCategory()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select category from drugcategory where category=@category", con))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dr.Dispose();
                            using (cmd = new SqlCommand("Update drugcategory set category=@category", con))
                            {
                                cmd.Parameters.AddWithValue("@category", category);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Success!";
                            }
                        }
                        else
                        {
                            ResponseMsg = "This category does not exist!";
                        }
                    }
                }
            }
        }

        public void AddDrugs()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select drug from drugs where drug=@drug", con))
                {
                    cmd.Parameters.AddWithValue("@drug", drug);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ResponseMsg = "This drug already exists!";
                        }
                        else
                        {
                            dr.Dispose();
                            using (cmd = new SqlCommand("Insert into drugs (category,drug) values (@category,@drug)", con))
                            {
                                cmd.Parameters.AddWithValue("@category", category);
                                cmd.Parameters.AddWithValue("@drug", drug);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Success!";
                            }
                        }
                    }
                }
            }
        }

        public void UpdateDrugs()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select drug from drugs where drug=@drug", con))
                {
                    cmd.Parameters.AddWithValue("@drug", drug);
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dr.Dispose();
                            using (cmd = new SqlCommand("Update drugs set drug=@drug where category=@category", con))
                            {
                                cmd.Parameters.AddWithValue("@category", category);
                                cmd.Parameters.AddWithValue("@drug", drug);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Success!";
                            }
                        }
                        else
                        {
                            ResponseMsg = "This drug does not exists!";
                        }
                    }
                }
            }
        }

        public void SaveChat()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Insert into chats(name,tblname,phone,message,messageid,messagemode,status,salescomplete,beinghandled,dd,mm,yy,date,time) values (@name,@tblname,@phone,@message,@messageid,@messagemode,@status,@salescomplete,@beinghandled,@dd,@mm,@yy,@date,@time)", con))
                {//name,phone,message,messageid,messagemode,status,salescomplete,beinghandled,dd,mm,yy,date
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@tblname", tblname);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@message", message);
                    int yourRandomEmailString = 10; //maximum: 32 
                    messageid = Guid.NewGuid().ToString("N").Substring(0, yourRandomEmailString);
                    cmd.Parameters.AddWithValue("@messageid", messageid);
                    cmd.Parameters.AddWithValue("@messagemode", messagemode);
                    status = "On";
                    cmd.Parameters.AddWithValue("@status", status);
                    salescomplete = "0";
                    cmd.Parameters.AddWithValue("@salescomplete", salescomplete);
                    beinghandled = "0";
                    cmd.Parameters.AddWithValue("@beinghandled", beinghandled);
                    cmd.Parameters.AddWithValue("@dd", dd);
                    cmd.Parameters.AddWithValue("@mm", mm);
                    cmd.Parameters.AddWithValue("@yy", yy);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
                    cmd.ExecuteNonQuery();
                    ResponseMsg = "Sent!";
                }
            }
        }

        public void ClearChats()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using(cmd = new SqlCommand("Delete chats where phone=@phone and dd<@dd and mm<=@mm and yy=@yy", con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@dd", dd);
                    cmd.Parameters.AddWithValue("@mm", mm);
                    cmd.Parameters.AddWithValue("@yy", yy);
                    cmd.ExecuteNonQuery();
                    ResponseMsg = "History Cleared.";
                }
            }
        }

        public void SetToBeingHandled()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using(cmd = new SqlCommand("Select Max(SN) from chats where phone=@phone and status=@status", con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@status", "On");
                    using(dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            MaxSN = dr.GetValue(0).ToString();
                            ResponseMsg = MaxSN;
                            //update now
                            dr.Dispose();
                            using(cmd = new SqlCommand("Update chats set beinghandled=@beinghandled where SN<=@sn",con))
                            {
                                cmd.Parameters.AddWithValue("@beinghandled", "1");
                                cmd.Parameters.AddWithValue("@sn", MaxSN);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Done!";
                            }
                        }
                    }
                }
            }
        }

        public void CloseEnquiry()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select Max(SN) from chats where phone=@phone and status=@status", con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@status", "On");
                    using (dr = cmd.ExecuteReader())
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            MaxSN = dr.GetValue(0).ToString();
                            ResponseMsg = MaxSN;
                            //update now
                            dr.Dispose();
                            using (cmd = new SqlCommand("Update chats set status=@status,beinghandled=@beinghandled where SN<=@sn and phone=@phone", con))
                            {
                                cmd.Parameters.AddWithValue("@status", "On");
                                cmd.Parameters.AddWithValue("@beinghandled", "2");
                                cmd.Parameters.AddWithValue("@sn", MaxSN);
                                cmd.Parameters.AddWithValue("@phone", phone);
                                cmd.ExecuteNonQuery();
                                ResponseMsg = "Done!";
                            }
                        }
                }
            }
        }

        public void CloseSale()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Select Max(SN) from chats where phone=@phone and status=@status", con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@status", "On");
                    using (dr = cmd.ExecuteReader())
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            MaxSN = dr.GetValue(0).ToString();
                            ResponseMsg = MaxSN;
                            //update now
                            dr.Dispose();
                            using (cmd = new SqlCommand("Update chats set beinghandled=@beinghandled where SN<=@sn and phone=@phone", con))
                            {
                                cmd.Parameters.AddWithValue("@beinghandled", "3");
                                cmd.Parameters.AddWithValue("@sn", MaxSN);
                                cmd.Parameters.AddWithValue("@phone", phone);
                                cmd.ExecuteNonQuery();

                                using (cmd = new SqlCommand("Insert into Salesclosed (phone,message,dd,mm,yy,date) values (@phone,@message,@dd,@mm,@yy,@date)", con))
                                {//phone,message,dd,mm,yy,date
                                    cmd.Parameters.AddWithValue("phone", phone);
                                    cmd.Parameters.AddWithValue("message", message);
                                    cmd.Parameters.AddWithValue("dd", dd);
                                    cmd.Parameters.AddWithValue("mm", mm);
                                    cmd.Parameters.AddWithValue("yy", yy);
                                    cmd.Parameters.AddWithValue("date", date);
                                    ResponseMsg = "Done!";
                                }

                            }
                        }
                }
            }
        }

        public DataTable GetChatClient()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending
                using (this.cmd = new SqlCommand("Select Tblname as Name,Message as Chat from Chats where phone=@phone and status=@status and dd=@dd and mm=@mm and yy=@yy ORDER BY [SN] ASC", this.con))
                {
                    this.cmd.Parameters.AddWithValue("@phone", (object)this.phone);
                    this.cmd.Parameters.AddWithValue("@status", (object)"On");
                    this.cmd.Parameters.AddWithValue("@dd", (object)this.dd);
                    this.cmd.Parameters.AddWithValue("@mm", (object)this.mm);
                    this.cmd.Parameters.AddWithValue("@yy", (object)this.yy);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        this.cmd.Connection = this.con;
                        sqlDataAdapter.SelectCommand = this.cmd;
                        using (this.dt = new DataTable())
                        {
                            sqlDataAdapter.Fill(this.dt);
                            return this.dt;
                        }
                    }
                }
            }
        }

        public DataTable GetChatAdmin()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending
                using (this.cmd = new SqlCommand("Select DISTINCT Phone as Phone_Number from Chats where status=@status and beinghandled=@beinghandled and dd=@dd and mm=@mm and yy=@yy ORDER BY [SN] ASC", this.con))
                {
                    this.cmd.Parameters.AddWithValue("@beinghandled", "0");
                    this.cmd.Parameters.AddWithValue("@status", (object)"On");
                    this.cmd.Parameters.AddWithValue("@dd", (object)this.dd);
                    this.cmd.Parameters.AddWithValue("@mm", (object)this.mm);
                    this.cmd.Parameters.AddWithValue("@yy", (object)this.yy);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        this.cmd.Connection = this.con;
                        sqlDataAdapter.SelectCommand = this.cmd;
                        using (this.dt = new DataTable())
                        {
                            sqlDataAdapter.Fill(this.dt);
                            return this.dt;
                        }
                    }
                }
            }
        }

        public DataTable GetChatBeingHandledAdmin()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending
                using (this.cmd = new SqlCommand("Select DISTINCT Phone as Phone_Number from Chats where status=@status and beinghandled=@beinghandled and dd=@dd and mm=@mm and yy=@yy ORDER BY [SN] ASC", this.con))
                {
                    this.cmd.Parameters.AddWithValue("@beinghandled", "1");
                    this.cmd.Parameters.AddWithValue("@status", (object)"On");
                    this.cmd.Parameters.AddWithValue("@dd", (object)this.dd);
                    this.cmd.Parameters.AddWithValue("@mm", (object)this.mm);
                    this.cmd.Parameters.AddWithValue("@yy", (object)this.yy);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        this.cmd.Connection = this.con;
                        sqlDataAdapter.SelectCommand = this.cmd;
                        using (this.dt = new DataTable())
                        {
                            sqlDataAdapter.Fill(this.dt);
                            return this.dt;
                        }
                    }
                }
            }
        }

        public DataTable LoadChatAdmin()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending
                using (this.cmd = new SqlCommand("Select tblname as Name, message as Chats from chats where status=@status and phone=@phone ORDER BY [SN] ASC", this.con))
                {
                    cmd.Parameters.AddWithValue("@status", "On");
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        this.cmd.Connection = this.con;
                        sqlDataAdapter.SelectCommand = this.cmd;
                        using (this.dt = new DataTable())
                        {
                            sqlDataAdapter.Fill(this.dt);
                            return this.dt;
                        }
                    }
                }
            }
        }

        public DataTable LoadChatBeingHandledAdmin()
        {
            using (con = new SqlConnection(conn))
            {
                con.Open();//DESC - Sql ordering descending
                using (this.cmd = new SqlCommand("Select tblname as Name,message as Chats from chats where status=@status and beinghandled=@beinghandled and phone=@phone ORDER BY [SN] ASC", this.con))
                {
                    cmd.Parameters.AddWithValue("@status", "On");
                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        this.cmd.Connection = this.con;
                        sqlDataAdapter.SelectCommand = this.cmd;
                        using (this.dt = new DataTable())
                        {
                            sqlDataAdapter.Fill(this.dt);
                            return this.dt;
                        }
                    }
                }
            }
        }

        public void SaveChatAdmin()
        {
            using(con= new SqlConnection(conn))
            {
                con.Open();
                using (cmd = new SqlCommand("Insert into chats(name,tblname,phone,message,messageid,messagemode,status,salescomplete,beinghandled,dd,mm,yy,date,time) values (@name,@tblname,@phone,@message,@messageid,@messagemode,@status,@salescomplete,@beinghandled,@dd,@mm,@yy,@date,@time)", con))
                {//name,phone,message,messageid,messagemode,status,salescomplete,beinghandled,dd,mm,yy,date
                    cmd.Parameters.AddWithValue("@name", username);
                    cmd.Parameters.AddWithValue("@tblname", "360QP");
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@message", message);
                    int yourRandomEmailString = 10; //maximum: 32 
                    messageid = Guid.NewGuid().ToString("N").Substring(0, yourRandomEmailString);
                    cmd.Parameters.AddWithValue("@messageid", messageid);
                    cmd.Parameters.AddWithValue("@messagemode", messagemode);
                    status = "On";
                    cmd.Parameters.AddWithValue("@status", status);
                    salescomplete = "0";
                    cmd.Parameters.AddWithValue("@salescomplete", salescomplete);
                    beinghandled = "1";
                    cmd.Parameters.AddWithValue("@beinghandled", beinghandled);
                    cmd.Parameters.AddWithValue("@dd", dd);
                    cmd.Parameters.AddWithValue("@mm", mm);
                    cmd.Parameters.AddWithValue("@yy", yy);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
                    cmd.ExecuteNonQuery();
                    ResponseMsg = "Sent!";
                }
            }
        }

        public void LoadAdminDashboard()
        {
            using(con = new SqlConnection(conn))
            {
                con.Open();
                using(cmd = new SqlCommand("Select COUNT (distinct phone) from chats where status=@status", con))
                {
                    cmd.Parameters.AddWithValue("@status", "On");
                    using(dr = cmd.ExecuteReader())
                    {
                        if(dr.Read() && !dr.IsDBNull(0))
                        {
                            runningchats = dr.GetValue(0).ToString();
                        }
                        else
                        {
                            runningchats = "0";
                        }
                    }
                }

                dr.Dispose();
                using (cmd = new SqlCommand("Select COUNT (distinct phone) from chats where salescomplete=@salescomplete", con))
                {
                    cmd.Parameters.AddWithValue("@salescomplete", "1");
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            closedsales = dr.GetValue(0).ToString();
                        }
                        else
                        {
                            closedsales = "0";
                        }
                    }
                }

                dr.Dispose();
                using (cmd = new SqlCommand("Select COUNT (distinct phone) from chats where beinghandled=@beinghandled", con))
                {
                    cmd.Parameters.AddWithValue("@beinghandled", "1");
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            closedchats = dr.GetValue(0).ToString();
                        }
                        else
                        {
                            closedchats = "0";
                        }
                    }
                }

                dr.Dispose();
                using (cmd = new SqlCommand("Select COUNT (distinct phone) from chats where status=@status and beinghandled=@beinghandled", con))
                {
                    cmd.Parameters.AddWithValue("@status", "On");
                    cmd.Parameters.AddWithValue("@beinghandled", "0");
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            unattendedchats = dr.GetValue(0).ToString();
                        }
                        else
                        {
                            unattendedchats = "0";
                        }
                    }
                }

                dr.Dispose();
                using (cmd = new SqlCommand("Select COUNT (phone) from login", con))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && !dr.IsDBNull(0))
                        {
                            allusers = dr.GetValue(0).ToString();
                        }
                        else
                        {
                            allusers = "0";
                        }
                    }
                }

            }
        }


    }
}