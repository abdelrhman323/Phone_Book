﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class Phone_Book : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    SqlCommand cmd;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["id"] !=null && Request.QueryString["action"] != null)
                {
                    string id = Request.QueryString["id"];
                    string action = Request.QueryString["action"];
                    string name = null;
                    string contact = null;
                    string location = null;
                    con.Open();
                    cmd = new SqlCommand("select * from Phone_Book where id='" + id + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        name = dr["Name"].ToString();
                        contact = dr["Contact"].ToString();
                        location = dr["Location"].ToString();
                    }
                    con.Close();
                    if (action == "1")
                    {
                        con.Open();
                        cmd = new SqlCommand("delete from Phone_Book where id='" + id + "'", con);
                        int checkD = cmd.ExecuteNonQuery();
                        if (checkD == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "deleted", "<script>alert('Contact Deleted...!!!');location='Phone_Book.aspx';</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "fail", "<script>alert('Failed...!!!');</script>");
                        }
                        con.Close();
                    }
                    else if (action == "2")
                    {
                        addbtn.Enabled = false;
                        upbtn.Enabled = true;
                        Session["id"] = id;
                        txtName.Text = name;
                        txtContact.Text = contact;
                        txtLocation.Text = location;
                    }
                    
                }
                con.Open();
                cmd = new SqlCommand("select * from Phone_Book", con);
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    gridBook.DataSource = dr;
                    gridBook.DataBind();
                }
                con.Close();
            }
        }

        protected void addbtn_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into Phone_Book values(@Name,@Contact,@Location)",con);
            cmd.Parameters.Add("@Name", txtName.Text);
            cmd.Parameters.Add("@Contact", txtContact.Text);
            cmd.Parameters.Add("@Location", txtLocation.Text);
            int count = cmd.ExecuteNonQuery();
            if(count == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "added", "<script>alert('Contact Added....!');location='Phone_Book.aspx';</script>");
                txtName.Text = "";
                txtContact.Text = "";
                txtLocation.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "failed", "<script>alert('please try again...!');</script>");

            }
            con.Close();
        }

        protected void upbtn_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update Phone_Book set Name=@Name, Contact=@Contact, Location=@Location where id='" + Session["id"] + "'", con);
            cmd.Parameters.Add("@Name", txtName.Text);
            cmd.Parameters.Add("@Contact", txtContact.Text);
            cmd.Parameters.Add("@Location", txtLocation.Text);
            int checkD = cmd.ExecuteNonQuery();
            if (checkD == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "updated", "<script>alert('Contact Updated...!!!');location='Phone_Book.aspx';</script>");
                txtName.Text = "";
                txtContact.Text = "";
                txtLocation.Text = "";
                addbtn.Enabled = true;
                upbtn.Enabled = false;
                Session.Abandon();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Updatefail", "<script>alert('Failed...!!!');</script>");
            }
            con.Close();
        }
    }
}