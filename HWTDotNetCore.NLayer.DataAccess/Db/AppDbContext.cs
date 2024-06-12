using HWTDotNetCore.NLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using HWTDotNetCore.NLayer.DataAccess.Models;

namespace HWTDotNetCore.NLayer.DataAccess.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);//use sql server
    }//what connection do you use
    public DbSet<BlogModel> Blogs { get; set; } // ဘယ်tableကိုသုံးမှာလဲကြော်ငြာပေးရ(connect C# and database)
}
