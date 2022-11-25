using Microsoft.AspNetCore.Mvc;
using Mije.DataAccess.Repository.IRepository;
using Mije.Models;
using System.Diagnostics;

namespace Mijestore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _db;

        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Barang> BarangList = _db.Barang.GetAll(includeProperties: "Produk");
            return View(BarangList);
        }
        public IActionResult Details(int id)
        {
            ShoppingCart cartobj = new()
            {
                count = 1,
                barang = _db.Barang.GetFirstorDefault(u => u.Id == id, includeProperties: "Produk")
            };
            return View(cartobj);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}