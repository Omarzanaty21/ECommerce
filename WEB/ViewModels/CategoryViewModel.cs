
using WEB.Models;

namespace WEB.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            
        }
        public CategoryViewModel(Category model)
        {
            this.Name = model.Name;
            this.ParentId = model.ParentId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

    }
} 