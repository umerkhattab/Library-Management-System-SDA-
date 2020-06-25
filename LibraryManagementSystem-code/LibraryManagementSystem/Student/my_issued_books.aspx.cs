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
    public partial class my_issued_books : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Muhammad\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystem\\LibraryManagementSystem\\App_Data\\LMS.mdf;Integrated Security=True");
        string penalty = "0";
        double NoOfDays;
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

            SqlCommand cmd2 = cnn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Penalty";
            cmd2.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                penalty = dr["Penalty"].ToString();
            }

            DataTable TempTable = new DataTable();
            TempTable.Clear();
            TempTable.Columns.Add("student_enrollment_no");
            TempTable.Columns.Add("books_isbn");
            TempTable.Columns.Add("books_issue_date");
            TempTable.Columns.Add("books_approx_return_date");
            TempTable.Columns.Add("student_username");
            TempTable.Columns.Add("is_books_returned");
            TempTable.Columns.Add("books_return_date");
            TempTable.Columns.Add("latedays");
            TempTable.Columns.Add("Penalty");

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_books where student_username='"+Session["student"].ToString()+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                DataRow dr1 = TempTable.NewRow();
                dr1["student_enrollment_no"] = dr["student_enrollment_no"].ToString();
                dr1["books_isbn"] = dr["books_isbn"].ToString();
                dr1["books_issue_date"] = dr["books_issue_date"].ToString();
                dr1["books_approx_return_date"] = dr["books_approx_return_date"].ToString();
                dr1["student_username"] = dr["student_username"].ToString();
                dr1["is_books_returned"] = dr["is_books_returned"].ToString();
                dr1["books_return_date"] = dr["books_return_date"].ToString();

                DateTime CurrentDate = Convert.ToDateTime(DateTime.Now.ToString());
                DateTime ApproxDate = Convert.ToDateTime(dr["books_approx_return_date"].ToString());

                if (CurrentDate > ApproxDate)
                {
                    TimeSpan T = CurrentDate - ApproxDate;
                    NoOfDays = Math.Floor(T.TotalDays);
                    dr1["latedays"] = NoOfDays.ToString();
                }
                else
                {
                    dr1["latedays"] = "0";
                }

                dr1["Penalty"] = (NoOfDays * Convert.ToDouble(penalty)).ToString();
                TempTable.Rows.Add(dr1);
            }

            d1.DataSource = TempTable;
            d1.DataBind();
        }
    }
}