﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
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

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue && !maxDate.HasValue)
            {
                minDate = DateTime.Now;
                maxDate = DateTime.Now.AddMonths(3);
            };

            if (!minDate.HasValue)
            {
                minDate = maxDate.Value.AddMonths(-3);
            }

            if (!maxDate.HasValue)
            {
                maxDate = minDate.Value.AddMonths(3);
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var consulta = await _uof._Sales.FindByDate(minDate, maxDate);

            return View(consulta);
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


    }
}
