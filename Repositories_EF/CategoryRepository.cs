using BusinessObjects_EF;
using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CaterogyDAO _caterogyDAO = new CaterogyDAO();
        public List<Category> GetAllCategories()
        {
            return _caterogyDAO.GetAllCategories();
        }
    }
}
