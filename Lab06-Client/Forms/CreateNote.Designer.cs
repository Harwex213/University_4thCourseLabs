using System.ComponentModel;

namespace Lab06_Client.Forms
{
    partial class CreateNote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelBtn = new System.Windows.Forms.Button();
            this.CreateBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.StudentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(135, 144);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(121, 49);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CreateBtn
            // 
            this.CreateBtn.Location = new System.Drawing.Point(8, 144);
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(121, 49);
            this.CreateBtn.TabIndex = 8;
            this.CreateBtn.Text = "Create";
            this.CreateBtn.UseVisualStyleBackColor = true;
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Subject";
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(12, 61);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(100, 22);
            this.SubjectTextBox.TabIndex = 6;
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(12, 90);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(100, 23);
            this.label.TabIndex = 11;
            this.label.Text = "Note";
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Location = new System.Drawing.Point(12, 116);
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(100, 22);
            this.NoteTextBox.TabIndex = 10;
            // 
            // StudentLabel
            // 
            this.StudentLabel.Location = new System.Drawing.Point(12, 9);
            this.StudentLabel.Name = "StudentLabel";
            this.StudentLabel.Size = new System.Drawing.Size(655, 23);
            this.StudentLabel.TabIndex = 12;
            this.StudentLabel.Text = "Create note for Student: ";
            // 
            // CreateNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StudentLabel);
            this.Controls.Add(this.label);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CreateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SubjectTextBox);
            this.Name = "CreateNote";
            this.Text = "CreateNote";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label StudentLabel;

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button CreateBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubjectTextBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox NoteTextBox;

        #endregion
    }
}