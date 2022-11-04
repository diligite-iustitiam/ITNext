
namespace Shop.Domain
{
    
    public partial class Order
    { 
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public int CVCode { get; set; }    
        public string? CouponCode { get; set; }              
        public decimal Total { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
