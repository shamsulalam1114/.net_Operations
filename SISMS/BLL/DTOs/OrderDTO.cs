using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = "Draft";
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalAmount { get; set; }
        [StringLength(20)] public string? PaymentMethod { get; set; }
        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
    }
}
