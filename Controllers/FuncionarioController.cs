using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBacharelatoFilas.Models;
using ProjetoBacharelatoFilas.Repositories;

namespace ProjetoBacharelatoFilas.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        private readonly IAuthenticate _authenticate;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IAuthenticate authenticate)
        {
            _funcionarioRepository = funcionarioRepository;
            _authenticate = authenticate;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _funcionarioRepository.Listar();
            return View(result);
        }
        [HttpGet]
        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(Funcionario funcionario)
        {
            var resultado = await _funcionarioRepository.Adicionar(funcionario);

            resultado = await _authenticate.RegisterUserAsync(funcionario.Email, GetFirstName(funcionario.NomeCompleto) + "123#".ToString(), await _funcionarioRepository.MaxFuncionario());

            return resultado ? RedirectToAction(nameof(Index)) : View(nameof(Criar), funcionario);
        }
        private static string GetFirstName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                return string.Empty;
            }

            string[] names = fullName.Split(' ');

            return names[0];
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int funcionarioId)
        {
            var resultado = await _funcionarioRepository.BuscarFuncionario(funcionarioId);
            return View(resultado);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Funcionario funcionario)
        {
            var resultado = await _funcionarioRepository.Editar(funcionario);

            return resultado ? RedirectToAction(nameof(Index)) : View(nameof(Editar), funcionario);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int funcionarioId)
        {
            var resultado = await _funcionarioRepository.Eliminar(funcionarioId);
            return RedirectToAction(nameof(Index));
        }

    }
}
