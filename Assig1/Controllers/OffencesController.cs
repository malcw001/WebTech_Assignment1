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
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Assig1.Controllers
{
    public class OffencesController : Controller
    {
        private readonly ExpiationsContext _context;

        public OffencesController(ExpiationsContext context)
        {
            _context = context;
        }

        // GET: Offences
        public async Task<IActionResult> Index(OffenceSearch os)
        {
            ViewBag.Title = "Offences";
            ViewBag.Active = "Offences";

            var offencesContext = _context.Offences
                .Include(o => o.Section)
                .Include(o => o.Section.Category)
                .OrderBy(o => o.OffenceCode);

            #region Search
            if (!string.IsNullOrWhiteSpace(os.SearchText))
            {
                offencesContext = (IOrderedQueryable<Offence>)offencesContext
                    .Where(i => i.Section.Category.CategoryName.Contains(os.SearchText));
            }
            if (os.CategoryId != null)
            {
                offencesContext = (IOrderedQueryable<Offence>)offencesContext
                    .Where(i => i.Section.Category.CategoryId == os.CategoryId);
            }
            #endregion

            #region CategoriesQuery
            var Categories = (from o in _context.ExpiationCategories
                              orderby (o.CategoryName)
                              select new
                              {
                                  o.CategoryId,
                                  o.CategoryName
                              }).ToList();

            os.CategoryName = new SelectList(Categories, nameof(os.CategoryId), nameof(os.CategoryName), os.CategoryId);
            #endregion

            os.ItemList = offencesContext.ToList();

            return View(os);
        }

        // GET: Offences/Details/A002
        public async Task<IActionResult> Details(string id)
        {
            ViewBag.Title = "Offences";
            ViewBag.Active = "Offences";
            if (id == null)
            {
                return NotFound();
            }

            var offence = await _context.Offences
                .Include(o => o.Section)
                .FirstOrDefaultAsync(m => m.OffenceCode == id);
            if (offence == null)
            {
                return NotFound();
            }

            return View(offence);
        }

        private bool OffenceExists(string id)
        {
            return _context.Offences.Any(e => e.OffenceCode == id);
        }
    }
}
