using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class StockLog
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public int ProductId { get; set; }

    public int ChangeQty { get; set; }

    public string Reason { get; set; } = null!;

    public int? RefId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
