using Microsoft.AspNetCore.Mvc;
using Projeto_ControleEstoque.Models;
using System.Diagnostics;
using Projeto_ControleEstoque.DAL;

namespace Projeto_ControleEstoque.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Produto> listaProdutos = new List<Produto>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            produto.DataInclusao = DateTime.Now;
            ProdutosDAL.dbInsert(produto);
            return RedirectToAction("Produtos");
        }

        [HttpPost]
        public IActionResult Update(Produto produto)
        {
            ProdutosDAL.dbUpdate(produto);
			return RedirectToAction("Produtos");
		}


        [HttpPost]
        public IActionResult Delete(int id)
        {
            ProdutosDAL.dbDelete(id);
            return RedirectToAction("Produtos");
        }

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            listaProdutos = ProdutosDAL.dbSelect();
            return View(listaProdutos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}