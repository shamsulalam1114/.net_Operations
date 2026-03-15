using System;
using System.Collections.Generic;

namespace Database_5.EF.Tables;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public decimal Price { get; set; }

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;
}
