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
    public partial class Login : System.Web.UI.Page
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
            int i = 0;

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Librarian_Registration where username='"+Username.Text+"' and password='"+Password.Text+"'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i > 0)
            {
                Response.Redirect("demo.aspx");
            }
            else
            {
                error.Style.Add("display", "black");
            }
        }
    }
}