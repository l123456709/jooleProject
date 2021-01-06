using JooleDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JooleRepository.Repositories
{   
    public interface ITechSpecFilterRepo : IRepository<TechSpecFilter>
    {

    }
    public class TechSpecFilterRepo : Repository<TechSpecFilter>, ITechSpecFilterRepo
    {
        public TechSpecFilterRepo(DbContext context) : base(context)
        {

        }
    }
}