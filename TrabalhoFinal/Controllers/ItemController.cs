using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Modelo;
using Inventario.Negocio;
using Inventario.ViewModel;

namespace Inventario.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult GetTodosItens([FromServices] ItemNegocio itemNegocio)
        {
            IEnumerable<Item> itens = itemNegocio.GetItens();

            ListaItemViewModel viewModel = new ListaItemViewModel()
            {
                Itens = itens,
                Quantidade = itens.Count(),
                CustoTotal = itemNegocio.CalculaCustoTotal(),
                ValorResidualTotal = itemNegocio.CalculaValorResidualTotal()
            };

            return View(viewModel);
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetTodosItens");
        }


        public IActionResult Details(string id, [FromServices] ItemNegocio itemNegocio)
        {
            Item item = itemNegocio.GetItem(id);

            ItemViewModel viewModel = new ItemViewModel
            {
                item = item
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Create(Item item, [FromServices] ItemNegocio itemNegocio)
        {

            item.CriadoEm = new DateTime();
            itemNegocio.CreateItem(item);
            return RedirectToAction("GetTodosItens");
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Delete(string id, [FromServices] ItemNegocio itemNegocio)
        {
            itemNegocio.DeleteItem(id);
            return RedirectToAction("GetTodosItens");
        }

        [HttpGet]
        public IActionResult Edit(string id, [FromServices] ItemNegocio itemNegocio)
        {
            Item item = itemNegocio.GetItem(id);

            ItemViewModel viewModel = new ItemViewModel
            {
                item = item
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Item item, [FromServices] ItemNegocio itemNegocio)
        {
            itemNegocio.UpdateItem(item);
            return RedirectToAction("GetTodosItens");
        }

    }
}
