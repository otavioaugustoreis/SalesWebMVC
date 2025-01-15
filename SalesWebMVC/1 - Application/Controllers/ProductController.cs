using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using SalesWebMVC._3___Data.Entity;
using SalesWebMVC.Data.Entity;
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



        public IActionResult Delete(int? id)
        {
            try
            {
                if (id < 0 || id is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });


                var obj = _uof._Product.GetId(p => p.Id == id);

                if (obj is null) return RedirectToAction(nameof(Error), new { message = "Product is not found" });

                var dto = _mapper.Map<ProductDTO>(obj);

                return View(dto);
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = "Product is not found" });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = _uof._Product.GetId(p => p.Id == id);


                _uof._Product.Delete(obj);
                _uof.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}
