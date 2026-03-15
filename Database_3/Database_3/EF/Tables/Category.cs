using System;
using System.Collections.Generic;

namespace Database_3.EF.Tables;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
