using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Models.DTO;
using SalesWebMVC.Models.Exceptions;
using SalesWebMVC.UnitOfWork;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public ActionResult<ProductDTO> Create()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<ProductDTO> Create(ProductDTO productDTO)
        {
            try
            {
                if (productDTO is { DsNome: "", Quantity : 0})
                {
                    return RedirectToAction(nameof(Error), new { message = "Seller is not found" });
                }

                var product = _mapper.Map<ProductEntity>(productDTO);

                _uof._Product.Post(product);
                _uof.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Product is not found" });
            }
        }

    }
}
