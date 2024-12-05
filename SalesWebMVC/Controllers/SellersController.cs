using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Models.Services;
using SalesWebMVC.UnitOfWork;



namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly IUnitOfWork _uof;

        public SellersController(IUnitOfWork uof)
        {
            _uof = uof;
        }


        public IActionResult Index()
        {
            var sellers = _uof._Seller.Get();

            return View(sellers);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SellerEntity seller)
        {
            _uof._Seller.Post(seller);
            _uof.Commit();
            //Redirecionar a alão
            return RedirectToAction(nameof(Index));
        }


    }
}
