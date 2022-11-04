using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain;
using Xunit;

namespace XUnitTests.DataDUT;

    public class ProductDataClass : IEnumerable<object[]>
  {

    public static IEnumerable<object[]> data = new[]
    {

            new object[] {

                    new Product
                    {
                ProductID = 22,
                ProductBrand = "Aa",
                ProductModel = "Bd",
                Price = 123123,
                ProductDescription = "s",
                ProductImage = "34",
                CategoryID = 6
                    }
                  },
            new object[]{
                     new Product
                    {
                ProductID = 23,
                ProductBrand = "Aa",
                ProductModel = "Bd",
                Price = 12,
                ProductDescription = "s",
                ProductImage = "34a",
                CategoryID = 2
                     }
               }
            
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    [Theory, ClassData(typeof(ProductDataClass))]
    public void Test_Product_ShoudReturn_CorrectPrice(Product product)
    {
        Assert.NotNull(product);
        Assert.InRange(product.Price, 1, 123124);
    }
}










//[Theory, MemberData(nameof(Product), MemberType =typeof(ProductDataClass))]
//public void Test_Product_ShoudReturn_CorrectPrice(Product product)
//{           
//    Assert.NotNull(product);
//    Assert.InRange(product.Price, 10000, 123124);
//}



