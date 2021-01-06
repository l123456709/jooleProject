using JooleDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JooleRepository.Repositories
{   
    public interface IPropertyRepo : IRepository<Property>
    {

    }
    public class PropertyRepo : Repository<Property>, IPropertyRepo
    {
        public PropertyRepo(DbContext context) : base(context)
        {

        }
    }
}