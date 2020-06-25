using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LibraryManagementSystem.Librarian
{
    
    public partial class delete_files : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Muhammad\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystem\\LibraryManagementSystem\\App_Data\\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            cnn.Open();

            if (Request.QueryString["id"] != null)
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_video = '' where id = '" + Request.QueryString["id"].ToString() + "'";
                cmd.ExecuteNonQuery();

            }
            else if(Request.QueryString["id1"] != null)
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_pdf= '' where id = '" + Request.QueryString["id1"].ToString() + "'";
                cmd.ExecuteNonQuery();

            }
            else
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from books where id ='" + Request.QueryString["id2"].ToString() + "'";
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Display_all_books.aspx");

            
        }
    }
}