
namespace HWTDotNetCore.WinFormsApp
{
    partial class FrmBlog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            Title = new Label();
            Author = new Label();
            Content = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(125, 43);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(335, 29);
            txtTitle.TabIndex = 0;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(125, 100);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(335, 29);
            txtAuthor.TabIndex = 1;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(125, 166);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(335, 52);
            txtContent.TabIndex = 2;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Location = new Point(125, 18);
            Title.Name = "Title";
            Title.Size = new Size(43, 22);
            Title.TabIndex = 3;
            Title.Text = "Title :";
            // 
            // Author
            // 
            Author.AutoSize = true;
            Author.Location = new Point(125, 75);
            Author.Name = "Author";
            Author.Size = new Size(61, 22);
            Author.TabIndex = 3;
            Author.Text = "Author :";
            // 
            // Content
            // 
            Content.AutoSize = true;
            Content.Location = new Point(125, 141);
            Content.Name = "Content";
            Content.Size = new Size(69, 22);
            Content.TabIndex = 3;
            Content.Text = "Content :";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(237, 233);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(108, 42);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ControlDark;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(125, 233);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 42);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Teal;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = SystemColors.Control;
            btnUpdate.Location = new Point(237, 233);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(108, 42);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(7F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 525);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(Content);
            Controls.Add(Author);
            Controls.Add(Title);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Font = new Font("Zawgyi-One", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Label Title;
        private Label Author;
        private Label Content;
        private Button btnSave;
        private Button btnCancel;
        private Button btnUpdate;
    }
}
