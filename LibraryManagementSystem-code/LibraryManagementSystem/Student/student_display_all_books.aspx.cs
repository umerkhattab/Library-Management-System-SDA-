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
    public partial class student_display_all_books : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Muhammad\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystem\\LibraryManagementSystem\\App_Data\\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            cnn.Open();

            if (Session["student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from books";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);

            r1.DataSource = dt;
            r1.DataBind();
        }

        public string checkvideo(object myvalue, object id)
        {
            if (myvalue == "")
            {
                return "Not Available";
            }
            else
            {
                myvalue = "../Librarian/" + myvalue.ToString();
                return "<a href='"+myvalue.ToString()+"' style='color:green'>View video</a>";
            }
        }

        public string checkPdf(object myvalue1, object id1)
        {
            if (myvalue1 == "")
            {
                return "Not Available";
            }
            else
            {
                myvalue1 = "../Librarian/" + myvalue1.ToString();
                return "<a href='"+myvalue1.ToString()+"' style='color:green'>View pdf</a>";
            }
        }
    }
}