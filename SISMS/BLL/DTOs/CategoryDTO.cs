using System.ComponentModel.DataAnnotations;
namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required][StringLength(80)] public string Name { get; set; } = null!;
        [Range(0.01, 999999)] public decimal Price { get; set; }
        [Range(0, 999999)] public int Qty { get; set; }
        [Range(0, 999999)] public int ReorderLevel { get; set; }
        [Range(1, int.MaxValue)] public int Cid { get; set; }
        public string Status { get; set; } = "Active";
    }
}
