using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_MVC.Models;

namespace MVC.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}