using WebProjectOnAzure.Models;
namespace WebProjectOnAzure.ViewForModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
