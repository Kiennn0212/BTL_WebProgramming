using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_WebProgramming.Data;
using BTL_WebProgramming.Models;

namespace BTL_WebProgramming.Controllers
{
    public class SanVanDongAutoController : Controller
    {
        private readonly MyDBContext _context;

        public SanVanDongAutoController(MyDBContext context)
        {
            _context = context;
        }

        // GET: SanVanDongAuto
        public async Task<IActionResult> Index()
        {
            return View(await _context.SanVanDong.ToListAsync());
        }

        // GET: SanVanDongAuto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanVanDong = await _context.SanVanDong
                .FirstOrDefaultAsync(m => m.MaSVD == id);
            if (sanVanDong == null)
            {
                return NotFound();
            }

            return View(sanVanDong);
        }

        // GET: SanVanDongAuto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanVanDongAuto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSVD,TenSVD,DiaChi,SucChua")] SanVanDong sanVanDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanVanDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanVanDong);
        }

        // GET: SanVanDongAuto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanVanDong = await _context.SanVanDong.FindAsync(id);
            if (sanVanDong == null)
            {
                return NotFound();
            }
            return View(sanVanDong);
        }

        // POST: SanVanDongAuto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSVD,TenSVD,DiaChi,SucChua")] SanVanDong sanVanDong)
        {
            if (id != sanVanDong.MaSVD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanVanDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanVanDongExists(sanVanDong.MaSVD))
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
            return View(sanVanDong);
        }

        // GET: SanVanDongAuto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanVanDong = await _context.SanVanDong
                .FirstOrDefaultAsync(m => m.MaSVD == id);
            if (sanVanDong == null)
            {
                return NotFound();
            }

            return View(sanVanDong);
        }

        // POST: SanVanDongAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanVanDong = await _context.SanVanDong.FindAsync(id);
            if (sanVanDong != null)
            {
                _context.SanVanDong.Remove(sanVanDong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanVanDongExists(int id)
        {
            return _context.SanVanDong.Any(e => e.MaSVD == id);
        }
    }
}
