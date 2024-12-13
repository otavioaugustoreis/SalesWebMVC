using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Exceptions;
using SalesWebMVC.Models.Services;
using SalesWebMVC.UnitOfWork;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
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


        public async Task<IActionResult> Index()
        {
            var sellers = await _uof._Seller.FindAllAsync();

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
            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<DepartmentEntity> departmentEntities = _uof._Department.Get();

                    SellerFormViewModel obj = new SellerFormViewModel()
                    {
                        Seller = seller,
                        Department = departmentEntities
                    };

                    return View(obj);
                }


                _uof._Seller.Post(seller);
                _uof.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller is not found" });
            }
        }

        public IActionResult Delete(int? id)
        {
            try
            {
                if (id < 0 || id is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });


                var obj = _uof._Seller.GetId(p => p.Id == id);

                if (obj is null) return RedirectToAction(nameof(Error), new { message = "Seller is not found" });


                return View(obj);
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller is not found" });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                SellerEntity sr = _uof._Seller.GetId(p => p.Id == id);

                _uof._Seller.Delete(sr);
                _uof.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Details(int? id)
        {
            if (id < 0 || id is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });


            SellerEntity obj = _uof._Seller.loadingDepartament(p => p.Id == id);

            if (obj is null) return RedirectToAction(nameof(Error), new { message = "Seller not found" });


            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });


            SellerEntity sr1 = _uof._Seller.GetId(p => p.Id == id);

            IEnumerable<DepartmentEntity> departmentEntities = _uof._Department.Get();

            SellerFormViewModel obj = new SellerFormViewModel()
            {
                Seller = sr1,
                Department = departmentEntities
            };

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, SellerEntity sellerEntity)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<DepartmentEntity> departmentEntities = _uof._Department.Get();

                SellerFormViewModel obj = new SellerFormViewModel()
                {
                    Seller = sellerEntity,
                    Department = departmentEntities
                };

                return View(obj);
            }

            if (id != sellerEntity.Id) BadRequest();

            try
            {
                _uof._Seller.Put(sellerEntity);
                _uof.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch (DBConcurrencyException d)
            {
                return RedirectToAction(nameof(Error), new { message = d.Message });
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }




        public IActionResult Error(string message = "Deu erro")
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            };

            return View(viewModel);
        }

    }
}
