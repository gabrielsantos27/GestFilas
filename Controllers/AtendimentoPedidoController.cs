using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBacharelatoFilas.Repositories;

namespace ProjetoBacharelatoFilas.Controllers
{
    [Authorize]
    public class AtendimentoPedidoController : Controller
    {
        private readonly IPedidoServicoRepository _pedidoServicoRepository;

        public AtendimentoPedidoController(IPedidoServicoRepository pedidoServicoRepository)
        {
            _pedidoServicoRepository = pedidoServicoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoServicoRepository.Listar();

            return View(pedidos);
        }
    }
}
