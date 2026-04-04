using System;
using System.Collections.Generic;
namespace recap.EF.Tables;
public partial class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Cgpa { get; set; }
}
