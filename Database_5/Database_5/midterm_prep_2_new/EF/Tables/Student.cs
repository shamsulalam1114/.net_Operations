using System;
using System.Collections.Generic;

namespace midterm_prep_2_new.EF.Tables;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cgpa { get; set; }
}