using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab06_Client.Forms
{
    public partial class UpdateNote : Form
    {
        private NoteProxy _noteProxy;
        
        public UpdateNote(StudentProxy studentProxy, NoteProxy noteProxy)
        {
            _noteProxy = noteProxy;
            
            InitializeComponent();

            StudentLabel.Text = "Update Note for student: " + studentProxy.Display;
            NoteLabel.Text = "Note ID: " + noteProxy.Display;
            SubjectTextBox.Text = noteProxy.Subj;
            NoteTextBox.Text = noteProxy.Note.ToString();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            var subjectName = SubjectTextBox.Text;
            if (string.IsNullOrEmpty(subjectName) || string.IsNullOrWhiteSpace(subjectName))
            {
                return;
            }
            var note = int.Parse(NoteTextBox.Text);

            var noteRecord = DataSource.Client.Notes.Where(n => n.id == _noteProxy.Id).FirstOrDefault();
            if (noteRecord == null)
            {
                return;
            }

            noteRecord.subj = subjectName;
            noteRecord.note = note;
            DataSource.Client.UpdateObject(noteRecord);
            DataSource.Client.SaveChanges();

            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}