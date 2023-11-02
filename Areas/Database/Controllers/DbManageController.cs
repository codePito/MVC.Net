using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DbManageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteBd()
        {
            return View();
        }

        [TempData]
        public string statusMessage { get; set; }

        [HttpPost]
        public async Task<IActionResult> DeleteBdAsync()
        {
            var success = await _appDbContext.Database.EnsureDeletedAsync();

            statusMessage = success ? "Xoa DB thanh cong" : "Khong xoa duoc";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _appDbContext.Database.MigrateAsync();

            statusMessage = "Cap nhat DB thanh cong";

            return RedirectToAction(nameof(Index));
        }

    }
}