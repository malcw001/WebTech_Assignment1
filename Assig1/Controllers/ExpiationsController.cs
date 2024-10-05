using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assig1.Data;
using Assig1.Models;

namespace Assig1.Controllers
{
    public class ExpiationsController : Controller
    {
        private readonly ExpiationsContext _context;

        public ExpiationsController(ExpiationsContext context)
        {
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    var yearList = _context.CustomerOrders
        //        .Select(co => co.OrderDate.Year)
        //        .Distinct()
        //        .OrderByDescending(co => co)
        //        .ToList();

        //    return View("AnnualSalesReport", new SelectList(yearList));
        //}

        //[Produces("application/json")]
        //public IActionResult AnnualSalesReportData(int Year)
        //{
        //    if (Year > 0)
        //    {
        //        var orderSummary = _context.ItemsInOrders
        //            .Where(iio => iio.OrderNumberNavigation.OrderDate.Year == Year)
        //            .GroupBy(iio => new { iio.OrderNumberNavigation.OrderDate.Year, iio.OrderNumberNavigation.OrderDate.Month })
        //            .Select(group => new
        //            {
        //                year = group.Key.Year,
        //                monthNo = group.Key.Month,
        //                monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month),
        //                totalItems = group.Sum(iio => iio.NumberOf),
        //                totalSales = group.Sum(iio => iio.TotalItemCost)
        //            })
        //            .OrderBy(data => data.monthNo);
        //        return Json(orderSummary);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}


        // GET: Expiations
        public async Task<IActionResult> Index()
        {

            return View(await _context.Expiations.ToListAsync());
        }

        // GET: Expiations/Details/5
        public async Task<IActionResult> Details(DateOnly? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expiation = await _context.Expiations
                .FirstOrDefaultAsync(m => m.IncidentStartDate == id);
            if (expiation == null)
            {
                return NotFound();
            }

            return View(expiation);
        }
    }
}
