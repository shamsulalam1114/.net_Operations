    using System;
using System.Collections.Generic;

namespace Database_1.EF.Tables;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
}
