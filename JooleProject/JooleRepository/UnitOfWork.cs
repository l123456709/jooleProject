using JooleRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JooleRepository
{
    public class UnitOfWork : IDisposable
    {
        DbContext Context;
        public IProductRepo product;

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
            product = new ProductRepo(Context);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}