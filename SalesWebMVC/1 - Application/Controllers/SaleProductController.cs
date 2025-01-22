using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Controllers;
using SalesWebMVC.Data.Enums;
using SalesWebMVC.Models.DTO;
using SalesWebMVC.Models.Exceptions;
using SalesWebMVC.UnitOfWork;
using System.Security.Cryptography.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalesWebMVC._1___Application.Controllers
{
    public class SaleProductController : Controller
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public SaleProductController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public ActionResult<SaleProductDTO> Create()
        {
            var viewModel = new SaleProductDTO()
            {
                ProductEntity = _uof._Product.Get(),
                SellerEntity = _uof._Seller.Get()
            };

            return View(viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult<SaleProductDTO> Create(SaleProductDTO saleProductDTO)
        {
            try
            {   
                if (saleProductDTO is null ||saleProductDTO is
                                               {
                                                   IdCLiente :  <= 0,
                                                   IdProduto: <= 0
                                               })
                {
                    return RedirectToAction(nameof(Error), new { message = "SaleProduct is not found" });
                }

                _uof._SaleProduct.GenerateSale(saleProductDTO.IdCLiente, saleProductDTO.IdProduto, SaleStatus.BILLED);

                return RedirectToAction(nameof(Index), "SalesRecords");
            }                             //A exceção só vai ser capturada caso o when seja verdadeiro
            catch (IntegrityException e) when (e.Message.Contains("Critical"))
            {
                return RedirectToAction(nameof(Error), new { message = "SaleProduct is not found" });
            }
        }
    }
}
