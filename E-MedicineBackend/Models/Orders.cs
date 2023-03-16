using System.ComponentModel.DataAnnotations;

namespace E_MedicineBackend.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }
    }
}
