using Dapper;
using HWTDotNetCore.Shared;
using HWTDotNetCore.WinFormsApp.Models;
using HWTDotNetCore.WinFormsApp.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWTDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        //private const int _edit = 1;
        //private const int _delete = 2;
        public FrmBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }
        
        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogList);
            dgvData.DataSource = lst;
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;

            if (e.RowIndex == -1) { return; }
            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);
            
            if(colIndex == (int)EnumFormControlType.Edit)
            {
                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();
                BlogList();
            }
            else if(colIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                
                DeleteBlog(blogId);
            }

            //EnumFormControlType enumForm = EnumFormControlType.None;
            //switch(enumForm)
            //{
            //    case EnumFormControlType.None:
            //        break;
            //    case EnumFormControlType.Delete:
            //        break;
            //    case EnumFormControlType.Edit:
            //        break;
            //}
        }

        private void DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                            WHERE BlogId = @BlogId";

            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Deleting successful" : "Deleting fail";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
