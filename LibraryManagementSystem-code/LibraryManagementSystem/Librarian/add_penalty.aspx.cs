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
    public partial class add_penalty : System.Web.UI.Page
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

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Penalty";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                penalty.Text = dr["Penalty"].ToString();
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Penalty";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)
            {
                SqlCommand cmd1 = cnn.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into Penalty values('" + penalty.Text + "')";
                cmd1.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd2 = cnn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update Penalty set penalty='" + penalty.Text + "'";
                cmd2.ExecuteNonQuery();
            }

            Response.Redirect("add_Penalty.aspx");
        }
    }
}