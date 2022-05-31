using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Technical_Test_Repository.Models;

namespace Technical_Test_Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MasterSelDBContext _context;
        public ProductRepository()
        {
            _context = new MasterSelDBContext();
        }
        public ProductRepository(MasterSelDBContext context)
        {
            _context = context;
        }
        public void Delete(int ProductID)
        {
            Product product = _context.Products.Find(ProductID);
            _context.Products.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int ProductID)
        {
            return _context.Products.Find(ProductID);
        }

        public void Insert(Product product)
        {
            _context.Products.Add(product);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}