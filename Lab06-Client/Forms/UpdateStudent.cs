using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab06_Client.Forms
{
    public partial class UpdateStudent : Form
    {
        private StudentProxy _studentProxy;
        
        public UpdateStudent(StudentProxy studentProxy)
        {
            _studentProxy = studentProxy;
            
            InitializeComponent();

            StudentIdLabel.Text = @"Student ID: " + studentProxy.Id;
            StudentNameTextBox.Text = studentProxy.Name;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            var studentName = StudentNameTextBox.Text;
            if (string.IsNullOrEmpty(studentName) || string.IsNullOrWhiteSpace(studentName))
            {
                return;
            }

            var student = DataSource.Client.Students.Where(s => s.id == _studentProxy.Id).FirstOrDefault();
            if (student == null)
            {
                return;
            }

            student.name = studentName;
            DataSource.Client.UpdateObject(student);
            DataSource.Client.SaveChanges();

            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}