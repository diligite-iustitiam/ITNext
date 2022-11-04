using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string? ProductBrand { get; set; }

        public string? ProductModel { get; set; }

        public string? ProductDescription { get; set; }

        public decimal Price { get; set; }

        public string? ProductImage { get; set; }
    }
}
