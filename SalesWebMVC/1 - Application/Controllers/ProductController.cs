using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Models.DTO;
using SalesWebMVC.UnitOfWork;

namespace SalesWebMVC._1___Application.Controllers
{
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public ActionResult<ProductDTO> Index()
        {
            var products = _uof._Product.Get();

            var productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return View(productsDTO);
        }


    }
}
