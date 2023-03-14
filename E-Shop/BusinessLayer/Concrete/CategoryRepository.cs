using EntityLayer.Entities;
using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;

namespace BusinessLayer.Concrete
{
    public class CategoryRepository:GenericRepository<Category>
    {
        DataContext db = new DataContext();
        public List<Product> CategoryDetails(int id)
        {
            return db.Products.Where(x => x.CategoryID == id).ToList();
        }
    }
}
