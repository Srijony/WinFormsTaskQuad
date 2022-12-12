using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTaskQuad.Model;
using WinFormsTaskQuad.SchoolDAL;

namespace WinFormsTaskQuad
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            StudentDAO studentDAO = new StudentDAO();
            List<Student> studentlist = studentDAO.getAllstudents();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = studentlist;

            comboBox1.DataSource = bindingSource1.DataSource;

            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var selectedStudent = (Student)comboBox1.SelectedItem;
            StudentDAO studentDAO = new StudentDAO();
            Student std= studentDAO.getStudent(selectedStudent);

            textBoxId.Text = std.id.ToString();
            textBoxName.Text = std.name.ToString();

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
        }

        private void EXEbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Process.Start(@"D:\Srijjony\newexe\NewExe.exe");
        }
    }
}
