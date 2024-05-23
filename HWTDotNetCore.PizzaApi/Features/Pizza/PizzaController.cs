using HWTDotNetCore.RestAPI.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HWTDotNetCore.PizzaApi.Features.Pizza
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PizzaController()
        {
            _appDbContext = new AppDbContext();
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var lst = await _appDbContext.Pizzas.ToListAsync();
            return Ok(lst);
        }

        [HttpGet("Extras")]
        public async Task<IActionResult> GetExtrasAsync()
        {
            var lst = await _appDbContext.PizzasExtras.ToListAsync();
            return Ok(lst);
        }

        [HttpPost("Order")]
        public async Task<IActionResult> OrderAsync(OrderRequest orderRequest)
        {
            var itemPizza = await _appDbContext.Pizzas.FirstOrDefaultAsync(x => x.Id == orderRequest.PizzaId);
            var total = itemPizza.Price;

            if(orderRequest.Extras.Length > 0)
            {
                var lstExtras = await _appDbContext.PizzasExtras.Where(x=> orderRequest.Extras.Contains(x.PizzaExtraId)).ToListAsync();
                total += lstExtras.Sum(x => x.PizzaExtraPrice);
            }

            var invoiceNo = DateTime.Now.ToString("yyyyMMddHHmmss");
            PizzaOrderModel pizzaOrder = new PizzaOrderModel()
            {
                PizzaOrderInvoiceNo = invoiceNo,
                PizzaId = orderRequest.PizzaId,
                TotalAmount = total
            };

            List<PizzaOrderDetailModel> pizzaOrderDetail = orderRequest.Extras.Select(extraId => new PizzaOrderDetailModel()
            {
                PizzaOrderInvoiceNo = invoiceNo,
                PizzaExtraId = extraId
            }).ToList();

            await _appDbContext.PizzasOrders.AddAsync(pizzaOrder);
            await _appDbContext.PizzasOrdersDetail.AddRangeAsync(pizzaOrderDetail);
            await _appDbContext.SaveChangesAsync();

            OrderResponse response = new OrderResponse()
            {
                InvoiceNo = invoiceNo,
                Message = "Thank you for your order! Enjoy your pizza! ",
                TotalAmount = total
            };

            return Ok(response);
        }
    }
}
