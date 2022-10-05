using System;
using System.Windows.Forms;
using WebServices_Lab06Model;

namespace Lab06_Client.Forms
{
    public partial class CreateStudent : Form
    {
        public CreateStudent()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var studentName = StudentNameTextBox.Text;
            if (string.IsNullOrEmpty(studentName) || string.IsNullOrWhiteSpace(studentName))
            {
                return;
            }

            var student = new Student
            {
                name = studentName,
            };
            DataSource.Client.AddToStudents(student);
            DataSource.Client.SaveChanges();

            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}