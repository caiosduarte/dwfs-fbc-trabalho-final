using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Modelo;

namespace Inventario.Repositorio
{
    public interface IRepositorioItem
    {
        IEnumerable<Item> GetAll();

        Item Get(string id);
        
        void Create(Item item);
        
        void Update(Item item);

        void Delete(string id);
    }
}
