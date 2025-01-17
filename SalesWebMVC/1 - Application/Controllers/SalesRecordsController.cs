using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using SalesWebMVC._1___Application.Models;
using SalesWebMVC._2___Domain.Filters;
using SalesWebMVC.UnitOfWork;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {

        private readonly IUnitOfWork _uof;

        public SalesRecordsController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(SalesRecordsFilter salesRecordsFilter)
        {

            if (!salesRecordsFilter.minDate.HasValue && !salesRecordsFilter.maxDate.HasValue)
            {
                salesRecordsFilter.minDate = DateTime.Now;
                salesRecordsFilter.maxDate = DateTime.Now.AddMonths(3);
            }

            if (!salesRecordsFilter.minDate.HasValue)
            {
                salesRecordsFilter.minDate = salesRecordsFilter.maxDate.Value.AddMonths(-3);
            }

            if (!salesRecordsFilter.maxDate.HasValue)
            {
                salesRecordsFilter.maxDate = salesRecordsFilter.minDate.Value.AddMonths(3);
            }

            if (String.IsNullOrEmpty(salesRecordsFilter.DsNome))
            {
                salesRecordsFilter.DsNome = string.Empty;
            }

            var consulta = await _uof._Sales.GetSalesRecordsFilter(salesRecordsFilter);

            //Se você cria uma classe para armazenar os valores, é mais fácil para a view trabalhar com essa classe!!, por isso a criação do SalesRescordsSearchViewModel
            var viewModel = new SalesRecordsSearchViewModel
            {
                Filter = salesRecordsFilter,
                SalesRecords = consulta
            };

            return View(viewModel);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) minDate = DateTime.Now;

            if (!maxDate.HasValue) minDate = DateTime.Now.AddDays(1);

            //Enviando valores pro front

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _uof._Sales.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);

        }

        public 

    }
}
