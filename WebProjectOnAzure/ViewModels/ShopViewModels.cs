using Microsoft.AspNetCore.Mvc.Rendering;
using WebProjectOnAzure.Models;
namespace WebProjectOnAzure.ViewModels
{
    public class ShopViewModels
    {
        public class ShopModel
        {
            public int? MaximumPrice { get; set; }
            public int? MinPrice { get; set; }
            public List<Product>? Products { get; set; }
            public List<Category>? Categories { get; set; }
            public int? SortBy { get; set; }
            public int? CategoryID { get; set; }
            public Pager? Pager { get; set; }
            public string? SearchTerm { get; set; }
            public int? ShopStyle { get; set; }
            public List<int>? CategoryCheckIds { get; set; }
            public int InitialMaximumPrice { get; set; }
        }
        public class FilterViewModel
        {
            public int? MaximumPrice { get; set; }
            public int? MinPrice { get; set; }
            public List<Product>? Products { get; set; }
            public List<Category>? Categories { get; set; }
            public int? SortBy { get; set; }
            public int? CategoryID { get; set; }
            public Pager? Pager { get; set; }
            public string? SearchTerm { get; set; }
            public int? ShopStyle { get; set; }
            public List<int>? CategoryCheckIds { get; set; }
            public int InitialMaximumPrice { get; set; }

        }
    }
}
