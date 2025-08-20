using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Dashboard()
    {

        if (HttpContext.Session.GetString("User") != null)
        {
            List<BaseEquipment> listBase = BaseEquipment.GetBaseEquipment();
            ViewBag.listBase = listBase;
            ViewBag.txtName = "";
            return View();
        }
        else
        {
            return RedirectToAction("Login", "Account");
        }
    }
    [HttpPost]
    public IActionResult Dashboard(FormCollection frm, string btnSubmit)
    {
        List<BaseEquipment> listBase = BaseEquipment.GetBaseEquipment();
        ViewBag.listBase = listBase;
        ViewBag.txtName = "";
        if(btnSubmit == "Search")
        {
            ViewBag.txtName = frm["txtName"].ToString();
        }
        //if(btnSubmit == "Logout")
        //{
        //    return RedirectToAction("Login", "Account");
        //}
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
