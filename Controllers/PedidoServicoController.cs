using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBacharelatoFilas.Models;

namespace ProjetoBacharelatoFilas.Controllers
{
	[Authorize]
	public class PedidoServicoController : Controller
	{
		private readonly ILogger<PedidoServicoController> _logger;

		public PedidoServicoController(ILogger<PedidoServicoController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Sobre()
		{
			return View();
		}
		public ActionResult Servico() => View();
		public ActionResult Equipe() => View();


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
