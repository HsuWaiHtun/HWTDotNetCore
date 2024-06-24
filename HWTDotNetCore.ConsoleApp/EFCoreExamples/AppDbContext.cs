using HWTDotNetCore.ConsoleApp.Dtos;
using HWTDotNetCore.ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWTDotNetCore.ConsoleApp.EFCoreExamples;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);//use sql server
    //}//what connection do you use
    public DbSet<BlogDto> Blogs { get; set; } // ဘယ်tableကိုသုံးမှာလဲကြော်ငြာပေးရ(connect C# and database)
}
