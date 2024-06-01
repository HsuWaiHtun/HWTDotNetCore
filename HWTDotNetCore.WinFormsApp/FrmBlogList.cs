using HWTDotNetCore.Shared;
using HWTDotNetCore.WinFormsApp.Models;
using HWTDotNetCore.WinFormsApp.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HWTDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlogList()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogList);
            dgvData.DataSource = lst;
        }
    }
}
