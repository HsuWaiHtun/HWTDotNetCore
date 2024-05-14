using HWTDotNetCore.RestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HWTDotNetCore.RestAPI.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);//use sql server
    }//what connection do you use
    public DbSet<BlogModel> Blogs { get; set; } // ဘယ်tableကိုသုံးမှာလဲကြော်ငြာပေးရ(connect C# and database)
}
