using Microsoft.AspNetCore.Mvc;
using StarWars.Context;
using StarWars.Models;
using System.Reflection;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Navbar i�in sayfa ba�l�klar�n� alma
        var titles = _context.Pages
                             .Where(p => p.Title != null)
                             .Select(p => p.Title!)
                             .ToList();

        var viewModel = new NavbarViewModel
        {
            PageTitles = titles
        };

        ViewBag.NavbarViewModel = viewModel;

        // TopContent verilerini alma
        var topContents = _context.TopContent
            .Where(tc => !string.IsNullOrEmpty(tc.ImgUrl) && !string.IsNullOrEmpty(tc.AltText))
            .ToList();

        var contentViewModel = new TopContentViewModel
        {
            Contents = topContents
        };

        ViewBag.TopContentViewModel = contentViewModel;

        return View();
    }

    [Route("{pageName}")]
    public IActionResult Sayfa(string pageName)
    {
        // Pages tablosundan sayfa verisini �ekme
        var sayfa = _context.Pages.FirstOrDefault(p => p.PageName == pageName);
        if (sayfa == null)
        {
            return NotFound(); // Sayfa bulunamazsa 404 d�nd�r
        }

        // about_contents tablosundan i�erikleri �ekme
        var aboutContents = _context.AboutContent.FirstOrDefault(ac => ac.PageName == sayfa.Id);

        // aboutContents null ise
        if (aboutContents == null)
        {
            return NotFound(); // ��erik bulunamad�ysa 404 d�nd�r
        }

        string imageBasePath = "/img/";

        // HTML'deki yer tutucular� dinamik i�eriklerle de�i�tir
        string dynamicHtml = sayfa.Content
            .Replace("IMAGE_PLACEHOLDER", imageBasePath + aboutContents.ImgContents)
            .Replace("TITLE_PLACEHOLDER", aboutContents.Title)
            .Replace("DESCRIPTION_PLACEHOLDER", aboutContents.Description);

        var model = new
        {
            HtmlContent = dynamicHtml
        };

        return View(model);
    }





}



