using System;
using System.Collections.Generic;

namespace Database_3.EF.Tables;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Cid { get; set; }

    public virtual Category CidNavigation { get; set; } = null!;
}
