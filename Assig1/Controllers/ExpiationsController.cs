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
