using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Excellerent.ResourceManagement.Domain.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        List<SubCategory> subCategories = new List<SubCategory>();
        public SubCategoryService()
        {
            subCategories.AddRange(
                new List<SubCategory> {
                    new SubCategory {
                        Guid = new Guid(),
                        Name = "Laptop",
                        Description ="laptop desc",
                    },
                    new SubCategory {
                        Guid= new Guid(),
                        Name = "System Unit",
                        Description = "system unit desc"
                    },
                    new SubCategory {
                        Guid= new Guid(),
                        Name = "Monitor",
                        Description = "monitor desc"
                    }
                }
            );
        }
        public List<SubCategory> GetSubCategories()
        {
            return subCategories;
        }

        public List<SubCategory> GetSubCategoryById(Guid id)
        {
            return id == null ? subCategories : subCategories.Where(x => x.Guid == id).ToList();
        }
    }
}
