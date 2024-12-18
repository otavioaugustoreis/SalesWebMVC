using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;
using SalesWebMVC.Data.Entity;
using SalesWebMVC.Models;
using SalesWebMVC.Models.DTO;
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
        private readonly IMapper _mapper;
        public SellersController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        //Caso não haja nenhum verbo ex: [HttpPost] o EntityFrameWork identifica o método 
        //[HttpGet]
        public async Task<ActionResult<SellerEntityDTOResponse>> Index()
        {
            var sellers = await _uof._Seller.FindAllAsync();

            var sellerDtoResponse = _mapper.Map<IEnumerable<SellerEntityDTOResponse>>(sellers);

            return View(sellerDtoResponse);
        }


        public ActionResult<SellerFormViewDTORequest> Create()
        {
            var departments = _uof._Department.Get();
            var viewModel = new SellerFormViewDTORequest()
            {
                Department = departments
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<SellerFormViewDTORequest> Create(SellerFormViewDTORequest sellerRequest)
        {
            try
            {
                if(sellerRequest is { Seller.Department: null, Seller.NrSalario: < 0 }) return RedirectToAction(nameof(Error), new { message = "Seller is not found" });

                var formRequest = sellerRequest.Seller;

                var seller = _mapper.Map<SellerEntity>(formRequest);
                
                if (ModelState.IsValid)
                {
                    IEnumerable<DepartmentEntity> departmentEntities = _uof._Department.Get();

                    var dtoResponse = _mapper.Map<SellerEntityDTORequest>(seller);

                    SellerFormViewDTORequest obj = new SellerFormViewDTORequest()
                    {
                        Seller = dtoResponse,
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


                var obj = _uof._Seller.loadingDepartament(p => p.Id == id);

                if (obj is null) return RedirectToAction(nameof(Error), new { message = "Seller is not found" });

                var dto = _mapper.Map<SellerEntityDTOResponse>(obj);

                return View(dto);
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Seller is not found" });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
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

        public ActionResult<SellerEntityDTOResponse> Details(int? id)

        {
            if (id < 0 || id is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });


            SellerEntity obj = _uof._Seller.loadingDepartament(p => p.Id == id);

            if (obj is null) return RedirectToAction(nameof(Error), new { message = "Seller not found" });


            var dto = _mapper.Map<SellerEntityDTOResponse>(obj);

            return View(dto);
        }

        public ActionResult Edit(int? id)
        {
            if (id is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });


            SellerEntity sr1 = _uof._Seller.GetId(p => p.Id == id);

            IEnumerable<DepartmentEntity> departmentEntities = _uof._Department.Get();

            var sellerDto = _mapper.Map<SellerEntityDTOResponse>(sr1);

            SellerFormViewDTOResponse obj = new SellerFormViewDTOResponse()
            {
                Seller = sellerDto,
                Department = departmentEntities
            };

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<SellerFormViewDTORequest> Edit(int? id, SellerEntityDTORequest sellerEntity)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<DepartmentEntity> departmentEntities = _uof._Department.Get();

                SellerFormViewDTORequest obj = new SellerFormViewDTORequest()
                {
                    Seller = sellerEntity,
                    Department = departmentEntities
                };

                return View(obj);
            }
            
            var seller = _mapper.Map<SellerEntity>(sellerEntity);

            if (id != seller.Id) BadRequest();

            try
            {
                _uof._Seller.Put(seller);
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




        public ActionResult Error(string message = "Deu erro")
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
