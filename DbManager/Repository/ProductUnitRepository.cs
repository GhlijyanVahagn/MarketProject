using DbManager.DatabaseContext;
using DbManager.RepositoryInterfaces;
using DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Repository
{
    class ProductUnitRepository : IProductUnitRepository
    {
        ProductUnitDbContext _context;
        public ProductUnitRepository()
        {
            _context = new ProductUnitDbContext();
        }

        public ProductUnitRepository(ProductUnitDbContext context)
        {
            _context = context;
        }
        public void Create(Unit entity)
        {
           _context.Unit.Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = _context.Unit.Find(Id);
            _context.Unit.Remove(entity);
        }

        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            return await _context.Unit.ToListAsync();
        }

        public Unit Read(int Id)
        {
            return _context.Unit.Find(Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Unit entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

        }
    }
}
