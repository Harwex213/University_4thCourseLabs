using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab06_Client.Forms;
using WebServices_Lab06Model;

namespace Lab06_Client
{
    public class StudentProxy
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }

        public StudentProxy(long id, string name)
        {
            Id = id;
            Name = name;
            Display = id + ", " + name;
        }
    }
    
    public class NoteProxy
    {
        public long Id { get; set; }
        public string Subj { get; set; }
        public long StudentId { get; set; }
        public int Note { get; set; }
        public string Display { get; set; }

        public NoteProxy(long id, long studentId, int note, string subj)
        {
            Id = id;
            Subj = subj;
            StudentId = studentId;
            Note = note;
            Display = subj + ": оценка " + note;
        }
    }

    public partial class Main : Form
    {
        private StudentProxy SetStudentsProxy()
        {
            StudentsListBox.SelectedIndexChanged -= StudentsListBox_SelectedIndexChanged;
            
            var students = DataSource.Client.Students.Select(s => new StudentProxy(s.id, s.name)).ToList();
            StudentsListBox.DataSource = students;
            StudentsListBox.DisplayMember = "Display";
            StudentsListBox.ValueMember = "Id";
            StudentsListBox.SelectedIndex = 0;
            
            StudentsListBox.SelectedIndexChanged += StudentsListBox_SelectedIndexChanged;

            return students.FirstOrDefault();
        }

        private void SetNotesProxy(StudentProxy student)
        {
            var notes = DataSource.Client.Notes.Where(n => n.studentId == student.Id)
                .Select(n => new NoteProxy(n.id, n.studentId, n.note, n.subj)).ToList();
            
            if (notes.Count == 0)
            {
                NotesListBox.DataSource = null;
                return;
            }
            
            NotesListBox.SelectedIndexChanged -= NotesListBox_SelectedIndexChanged;
            NotesListBox.DataSource = notes;
            NotesListBox.DisplayMember = "Display";
            NotesListBox.ValueMember = "Id";
            NotesListBox.SelectedIndex = 0;
            NotesListBox.SelectedIndexChanged += NotesListBox_SelectedIndexChanged;
        }

        public Main()
        {
            InitializeComponent();
            
            StudentsListBox.SelectedIndexChanged += StudentsListBox_SelectedIndexChanged;
            NotesListBox.SelectedIndexChanged += NotesListBox_SelectedIndexChanged;
            
            var studentProxy =  SetStudentsProxy();
            SetNotesProxy(studentProxy);
        }

        private void StudentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var studentProxy = StudentsListBox.SelectedItem as StudentProxy;
            SetNotesProxy(studentProxy);
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var createForm = new CreateStudent();
            createForm.ShowDialog();

            var studentProxy =  SetStudentsProxy();
            SetNotesProxy(studentProxy);
        }

        private void UpdateStudentBtn_Click(object sender, EventArgs e)
        {
            var student = StudentsListBox.SelectedItem as StudentProxy;
            var updateForm = new UpdateStudent(student);
            updateForm.ShowDialog();

            var studentProxy =  SetStudentsProxy();
            SetNotesProxy(studentProxy);
        }

        private void DeleteStudentBtn_Click(object sender, EventArgs e)
        {
            var studentProxy = StudentsListBox.SelectedItem as StudentProxy;
            var student = DataSource.Client.Students.Where(s => s.id == studentProxy.Id).FirstOrDefault();
            if (student == null)
            {
                return;
            }
            
            var notes = DataSource.Client.Notes.Where(n => n.studentId == student.id).ToList();
            if (notes.Count != 0)
            {
                NotesListBox.DataSource = null;
                
                foreach (var note in notes)
                {
                    DataSource.Client.DeleteObject(note);
                }
            }
            DataSource.Client.SaveChanges();
            
            DataSource.Client.DeleteObject(student);
            DataSource.Client.SaveChanges();
            
            var studentProxy1 =  SetStudentsProxy();
            SetNotesProxy(studentProxy1);
        }

        private void CreateNoteBtn_Click(object sender, EventArgs e)
        {
            var studentProxy = StudentsListBox.SelectedItem as StudentProxy;
            var createForm = new CreateNote(studentProxy);
            createForm.ShowDialog();
            
            SetNotesProxy(studentProxy);
        }

        private void UpdateNoteBtn_Click(object sender, EventArgs e)
        {
            var studentProxy = StudentsListBox.SelectedItem as StudentProxy;
            var noteProxy = NotesListBox.SelectedItem as NoteProxy;
            var updateForm = new UpdateNote(studentProxy, noteProxy);
            updateForm.ShowDialog();
            
            SetNotesProxy(studentProxy);
        }

        private void DeleteNoteBtn_Click(object sender, EventArgs e)
        {
            var studentProxy = StudentsListBox.SelectedItem as StudentProxy;
            var noteProxy = NotesListBox.SelectedItem as NoteProxy;
            var noteRecord = DataSource.Client.Notes.Where(s => s.id == noteProxy.Id).FirstOrDefault();
            if (noteRecord == null)
            {
                return;
            }

            DataSource.Client.DeleteObject(noteRecord);
            DataSource.Client.SaveChanges();
            
            SetNotesProxy(studentProxy);
        }
    }
}
