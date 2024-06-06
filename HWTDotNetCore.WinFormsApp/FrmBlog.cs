using HWTDotNetCore.Shared;
using HWTDotNetCore.WinFormsApp.Models;
using HWTDotNetCore.WinFormsApp.Queries;
using System.Data.SqlClient;
using System.Data;

namespace HWTDotNetCore.WinFormsApp
{
    public partial class FrmBlog : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _blogId;

        public FrmBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        public FrmBlog(int blogId)
        {
            InitializeComponent();
            _blogId = blogId;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            var model = _dapperService.QueryFirstOrDefault<BlogModel>("Select * from tbl_blog where BlogId = @BlogId", new { blogId = _blogId });
            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        private void clearControl()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = txtTitle.Text,
                    BlogAuthor = txtAuthor.Text,
                    BlogContent = txtContent.Text,
                };

                int result = _dapperService.Execute(BlogQuery.BlogCreate, blog);
                string message = result > 0 ? "Saving Successful" : "Saving fail";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                if (result > 0) clearControl();
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId = @BlogId";
            BlogModel item = new BlogModel()
            {
                BlogId = _blogId,
                BlogTitle = txtTitle.Text,
                BlogAuthor = txtAuthor.Text,
                BlogContent = txtContent.Text,
            };

            int result = _dapperService.Execute(query, item);
            string message = result > 0 ? "Updating successful" : "Updating fail";
            MessageBox.Show(message);
            this.Close();
        }
    }
}
