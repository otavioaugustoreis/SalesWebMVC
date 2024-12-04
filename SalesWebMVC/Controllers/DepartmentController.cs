using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Data.Entity;

namespace SalesWebMVC.Controllers
{
    /*Testar esse cara
     [Route("api/[controller]")]*/
    //[ApiController]
    public class DepartmentController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<DepartmentEntity> list = new List<DepartmentEntity>()
            {
                new DepartmentEntity(1, "Eletronics"),
                new DepartmentEntity(2, "Eats")
            };

            return View(list);
        }
    }
}
