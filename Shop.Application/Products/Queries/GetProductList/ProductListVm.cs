﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public IList<ProductLookupDto>? Products { get; set; }
    }
}
