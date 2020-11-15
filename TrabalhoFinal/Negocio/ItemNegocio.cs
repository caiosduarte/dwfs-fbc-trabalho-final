using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Modelo;
using Inventario.Repositorio;

namespace Inventario.Negocio
{
    public class ItemNegocio
    {
        private IRepositorioItem _repositorioItem;
        public ItemNegocio(IRepositorioItem repositorioItem)
        {
            _repositorioItem = repositorioItem;
        }

        internal void DeleteItem(string id)
        {
            _repositorioItem.Delete(id);
        }

        internal void UpdateItem(Item item)
        {
            item.AtualizadoEm = DateTime.Now;

            _repositorioItem.Update(item);
        }

        public IEnumerable<Item> GetItens()
        {
            return _repositorioItem.GetAll();
        }

        public decimal CalculaCustoTotal()
        {
            decimal resultado = 0;
            foreach (Item item in GetItens()) 
            {
                resultado += item.CalculaDepreciacaoAnual();
            } 

            return resultado;
        }

        internal decimal CalculaValorResidualTotal()
        {
            decimal resultado = 0;
            foreach (Item item in GetItens())
            {
                resultado += (decimal)item.ValorResidual;
            }

            return resultado;
        }

        public Item GetItem(string id)
        {
            return _repositorioItem.Get(id);
        }

        internal void CreateItem(Item item)
        {
            item.CriadoEm = DateTime.Now;
            item.AtualizadoEm = DateTime.Now;
            _repositorioItem.Create(item);
        }


    }
}
