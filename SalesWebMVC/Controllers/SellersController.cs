using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Models.Services;
using SalesWebMVC.UnitOfWork;
//using SalesWebMVC.Views.ViewsModel;



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
            var departments = _uof._Department.Get();
            var viewModel = new SellerFormViewModel()
            {
                Department = departments
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SellerEntity seller)
        {
            _uof._Seller.Post(seller);
            _uof.Commit();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id < 0 || id is null)  NotFound();

            var obj = _uof._Seller.GetId(p => p.Id == id);

            if (obj is null) NotFound();

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            SellerEntity sr = _uof._Seller.GetId(p => p.Id == id);

            _uof._Seller.Delete(sr);
            _uof.Commit();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id < 0 || id is null) NotFound();

            SellerEntity obj = _uof._Seller.loadingDepartament(p => p.Id == id);

            if (obj is null) NotFound();

            return View(obj);
        }

    }
}
