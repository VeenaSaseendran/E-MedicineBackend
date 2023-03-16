using System.ComponentModel.DataAnnotations;

namespace E_MedicineBackend.Models
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }    
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
