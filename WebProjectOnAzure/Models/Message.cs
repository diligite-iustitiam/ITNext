using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebProjectOnAzure.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Text { get; set; }
        public DateTime? Time { get; set; }
        public string? UserID { get; set; }
        public virtual AppUser? Sender { get; set; }
    }
}
