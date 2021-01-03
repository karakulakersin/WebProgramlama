using BlogSosyalMedya.Data;
using BlogSosyalMedya.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDunyasi1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {  
        private readonly IHtmlLocalizer<HomeController> _localizer;
    
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, IHtmlLocalizer<HomeController> localizer)
        {
            _context = context;
            _localizer = localizer;

        }

        public IActionResult Index()
        {
            var test = _localizer["Page Heading"];
            ViewData["Page Heading"] = test;
            var db = _context.TatilYerleri
                .Include(f => f.Sehir)
                .Include(f => f.Ulke);


            return View(db.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
