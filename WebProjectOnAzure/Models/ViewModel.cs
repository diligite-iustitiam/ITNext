
using WebProjectOnAzure.ViewModels;

namespace WebProjectOnAzure.Models
{
    public class ViewModel
    {
        public string? SelectItem { get; set; }
        public string? SelectedCategory { get; set; }
        public List<Product>? ProductSelectList { get; set; }
        public Category? Categories { get; set; }
        public Product? ProductModels { get; set; }
    }
}
