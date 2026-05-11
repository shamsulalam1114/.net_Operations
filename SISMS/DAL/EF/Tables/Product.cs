using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public int ReorderLevel { get; set; }

    public int Cid { get; set; }

    public string Status { get; set; } = null!;

    public virtual Category CidNavigation { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<StockLog> StockLogs { get; set; } = new List<StockLog>();
}
