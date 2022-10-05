using System;
using System.Windows.Forms;
using WebServices_Lab06Model;

namespace Lab06_Client.Forms
{
    public partial class CreateNote : Form
    {
        private StudentProxy _studentProxy;
        
        public CreateNote(StudentProxy studentProxy)
        {
            _studentProxy = studentProxy;
            
            InitializeComponent();

            StudentLabel.Text = "Create note for Student: " + studentProxy.Display;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var subjectName = SubjectTextBox.Text;
            if (string.IsNullOrEmpty(subjectName) || string.IsNullOrWhiteSpace(subjectName))
            {
                return;
            }

            var note = int.Parse(NoteTextBox.Text);

            var noteRecord = new Note
            {
                subj = subjectName,
                note = note,
                studentId = _studentProxy.Id,
            };
            DataSource.Client.AddToNotes(noteRecord);
            DataSource.Client.SaveChanges();

            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}