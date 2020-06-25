using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Student
{
    public partial class student_registration : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Muhammad\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystem\\LibraryManagementSystem\\App_Data\\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            cnn.Open();

        }

        protected void b1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int count1 = 0;

            SqlCommand cmd1 = cnn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from student_registration where enrollment_no='" + enrollmentno.Text + "'";
            cmd1.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            if (count > 0)
            {
                Response.Write("<script>alert('This Enrollment Number is already registered!');</script>");
            }
            else
            {   
                
                SqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from student_registration where username='" + username.Text + "'";
                cmd2.ExecuteNonQuery();

                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                da1.Fill(dt1);
                count1 = Convert.ToInt32(dt1.Rows.Count.ToString());

                if (count1 > 0)
                {
                    Response.Write("<script>alert('This Username is already taken!');</script>");
                }
                else
                {

                    string randomNo = Class1.GetRandomPassword(10) + ".jpg";

                    fo1.SaveAs(Request.PhysicalApplicationPath + "/student/student_img/" + randomNo.ToString());
                    string path = "student/student_img/" + randomNo.ToString();

                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into student_registration values ('" + firstname.Text + "','" + lastname.Text + "','" + enrollmentno.Text + "','" + username.Text + "','" + password.Text + "','" + email.Text + "','" + contact.Text + "','" + path.ToString() + "','no')";
                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Registered Successfully');</script>");
                }

            }
        }
    }
}