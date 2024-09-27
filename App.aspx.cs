using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace CRUD_App
{
    public partial class App : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        protected void Load_Data()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;password='';database=student_management_asp");
            conn.Open();

            string selectAll = "SELECT * FROM students";

            MySqlCommand selectCommand = new MySqlCommand(selectAll, conn);

            MySqlDataReader dataReader = selectCommand.ExecuteReader();

            string allData = "";

            while (dataReader.Read())
            {
                //allData += $"<tr>\r\n<th scope=\"row\">{dataReader[0]}</th>\r\n<td>{dataReader[1]}</td>\r\n<td>{dataReader[2]}</td>\r\n<td>{dataReader[3]}</td>\r\n<td>{dataReader[4]}</td>\r\n<td>\r\n<button type=\"button\" class=\"btn btn-primary btn-sm\">Edit</button>\r\n<buttozn type=\"button\" data-bs-toggle=\"modal\" data-bs-target=\"#deleteModal\" {runat="server"} {OnClick="btn_select_to_delete"} class=\"btn btn-danger btn-sm\">Delete</button>\r\n</td>\r\n</tr>";
                allData += $"<tr>\r\n" +
             $"<th scope=\"row\">{dataReader[0]}</th>\r\n" +
             $"<td>{dataReader[1]}</td>\r\n" +
             $"<td>{dataReader[2]}</td>\r\n" +
             $"<td>{dataReader[3]}</td>\r\n" +
             $"<td>{dataReader[4]}</td>\r\n" +
             $"<td>\r\n" +
             $"<a type=\"button\" href=\"EditUser.aspx?id={dataReader[1]}\" class=\"btn btn-primary btn-sm\">Edit</a>\r\n" +
             $"<a type=\"button\" href=\"DeleteUser.aspx?id={dataReader[1]}\" class=\"btn btn-danger btn-sm\">Delete</a>\r\n" +
             $"</td>\r\n" +
             $"</tr>";

            }

            TableOut.Text = allData;

            string isDeleted = Request.QueryString["deleteSuccess"];
            string isUpdated = Request.QueryString["updateSuccess"];


            if (isDeleted=="true")
            {
                TableOut.Text += $"<div class=\"alert alert-danger\" role=\"alert\">\r\n Record deleted succesfully!\r\n</div>";
            }

            if (isUpdated == "true")
            {
                TableOut.Text += $"<div class=\"alert alert-success\" role=\"alert\">\r\n Record updated succesfully!\r\n</div>";
            }

            conn.Close();
        }

        protected void btn_add_student(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;password='';database=student_management_asp");
            conn.Open();
            string insertQuery = $"INSERT INTO `students`(`roll`, `name`, `address`, `semester`) VALUES ('{rollNo.Text}','{inputName.Text}','{inputAddress.Text}','{inputSemester.Text}')";

            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);

            int status = cmd.ExecuteNonQuery();

            if(status>0)
            {
                Output.Text = $"<div class='alert alert-success' role='alert'>Recorder Added Succesfully</div>";
            }
            else
            {
                Output.Text = $"<div class='alert alert-danger' role='alert'>Failed to Add record</div>";

            }

            conn.Close();

            Load_Data();
        }

        protected void btn_select_to_delete(object sender, EventArgs e)
        {

        }

        protected void btn_delete_student(object sender, EventArgs e)
        {

        }
    }
}