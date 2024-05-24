namespace HWTDotNetCore.PizzaApi.Queries
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } =
            @"SELECT po.*,p.Pizza,p.Price  FROM [Tbl_PizzaOrder] po 
              inner join [Tbl_Pizza] p on po.PizzaId = p.PizzaId
              Where Po.PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo
            ";

        public static string PizzaOrderDetailQuery { get; } =
            @"SELECT pod.*,pe.PizzaExtraName,pe.Price  FROM [Tbl_PizzaOrderDetail] pod 
              inner join [Tbl_PizzaExtra] pe on pod.PizzaExtraId = pe.PizzaExtraId
              Where Pod.PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo
            ";
    }
}
