using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlline_liberay
{
    public partial class Adminlogin : System.Web.UI.Page
    {
        string strdon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
             {
                 SqlConnection con = new SqlConnection(strdon);
                 if (con.State == ConnectionState.Closed)
                 {
                     con.Open();
                 }

                 SqlCommand cmd = new SqlCommand("select * from admin_login_tbl where username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                 SqlDataReader dr = cmd.ExecuteReader();
                 if (dr.HasRows)
                 {
                     while (dr.Read())
                     {
                         Response.Write("<Script>alert('" + dr.GetValue(0).ToString() + "');</Script>");
                        Session["username"] = dr.GetValue(0).ToString();
                       // Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                        //Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                 else
                 {
                     Response.Write("<Script>alert('Invalid user ');</Script>");
                 }

                 //Response.Write("<Script>alert('Button click');</Script>");
             }

             catch (Exception ex)
             {
                 Response.Write("<Script>alert('"+ex.Message+"');</Script>");
             }

            //Response.Write("<script>alert('Rohan');</script>");
           /* try
            {
                SqlConnection con = new SqlConnection(strdon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into admin_login_tbl (username,password)" +
                    "values(@name,@pass)", con);

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", TextBox2.Text.Trim());
                //cmd.Parameters.AddWithValue("@fname", TextBox3.Text.Trim());

                cmd.Parameters.AddWithValue("@mail", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_stuts", TextBox10.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<Script>alert('User signUP go to login');</Script>");
            }
            catch (Exception ex)
            {
                Response.Write("<Script>alert('" + ex.Message + "');</Script>");
            }*/

        }

    }
}