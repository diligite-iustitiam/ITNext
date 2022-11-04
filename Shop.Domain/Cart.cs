
namespace Shop.Domain
{
    public class Cart
    {
        public int RecordID { get; set; }
        public string? CartID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Product? Product { get; set; }
    }
}
