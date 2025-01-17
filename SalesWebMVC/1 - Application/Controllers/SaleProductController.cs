using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models.DTO;
using SalesWebMVC.UnitOfWork;

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


        [HttpPost]
        public ActionResult<SaleProductDTO> Create(SaleProductDTO saleProductDTO)
        {
            //Fazer lógica para receber a procedure
            return View();
        }
    }
}
