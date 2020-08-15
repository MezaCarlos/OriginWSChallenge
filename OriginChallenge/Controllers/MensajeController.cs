using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OriginChallenge.Controllers
{
    public class MensajeController : Controller
    {
        public IActionResult Index()
        {
            if (TempData.ContainsKey("Parametros"))
                ViewBag.Parametros = JsonSerializer.Deserialize<Dictionary<string, string>>(TempData["Parametros"] as string);
            else
                ViewBag.Parametros = new Dictionary<string, string>();

            return View();
        }

    }
}
