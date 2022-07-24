using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Model
{
    public class BillDetail
    {

        [Key]
        public int BillId { get; set; }
        public string BillName { get; set; } = null!;
        
        public int BillAmount { get; set; }
        public string BillStatus { get; set; } = "Pending";
        public string ?Email { get; set; }
        public int? ContactNumber { get; set; }

        public DateTime? BillDate { get; set; }

        public string? Reason { get; set; } = null!;

    }
}
