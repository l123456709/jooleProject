using JooleDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JooleRepository.Repositories
{   
    public interface ICategoryRepo : IRepository<Category>
    {

    }
    public class CategoryRepo : Repository<Category>, ICategoryRepo
    {
        public CategoryRepo(DbContext context) : base(context)
        {

        }
    }
}