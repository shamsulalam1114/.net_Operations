namespace BLL.DTOs
{
    public class ReportDTO
    {
        public decimal TodaySales { get; set; }
        public decimal ThisWeekSales { get; set; }
        public int LowStockCount { get; set; }
        public List<TopProductDTO> TopProducts { get; set; } = new();
    }
    public class TopProductDTO
    {
        public string ProductName { get; set; } = "";
        public int SoldQty { get; set; }
    }
}
