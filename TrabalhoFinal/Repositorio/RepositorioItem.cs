using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Data;
using Inventario.Modelo;

namespace Inventario.Repositorio
{
    public class RepositorioItem : IRepositorioItem
    {
        private ApplicationDbContext _context;

        public RepositorioItem(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetAll()
        {
            return (_context.Item != null? _context.Item.ToList(): new List<Item>());
        }

        public Item Get(string id)
        {
            return _context.Item.Where(item => item.Id.ToString().Equals(id)).FirstOrDefault();
        }

        public void Create(Item item)
        {
            this._context.Item.Add(item);
            this._context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this._context.SaveChanges();
        }

        public void Update(Item item)
        {
            this._context.Item.Update(item);
            this._context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
        }

        public void Delete(string id)
        {
            Item item = Get(id);
            this._context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            this._context.SaveChanges();
        }
    }
}
