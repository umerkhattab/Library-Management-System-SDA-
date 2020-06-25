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
    public partial class issue_books : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Muhammad\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystem\\LibraryManagementSystem\\App_Data\\LMS.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }

            cnn.Open();

            if (IsPostBack) return;

            enro.Items.Clear();
            enro.Items.Add("Select");
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select enrollment_no from student_registration";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                enro.Items.Add(dr["enrollment_no"].ToString());

            }

            isbn.Items.Clear();
            isbn.Items.Add("Select");
            SqlCommand cmd1 = cnn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select books_isbn from books";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                isbn.Items.Add(dr1["books_isbn"].ToString());

            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {

            if (isbn.SelectedItem.ToString() == "Select")
            {
                Response.Write("<script>alert('Please select a book!'); window.location.href=window.location.href</script>");
            }
            else
            {

                int found = 0;
                SqlCommand cmd3 = cnn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from issue_books where student_enrollment_no='" + enro.SelectedItem.ToString() + "' and books_isbn='" + isbn.SelectedItem.ToString() + "' and is_books_return='no'";
                cmd3.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
                da1.Fill(dt1);
                found = Convert.ToInt32(dt1.Rows.Count.ToString());

                if (found > 0)
                {
                    Response.Write("<script>alert('this book is already available with this student!');</script>");
                }
                else
                {

                    if (instock.Text == "0")
                    {
                        Response.Write("<script>alert('this book is not available in stock!');</script>");
                    }
                    else
                    {
                        string books_issue_date = DateTime.Now.ToString("yyyy/MM/dd");
                        string approx_return_date = DateTime.Now.AddDays(10).ToString("yyyy/MM/dd");
                        string username = "";

                        SqlCommand cmd = cnn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from student_registration where enrollment_no='" + enro.SelectedItem.ToString() + "'";
                        cmd.ExecuteNonQuery();
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            username = dr["username"].ToString();
                        }

                        SqlCommand cmd1 = cnn.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into issue_books values('" + enro.SelectedItem.ToString() + "','" + isbn.SelectedItem.ToString() + "','" + books_issue_date.ToString() + "','" + approx_return_date.ToString() + "','" + username.ToString() + "','no','no') ";
                        cmd1.ExecuteNonQuery();

                        SqlCommand cmd2 = cnn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "update books set available_qty=available_qty-1 where books_isbn='" + isbn.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();

                        Response.Write("<script>alert('books issued successfully'); window.location.href=window.location.href</script>");
                    }
                }
            }
        }

        protected void isbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            i1.ImageUrl = "";
            booksname.Text = "";
            instock.Text = "";

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from books where books_isbn='" + isbn.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                i1.ImageUrl = dr["books_image"].ToString();
                booksname.Text = dr["books_title"].ToString();
                instock.Text = dr["available_qty"].ToString();
            }
        }
    }
}