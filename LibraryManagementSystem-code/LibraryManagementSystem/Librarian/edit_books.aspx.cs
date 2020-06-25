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
    public partial class edit_books : System.Web.UI.Page
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

            if (IsPostBack) return;

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from books where id = "+id+" ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                booksTitle.Text = dr["books_title"].ToString();
                AuthorName.Text = dr["books_author_name"].ToString();
                ISBN.Text = dr["books_isbn"].ToString();
                Qty.Text = dr["available_qty"].ToString();
                booksimage.Text = dr["books_image"].ToString();
                bookspdf.Text = dr["books_pdf"].ToString();
                booksvideo.Text = dr["books_video"].ToString();
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            string Books_Image_Name = "";
            string Books_Pdf = "";
            string Books_Videos = "";

            string path = "";
            string path2 = "";
            string path3 = "";


            if (f1.FileName.ToString() != "")
            {
                Books_Image_Name = Class1.GetRandomPassword(10) + ".jpg";
                f1.SaveAs(Request.PhysicalApplicationPath + "/Librarian/Books_Images/" + Books_Image_Name.ToString());
                path = "Books_Images/" + Books_Image_Name.ToString();

                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title = '"+booksTitle.Text+"', books_image='"+path.ToString()+"', books_author_name='"+AuthorName.Text+"',books_isbn='"+ISBN.Text+"',available_qty='"+Qty.Text+"' where id = " + id + "";
                cmd.ExecuteNonQuery();
            }

            if (f2.FileName.ToString() != "")
            {
                Books_Pdf = Class1.GetRandomPassword(10) + ".pdf";

                f2.SaveAs(Request.PhysicalApplicationPath + "/Librarian/Books_Pdf/" + Books_Pdf.ToString());
                path2 = "Books_Pdf/" + Books_Pdf.ToString();

                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title = '" + booksTitle.Text + "', books_pdf='" + path2.ToString() + "', books_author_name='" + AuthorName.Text + "',books_isbn='" + ISBN.Text + "',available_qty='" + Qty.Text + "' where id = " + id + "";
                cmd.ExecuteNonQuery();
            }

            if (f3.FileName.ToString() != "")
            {
                Books_Videos = Class1.GetRandomPassword(10) + ".mp4";

                f3.SaveAs(Request.PhysicalApplicationPath + "/Librarian/Books_Videos/" + Books_Videos.ToString());
                path3 = "Books_Videos/" + Books_Videos.ToString();

                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title = '" + booksTitle.Text + "', books_video='" + path3.ToString() + "', books_author_name='" + AuthorName.Text + "',books_isbn='" + ISBN.Text + "',available_qty='" + Qty.Text + "' where id = " + id + "";
                cmd.ExecuteNonQuery();
            }

            if(f1.FileName.ToString()=="" && f2.FileName.ToString() == "" && f3.FileName.ToString() == "")
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update books set books_title = '" + booksTitle.Text + "', books_author_name='" + AuthorName.Text + "',books_isbn='" + ISBN.Text + "',available_qty='" + Qty.Text + "' where id = " + id + "";
                cmd.ExecuteNonQuery();

            }


            Response.Redirect("Display_all_books.aspx");
            
        }
    }
}