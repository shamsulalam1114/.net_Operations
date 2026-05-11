namespace BLL.DTOs
{
    public class StockLogDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductId { get; set; }
        public int ChangeQty { get; set; }
        public string Reason { get; set; } = null!;
        public int? RefId { get; set; }
        public string? ProductName { get; set; }
    }
}
