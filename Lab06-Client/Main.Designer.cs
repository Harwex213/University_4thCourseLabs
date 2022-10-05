namespace Lab06_Client
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StudentsListBox = new System.Windows.Forms.ListBox();
            this.NotesListBox = new System.Windows.Forms.ListBox();
            this.CreateNoteBtn = new System.Windows.Forms.Button();
            this.UpdateNoteBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.UpdateStudentBtn = new System.Windows.Forms.Button();
            this.DeleteNoteBtn = new System.Windows.Forms.Button();
            this.DeleteStudentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StudentsListBox
            // 
            this.StudentsListBox.FormattingEnabled = true;
            this.StudentsListBox.ItemHeight = 16;
            this.StudentsListBox.Location = new System.Drawing.Point(12, 12);
            this.StudentsListBox.Name = "StudentsListBox";
            this.StudentsListBox.Size = new System.Drawing.Size(325, 404);
            this.StudentsListBox.TabIndex = 1;
            // 
            // NotesListBox
            // 
            this.NotesListBox.FormattingEnabled = true;
            this.NotesListBox.ItemHeight = 16;
            this.NotesListBox.Location = new System.Drawing.Point(475, 12);
            this.NotesListBox.Name = "NotesListBox";
            this.NotesListBox.Size = new System.Drawing.Size(325, 404);
            this.NotesListBox.TabIndex = 2;
            // 
            // CreateNoteBtn
            // 
            this.CreateNoteBtn.Location = new System.Drawing.Point(806, 12);
            this.CreateNoteBtn.Name = "CreateNoteBtn";
            this.CreateNoteBtn.Size = new System.Drawing.Size(101, 33);
            this.CreateNoteBtn.TabIndex = 3;
            this.CreateNoteBtn.Text = "Create Note";
            this.CreateNoteBtn.UseVisualStyleBackColor = true;
            this.CreateNoteBtn.Click += new System.EventHandler(this.CreateNoteBtn_Click);
            // 
            // UpdateNoteBtn
            // 
            this.UpdateNoteBtn.Location = new System.Drawing.Point(806, 51);
            this.UpdateNoteBtn.Name = "UpdateNoteBtn";
            this.UpdateNoteBtn.Size = new System.Drawing.Size(101, 33);
            this.UpdateNoteBtn.TabIndex = 4;
            this.UpdateNoteBtn.Text = "Update Note";
            this.UpdateNoteBtn.UseVisualStyleBackColor = true;
            this.UpdateNoteBtn.Click += new System.EventHandler(this.UpdateNoteBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(343, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 33);
            this.button3.TabIndex = 5;
            this.button3.Text = "Create Student";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UpdateStudentBtn
            // 
            this.UpdateStudentBtn.Location = new System.Drawing.Point(343, 51);
            this.UpdateStudentBtn.Name = "UpdateStudentBtn";
            this.UpdateStudentBtn.Size = new System.Drawing.Size(126, 33);
            this.UpdateStudentBtn.TabIndex = 6;
            this.UpdateStudentBtn.Text = "Update Student";
            this.UpdateStudentBtn.UseVisualStyleBackColor = true;
            this.UpdateStudentBtn.Click += new System.EventHandler(this.UpdateStudentBtn_Click);
            // 
            // DeleteNoteBtn
            // 
            this.DeleteNoteBtn.Location = new System.Drawing.Point(806, 90);
            this.DeleteNoteBtn.Name = "DeleteNoteBtn";
            this.DeleteNoteBtn.Size = new System.Drawing.Size(101, 33);
            this.DeleteNoteBtn.TabIndex = 7;
            this.DeleteNoteBtn.Text = "Delete Note";
            this.DeleteNoteBtn.UseVisualStyleBackColor = true;
            this.DeleteNoteBtn.Click += new System.EventHandler(this.DeleteNoteBtn_Click);
            // 
            // DeleteStudentBtn
            // 
            this.DeleteStudentBtn.Location = new System.Drawing.Point(343, 90);
            this.DeleteStudentBtn.Name = "DeleteStudentBtn";
            this.DeleteStudentBtn.Size = new System.Drawing.Size(126, 33);
            this.DeleteStudentBtn.TabIndex = 8;
            this.DeleteStudentBtn.Text = "Delete Student";
            this.DeleteStudentBtn.UseVisualStyleBackColor = true;
            this.DeleteStudentBtn.Click += new System.EventHandler(this.DeleteStudentBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 437);
            this.Controls.Add(this.DeleteStudentBtn);
            this.Controls.Add(this.DeleteNoteBtn);
            this.Controls.Add(this.UpdateStudentBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.UpdateNoteBtn);
            this.Controls.Add(this.CreateNoteBtn);
            this.Controls.Add(this.NotesListBox);
            this.Controls.Add(this.StudentsListBox);
            this.Name = "Main";
            this.Text = "Super GUI UI ultra 3000 nano XXX-9";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox StudentsListBox;
        private System.Windows.Forms.ListBox NotesListBox;
        private System.Windows.Forms.Button CreateNoteBtn;
        private System.Windows.Forms.Button UpdateNoteBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button UpdateStudentBtn;
        private System.Windows.Forms.Button DeleteNoteBtn;
        private System.Windows.Forms.Button DeleteStudentBtn;
    }
}

