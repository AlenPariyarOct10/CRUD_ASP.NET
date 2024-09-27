using MySql.Data.MySqlClient;
using System;
using System.Web.UI;

namespace CRUD_App
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Semester { get; set; }

        public Student(string id, string name, string address, string semester)
        {
            Id = id;
            Name = name;
            Address = address;
            Semester = semester;
        }

        public Student() { }
    }

    public partial class DeleteUser : System.Web.UI.Page
    {

        protected void btn_delete_student(object sender, EventArgs e)
        {
            delete_student(HiddenRollNumber.Value.ToString());
            Response.Redirect("App.aspx?deleteSuccess=true");
        }

        protected void delete_student(string roll)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;password='';database=student_management_asp");
            conn.Open();
            string insertQuery = $"Delete from Students where roll={roll}";

            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);

            int status = cmd.ExecuteNonQuery();

            if (status > 0)
            {
                Output.Text = $"<div class='alert alert-success' role='alert'>Recorder deleted Succesfully</div>";
            }
            else
            {
                Output.Text = $"<div class='alert alert-danger' role='alert'>Failed to delete record</div>";

            }

            conn.Close();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request.QueryString["id"];

            if (string.IsNullOrEmpty(uid))
            {
                UserId.Text = "User ID is missing.";
                return;
            }

            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password='';database=student_management_asp"))
            {
                try
                {
                    conn.Open();

                    string selectRecordQuery = "SELECT * FROM Students WHERE roll = @uid";
                    using (MySqlCommand selectRecordCommand = new MySqlCommand(selectRecordQuery, conn))
                    {
                        selectRecordCommand.Parameters.AddWithValue("@uid", uid);

                        using (MySqlDataReader dataReader = selectRecordCommand.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                Student student = new Student
                                {
                                    Id = dataReader[1].ToString(),
                                    Name = dataReader[2].ToString(),
                                    Address = dataReader[3].ToString(),
                                    Semester = dataReader[4].ToString()
                                };

                                HiddenRollNumber.Value = student.Id;

                                UserId.Text = $" <tr>\r\n<th scope=\"col\">{student.Id}</th>\r\n<th scope=\"col\">{student.Name}</th>\r\n<th scope=\"col\">{student.Address}</th>\r\n<th scope=\"col\">{student.Semester}</th>\r\n</tr>";
                            }
                            else
                            {
                                UserId.Text = "No user found with the provided ID.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    UserId.Text = "An error occurred: " + ex.Message;
                }
            }
        }
    }
}
