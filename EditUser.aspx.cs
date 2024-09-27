using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_App
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Request.QueryString["id"];

        

            if (string.IsNullOrEmpty(uid))
            {
                OutValue.Text = "User ID is missing.";
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

                                rollNo.Text = student.Id;
                               
                             
                            }
                            else
                            {
                                OutValue.Text = "No user found with the provided ID.";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    OutValue.Text = "An error occurred: " + ex.Message;
                }
            }
        }

        protected void btn_edit_student(object sender, EventArgs e)
        {
            update_student(HiddenRollNumber.Value.ToString(), inputName.Text, inputAddress.Text, inputSemester.Text);
            Response.Redirect("App.aspx?updateSuccess=true");
           
        }

        protected void update_student(string roll, string name, string address, string semester)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;password='';database=student_management_asp");
            conn.Open();
            string insertQuery = $"UPDATE `students` SET `name`= '{name}',`address`= '{address}',`semester`= '{semester}' WHERE `roll`='{roll}'";
            
            MySqlCommand cmd = new MySqlCommand(insertQuery, conn);

            int status = cmd.ExecuteNonQuery();
            OutValue.Text += "Status " + roll+"<br>"+name+"<br>"+address+"<br>"+semester;
            conn.Close();

        }
    }
}