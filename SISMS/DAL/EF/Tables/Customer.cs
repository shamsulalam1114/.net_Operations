using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool IsMember { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
