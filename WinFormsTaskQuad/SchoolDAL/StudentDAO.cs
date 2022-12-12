using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTaskQuad.Model;

namespace WinFormsTaskQuad.SchoolDAL
{
    public class StudentDAO
    {
        private string con { get; set; }
        private SqlConnection connection { get; set; } = new();

        public StudentDAO()
        {
            con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            //MessageBox.Show(con);
            connection = new SqlConnection(con);
        }
        public List<Student> getAllstudents()
        {
            List<Student> students = new List<Student>();
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                string query = "SELECT * FROM STUDENTS";

                SqlCommand sql = new SqlCommand(query, connection);

                SqlDataReader reader = sql.ExecuteReader();


                while (reader.Read())
                {
                    Student student = new Student();
                    student.id = (int)reader["id"];
                    student.name = reader["name"].ToString();
                    students.Add(student);

                }

                dispose();

            }
            return students;
        }
        public Student getStudent(Student student)
        {
            List<Student> students = new List<Student>();
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                string query = "SELECT * FROM STUDENTS WHERE id= " + student.id;

                SqlCommand sql = new SqlCommand(query, connection);

                SqlDataReader reader = sql.ExecuteReader();


                while (reader.Read())
                {
                    Student studentobj = new Student();
                    studentobj.id = (int)reader["id"];
                    studentobj.name = reader["name"].ToString();
                    students.Add(student);

                }



                dispose();

            }
            return students.FirstOrDefault();
        }

        public void dispose()
        {
            connection.Close();
        }

    }
}
