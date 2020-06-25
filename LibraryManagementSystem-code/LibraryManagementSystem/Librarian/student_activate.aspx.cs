using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Librarian
{
    public partial class student_activate : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Muhammad\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystem\\LibraryManagementSystem\\App_Data\\LMS.mdf;Integrated Security=True");
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            cnn.Open();

            id = Convert.ToInt32(Request.QueryString["id"].ToString());

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update student_registration set approved = 'yes' where id = "+id+";";
            cmd.ExecuteNonQuery();

            Response.Redirect("display_student_info.aspx");
        }
    }
}