using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotographyApp.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyApp.Controllers
{
    public class PackagesController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PackagesController(DataContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Packages/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Hämta alla paket och skicka dem till vyn via ViewBag
            ViewBag.AllPackages = _context.Packages.ToList();
            return View();
        }

        // POST: Packages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Package package, List<IFormFile> images)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                // Hantera bilduppladdningar
                foreach (var image in images)
                {
                    if (image != null && image.Length > 0)
                    {
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

                        if (!Directory.Exists(uploads))
                        {
                            Directory.CreateDirectory(uploads);
                        }

                        var filePath = Path.Combine(uploads, image.FileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                        }

                        package.ImagePaths = package.ImagePaths ?? new List<string>();
                        package.ImagePaths.Add("/uploads/" + image.FileName);
                    }
                }

                _context.Add(package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Om modellen inte är giltig, skicka alla paket till vyn via ViewBag
            ViewBag.AllPackages = _context.Packages.ToList();
            return View(package);
        }

        // GET: Packages/Index
        public async Task<IActionResult> Index()
        {
            var packages = await _context.Packages.ToListAsync();
            return View(packages);
        }

        // GET: Packages/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(p => p.Id == id);

            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // GET: Packages/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }

        // POST: Packages/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Package package, List<IFormFile> images)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Hantera bilduppladdningar
                    foreach (var image in images)
                    {
                        if (image != null && image.Length > 0)
                        {
                            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

                            if (!Directory.Exists(uploads))
                            {
                                Directory.CreateDirectory(uploads);
                            }

                            var filePath = Path.Combine(uploads, image.FileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await image.CopyToAsync(fileStream);
                            }

                            package.ImagePaths = package.ImagePaths ?? new List<string>();
                            package.ImagePaths.Add("/uploads/" + image.FileName);
                        }
                    }

                    _context.Update(package);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(package.Id))
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
            return View(package);
        }

        private bool PackageExists(int id)
        {
            return _context.Packages.Any(e => e.Id == id);
        }

        // GET: Packages/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var package = await _context.Packages.FirstOrDefaultAsync(p => p.Id == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // POST: Packages/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package != null)
            {
                _context.Packages.Remove(package);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
