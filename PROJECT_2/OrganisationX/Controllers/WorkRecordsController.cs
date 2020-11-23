using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganisationX.Models;

namespace OrganisationX.Controllers
{
    [Authorize]
    public class WorkRecordsController : Controller
    {
        private readonly OrganisationXDBContext _context;

        public WorkRecordsController(OrganisationXDBContext context)
        {
            _context = context;
        }

        // GET: WorkRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkRecord.ToListAsync());
        }

        // GET: WorkRecords/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workRecord = await _context.WorkRecord
                .FirstOrDefaultAsync(m => m.WorkRid == id);
            if (workRecord == null)
            {
                return NotFound();
            }

            return View(workRecord);
        }

        // GET: WorkRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkRid,Promo,NumOfComp,YearsAtCurrComp,YearsRole,TotalWorkingYears")] WorkRecord workRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workRecord);
        }

        // GET: WorkRecords/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workRecord = await _context.WorkRecord.FindAsync(id);
            if (workRecord == null)
            {
                return NotFound();
            }
            return View(workRecord);
        }

        // POST: WorkRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("WorkRid,Promo,NumOfComp,YearsAtCurrComp,YearsRole,TotalWorkingYears")] WorkRecord workRecord)
        {
            if (id != workRecord.WorkRid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkRecordExists(workRecord.WorkRid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workRecord);
        }

        // GET: WorkRecords/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workRecord = await _context.WorkRecord
                .FirstOrDefaultAsync(m => m.WorkRid == id);
            if (workRecord == null)
            {
                return NotFound();
            }

            return View(workRecord);
        }

        // POST: WorkRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var workRecord = await _context.WorkRecord.FindAsync(id);
            _context.WorkRecord.Remove(workRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkRecordExists(string id)
        {
            return _context.WorkRecord.Any(e => e.WorkRid == id);
        }
    }
}
