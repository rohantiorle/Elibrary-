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
    public partial class Usersignup : System.Web.UI.Page
    {
        string strdon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //All the signup click 
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Rohan');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strdon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into member_master_tbl (full_name,dbo,contact_no,email,state,city,pincode,full_address,member_id,password,account_stuts) " +
                    "values(@full_name,@dbo,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_stuts)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dbo", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
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
                Response.Write("<Script>alert('"+ ex.Message +"');</Script>");
            }

        }
    }
}