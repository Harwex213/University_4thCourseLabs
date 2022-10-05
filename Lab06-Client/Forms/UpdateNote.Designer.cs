using System.ComponentModel;

namespace Lab06_Client.Forms
{
    partial class UpdateNote
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
            this.StudentLabel = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.NoteLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StudentLabel
            // 
            this.StudentLabel.Location = new System.Drawing.Point(12, 13);
            this.StudentLabel.Name = "StudentLabel";
            this.StudentLabel.Size = new System.Drawing.Size(655, 23);
            this.StudentLabel.TabIndex = 19;
            this.StudentLabel.Text = "Create note for Student: ";
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(12, 117);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(100, 23);
            this.label.TabIndex = 18;
            this.label.Text = "Note";
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Location = new System.Drawing.Point(12, 143);
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(100, 22);
            this.NoteTextBox.TabIndex = 17;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(135, 171);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(121, 49);
            this.CancelBtn.TabIndex = 16;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(8, 171);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(121, 49);
            this.UpdateBtn.TabIndex = 15;
            this.UpdateBtn.Text = "Create";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Subject";
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(12, 88);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(100, 22);
            this.SubjectTextBox.TabIndex = 13;
            // 
            // NoteLabel
            // 
            this.NoteLabel.Location = new System.Drawing.Point(12, 39);
            this.NoteLabel.Name = "NoteLabel";
            this.NoteLabel.Size = new System.Drawing.Size(100, 23);
            this.NoteLabel.TabIndex = 20;
            this.NoteLabel.Text = "Note ID: ";
            // 
            // UpdateNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NoteLabel);
            this.Controls.Add(this.StudentLabel);
            this.Controls.Add(this.label);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SubjectTextBox);
            this.Name = "UpdateNote";
            this.Text = "UpdateNote";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label StudentLabel;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubjectTextBox;
        private System.Windows.Forms.Label NoteLabel;

        #endregion
    }
}