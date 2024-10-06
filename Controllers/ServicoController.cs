using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBacharelatoFilas.Helpers.Enum;
using ProjetoBacharelatoFilas.Models;
using ProjetoBacharelatoFilas.Repositories;
using ProjetoBacharelatoFilas.ViewModels;
using iTextSharp.LGPLv2.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace ProjetoBacharelatoFilas.Controllers
{
    [Authorize]
    public class ServicoController : Controller
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IPedidoServicoRepository _pedidoServicoRepository;
        private readonly IEstudanteRepository _estudanteRepository;
        private readonly IModeloSenhaRepository _modeloSenhaRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServicoController(IServicoRepository servicoRepository, IPedidoServicoRepository pedidoServicoRepository, IEstudanteRepository estudanteRepository, IModeloSenhaRepository modeloSenhaRepository, IWebHostEnvironment webHostEnvironment)
        {
            _servicoRepository = servicoRepository ?? throw new ArgumentNullException(nameof(servicoRepository));
            _pedidoServicoRepository = pedidoServicoRepository;
            _estudanteRepository = estudanteRepository;
            _modeloSenhaRepository = modeloSenhaRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var servicos = await _servicoRepository.Listar();
            return View(servicos);
        }

        [HttpGet]
        public async Task<IActionResult> Listagem()
        {
            var servicos = await _servicoRepository.Listar();
            return View(servicos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Criar(Servico servico)
        {
            var resultado = await _servicoRepository.Adicionar(servico);

            return resultado ? RedirectToAction(nameof(Listagem)) : View(nameof(Criar), servico);
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int servicoId)
        {
            var resultado = await _servicoRepository.BuscarServico(servicoId);
            ViewData["Estados"] = Enum.GetValues(typeof(Estado));
            return View(resultado);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Servico servico)
        {
            var resultado = await _servicoRepository.Editar(servico);

            return resultado ? RedirectToAction(nameof(Listagem)) : View(nameof(Editar), servico);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int servicoId)
        {
            var resultado = await _servicoRepository.Eliminar(servicoId);
            return RedirectToAction(nameof(Listagem));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Formulario(int servicoId)
        {
            var form = new FormularioViewModel { ServicoId = servicoId };
            return View(form);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> EfetuarPedido(FormularioViewModel servico)
        {
            var response = await _modeloSenhaRepository.Adicionar();
            var pedido = new PedidoServico
            {
                ServicoId = servico.ServicoId,
                NomeCompleto = servico.Estudante.NomeCompleto,
                Email = servico.Estudante.Email,
                Telefone = servico.Estudante.Telefone,
                Curso = servico.Estudante.Curso,
                SenhaPedido = response.Senha,
                Servico = await _servicoRepository.BuscarServico(servico.ServicoId)
            };
            await _pedidoServicoRepository.Adicionar(pedido);

            return View(nameof(ConfirmacaoPedido), pedido);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ConfirmacaoPedido()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> PdfGerar(int id)
        {
            var pedidoServico = await _pedidoServicoRepository.BuscarPedidoServicoAsync(id);

            var webRootPath = _webHostEnvironment.WebRootPath;

            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document(PageSize.A4, 25, 25, 25, 25);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            var imagePath = Path.Combine(webRootPath, "img", "instic-logo-1.png");

            Image logo = Image.GetInstance(imagePath);
            logo.ScalePercent(10f);
            logo.Alignment = Element.ALIGN_CENTER;
            document.Add(logo);
            Paragraph space = new Paragraph($"\n\n\n\n\n");
            space.Alignment = Element.ALIGN_CENTER;
            space.Font = new Font(Font.HELVETICA, 13, Font.BOLD, BaseColor.Blue);
            document.Add(space);
            Paragraph companyName = new Paragraph($"Estudante:{pedidoServico.NomeCompleto}");
            companyName.Alignment = Element.ALIGN_CENTER;
            companyName.Font = new Font(Font.HELVETICA, 13, Font.BOLD, BaseColor.Blue);
            document.Add(companyName);

            Paragraph senha = new Paragraph($"Senha:{pedidoServico.SenhaPedido}");
            senha.Alignment = Element.ALIGN_CENTER;
            senha.Font = new Font(Font.HELVETICA, 13, Font.BOLD, BaseColor.Blue);
            document.Add(senha);

            Paragraph servico = new Paragraph($"Serviço:{pedidoServico.Servico.NomeServico}");
            servico.Alignment = Element.ALIGN_CENTER;
            servico.Font = new Font(Font.HELVETICA, 13, Font.BOLD, BaseColor.Blue);
            document.Add(servico);

            document.Add(new Paragraph("\n"));
            Paragraph mesAvaliacao = new Paragraph($"Data Emissão:{pedidoServico.DataCriacao.ToShortDateString()}");
            mesAvaliacao.Alignment = Element.ALIGN_CENTER;
            mesAvaliacao.Font = new Font(Font.HELVETICA, 16, Font.BOLD, BaseColor.Blue);
            document.Add(mesAvaliacao);

            document.Add(new Paragraph("\n"));

            document.Close();

            byte[] pdfContent = memoryStream.ToArray();
            return new FileContentResult(pdfContent, "application/pdf");
        }
        
    }
}
