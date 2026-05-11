using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Range(1, int.MaxValue)] public int ProductId { get; set; }
        [Range(0.01, 999999)] public decimal UnitPrice { get; set; }
        [Range(1, 999999)] public int Qty { get; set; }
        public decimal LineTotal { get; set; }
    }
}
