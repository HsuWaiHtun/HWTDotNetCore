using HWTDotNetCore.PizzaApi;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWTDotNetCore.RestAPI.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);//use sql server
    }//what connection do you use
    public DbSet<PizzaModel> Pizzas { get; set; } // ဘယ်tableကိုသုံးမှာလဲကြော်ငြာပေးရ(connect C# and database)
    public DbSet<PizzaExtraModel> PizzasExtras { get; set; }
    public DbSet<PizzaOrderModel> PizzasOrders { get; set;}
    public DbSet<PizzaOrderDetailModel> PizzasOrdersDetail { get; set; }
}

[Table("Tbl_Pizza")]
public class PizzaModel
{
    [Key]
    [Column("PizzaId")]//want to use different name with table name in database
    public int Id { get; set; }
    [Column("Pizza")]
    public string Name { get; set; }
    public decimal Price { get; set; }
}

[Table("Tbl_PizzaExtra")]
public class PizzaExtraModel
{
    [Key]
    public int PizzaExtraId { get; set; }
    public string PizzaExtraName { get; set; }
    [Column("Price")]
    public decimal PizzaExtraPrice { get; set; }
    [NotMapped]
    public string PriceStr { get { return "$ " + PizzaExtraPrice; } }
}

public class OrderRequest
{
    public int PizzaId { get; set; }
    public int[] Extras { get; set; }
}

public class OrderResponse
{
    public string Message { get; set; }
    public string InvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }
}

[Table("Tbl_PizzaOrder")]
public class PizzaOrderModel
{
    [Key]
    public int PizzaOrderId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaId { get;set; }
    public decimal TotalAmount {  get; set; }
}

[Table("Tbl_PizzaOrderDetail")]
public class PizzaOrderDetailModel
{
    [Key]
    public int PizzaOrderDetailId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaExtraId { get; set; }
}

public class PizzaOrderInvoiceHeadModel
{
    public int PizzaOrderId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Pizza { get; set; }
    public decimal Price { get; set; }
}

public class PizzaOrderInvoiceDetailModel
{
    public int PizzaOrderDetailId { get; set; }
    public string PizzaOrderInvoiceNo { get; set; }
    public int PizzaExtraId { get; set; }
    public string PizzaExtraName { get; set; }
    public decimal Price { get; set; }
}

public class PizzaOrderInvoiceResponse
{
    public PizzaOrderInvoiceHeadModel Order { get; set; }
    public List<PizzaOrderInvoiceDetailModel> OrderDetail { get; set; }
}