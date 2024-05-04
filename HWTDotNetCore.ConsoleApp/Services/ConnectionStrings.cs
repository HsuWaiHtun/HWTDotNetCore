using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWTDotNetCore.ConsoleApp.Services
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "RV-IT-LP-202",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa@12345",
            TrustServerCertificate = true,
        };
    }
}
