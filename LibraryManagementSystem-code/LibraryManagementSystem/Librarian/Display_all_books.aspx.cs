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
    public partial class Display_all_books : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Muhammad\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystem\\LibraryManagementSystem\\App_Data\\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            cnn.Open();

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
                return myvalue.ToString();
            }
            else
            {
                return "<a href='delete_files.aspx?id=" + id + "' style='color:red'>delete video</a>";
            }
        }

        public string checkPdf(object myvalue1, object id1)
        {
            if (myvalue1 == "")
            {
                return myvalue1.ToString();
            }
            else
            {
                return "<a href='delete_files.aspx?id1=" + id1 + "' style='color:red'>delete pdf</a>";
            }
        }


    }
}