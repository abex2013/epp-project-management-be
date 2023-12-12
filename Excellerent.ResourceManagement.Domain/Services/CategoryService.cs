using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        List<Category> categories = new List<Category>();
        public CategoryService()
        {
            categories.AddRange(
                new List<Category> {
                    new Category {
                        Guid = new Guid(),
                        Name = "Device",
                        Description ="device desc",
                    },
                    new Category {
                        Guid= new Guid(),
                        Name = "Mobile",
                        Description = "mobile desc"
                    },
                    new Category {
                        Guid= new Guid(),
                        Name = "Printer",
                        Description = "printer desc"
                    }
                }
            );
        }
        public List<Category> GetCategories()
        {
            return categories;
        }

        public List<Category> GetCategoryById(Guid id)
        {
            return id == null ? categories : categories.Where(x => x.Guid == id).ToList();
        }
    }
}
