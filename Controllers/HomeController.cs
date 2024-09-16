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
        // Navbar için sayfa baþlýklarýný alma
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
        // Pages tablosundan sayfa verisini çekme
        var sayfa = _context.Pages.FirstOrDefault(p => p.PageName == pageName);
        if (sayfa == null)
        {
            return NotFound(); // Sayfa bulunamazsa 404 döndür
        }

        // about_contents tablosundan içerikleri çekme
        var aboutContents = _context.AboutContent.FirstOrDefault(ac => ac.PageName == sayfa.Id);

        // aboutContents null ise
        if (aboutContents == null)
        {
            return NotFound(); // Ýçerik bulunamadýysa 404 döndür
        }

        string imageBasePath = "/img/";

        // HTML'deki yer tutucularý dinamik içeriklerle deðiþtir
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



