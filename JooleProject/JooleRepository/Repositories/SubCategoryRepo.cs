using JooleDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JooleRepository.Repositories
{   
    public interface ISubCategoryRepo : IRepository<SubCategory>
    {

    }
    public class SubCategoryRepo : Repository<SubCategory>, ISubCategoryRepo
    {
        public SubCategoryRepo(DbContext context) : base(context)
        {

        }
    }
}