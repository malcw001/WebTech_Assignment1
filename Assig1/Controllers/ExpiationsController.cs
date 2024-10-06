using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assig1.Data;
using Assig1.Models;
using Assig1.ViewModels;

namespace Assig1.Controllers
{
    public class ExpiationsController : Controller
    {
        private readonly ExpiationsContext _context;

        public ExpiationsController(ExpiationsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(ExpiationSearch es)
        {
            var stats = _context.Expiations
                .Join(_context.CameraCodes, e => e.CameraLocationId, cc => cc.LocationId,
                (e, cc) => new { expiation = e, cameraCode = cc})
                .GroupBy(ec => new { ec.expiation.CameraLocationId, ec.cameraCode.Suburb })
                .Select(g => new ExpiationStat
                {
                    LocationId = g.Key.CameraLocationId,
                    Suburb = g.Key.Suburb,
                    TotalIncidents = g.Count(),
                    MaxSpeed = g.Max(e => e.expiation.VehicleSpeed),
                    AvgSpeed = g.Average(e => e.expiation.VehicleSpeed),
                    TotalPenaltyFees = g.Sum(e => e.expiation.OffencePenaltyAmt),
                    TotalFees = g.Sum(e => e.expiation.TotalFeeAmt)
                });

            #region LocationQuery
            if (es.LocationId != null) {
                stats = stats
                    .Where(i => i.LocationId == es.LocationId);
            }
            #endregion

            es.ExpiationList = stats.ToList();

            #region LocationName
            var Locations = (from cc in _context.CameraCodes
                             join e in _context.Expiations on cc.LocationId equals e.CameraLocationId into expGroup
                             orderby (cc.Suburb)
                              select new
                              {
                                  cc.LocationId,
                                  cc.Suburb
                              }).ToList();

            es.Suburb = new SelectList(Locations, nameof(es.LocationId), nameof(es.Suburb), es.LocationId);
            #endregion

            return View(es);
            //return View("ExpiationReport", new SelectList(offenceList));
        }

        //[Produces("application/json")]
        //public async Task<IActionResult> ExpiationReportData(int Location)
        //{
        //    if (Location > 0)
        //    {
        //        var expiationsSummary = _context.Expiations
        //            .Where(e => e.CameraLocationId == Location)
        //            .GroupBy(e => new { e.OffenceCode })
        //            .Select(group => new
        //            {
        //                time = group.Key.Year,
        //                location = group.Key.Month,
        //                monthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(group.Key.Month),
        //                totalItems = group.Sum(e => e.NumberOf),
        //                totalSales = group.Sum(e => e.TotalItemCost)
        //            })
        //            .OrderBy(data => data.monthNo);
        //        return Json(expiationsSummary);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

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
