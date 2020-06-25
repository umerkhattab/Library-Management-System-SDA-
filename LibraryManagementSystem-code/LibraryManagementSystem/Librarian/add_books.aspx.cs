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
    public partial class add_books : System.Web.UI.Page
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
            string Books_Image_Name = Class1.GetRandomPassword(10) + ".jpg";
            string Books_Pdf = Class1.GetRandomPassword(10) + ".jpg";
            string Books_Videos = Class1.GetRandomPassword(10) + ".jpg";

            string path = "";
            string path2 = "";
            string path3 = "";

            f1.SaveAs(Request.PhysicalApplicationPath + "/Librarian/Books_Images/" + Books_Image_Name.ToString());
            path = "Books_Images/" + Books_Image_Name.ToString();

            if (f2.FileName.ToString() != "")
            {
                Books_Pdf = Class1.GetRandomPassword(10) + ".pdf";

                f2.SaveAs(Request.PhysicalApplicationPath + "/Librarian/Books_Pdf/" + Books_Pdf.ToString());
                path2 = "Books_Pdf/" + Books_Pdf.ToString();
            }

            if (f3.FileName.ToString() != "")
            {
                Books_Videos = Class1.GetRandomPassword(10) + ".mp4";

                f3.SaveAs(Request.PhysicalApplicationPath + "/Librarian/Books_Videos/" + Books_Videos.ToString());
                path3 = "Books_Videos/" + Books_Videos.ToString();
            }

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books values ('"+booksTitle.Text+"','"+path.ToString()+"','"+path2.ToString()+"','"+path3.ToString()+"','"+AuthorName.Text+"','"+ISBN.Text+"','"+Qty.Text+"') ";
            cmd.ExecuteNonQuery();

            msg.Style.Add("display", "block");
            

        }
    }
}