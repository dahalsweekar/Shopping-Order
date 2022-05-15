using Make_Orders.Data;
using Make_Orders.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Make_Orders.Controllers
{


    public class HomeController : Controller
    {



        private readonly ILogger<HomeController> _logger;

        private Make_OrdersContext _dbContext;
        public HomeController(ILogger<HomeController> logger, Make_OrdersContext dbcontext)
        {
            _logger = logger;
            //Initialization of context
            _dbContext = dbcontext;
            //Initialization of Models

        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Hello(Orders order, List<Items> items)
        {

            return View();
        }
        public async Task<IActionResult> Main(Orders order, List<Items> items)
        {

            /*ViewBag.OrderName = order.Name;
            ViewBag.Description = order.Description;
            ViewBag.ItemName = item.ItemsName;
            ViewBag.Item_type = item.Item_type;
            ViewBag.Rate = item.Rate;*/

            if (order.Name != null && items.Count != 0)
            {
                _dbContext.Add(order);
                await _dbContext.SaveChangesAsync();
                for (var i = 0; i < items.Count; i++)
                {
                    items[i].OrdersID = order.OrdersID;

                }
                return RedirectToAction("FinalView");
            }

            return View("Main");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult FinalView()
        {
            Common x = new Common();
            x.item = _dbContext.Items.ToList();
            x.order = _dbContext.Orders.ToList();
            return View(x);
        }
    }
}