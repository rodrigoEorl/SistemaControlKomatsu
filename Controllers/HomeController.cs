using Microsoft.AspNetCore.Mvc;
using SistemaControl.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace SistemaControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbpruebasContext _dbContext;
        public HomeController(ILogger<HomeController> logger, DbpruebasContext dbpruebasContext)
        {
            _logger = logger;
            this._dbContext = dbpruebasContext;
        }

        public IActionResult Index()
        {
            List<Ordene> ordenes = _dbContext.Ordenes.ToList();
            return View(ordenes);
        }
        public ActionResult Process(List<Ordene> ordenes)
        {
            ViewBag.InterNoPlan = _dbContext.Maestros.Where(p => p.Codigo == "[NOPLANINTERRUPCION]").ToList();
            ViewBag.InterPlan = _dbContext.Maestros.Where(p => p.Codigo == "[PLANINTERRUPCION]").ToList();
            return PartialView(ordenes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult UpdateOrden(List<Ordene> ordenes)
        {
            try
            {

                foreach (var orden in ordenes)
                {
                    Ordene ordenUpd = _dbContext.Ordenes.FirstOrDefault(c => c.IdOrden == orden.IdOrden);
                    ordenUpd.Estado = orden.Estado;
                    ordenUpd.Tipo = orden.Tipo;
                    _dbContext.Ordenes.Update(ordenUpd);
                }

                _dbContext.SaveChanges();
                return Json(new { mensaje = "Correcto" });

            }
            catch (Exception)
            {
                return Json(null);
            }
        }
    }
}