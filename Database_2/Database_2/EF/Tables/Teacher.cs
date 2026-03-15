using System;
using System.Collections.Generic;

namespace Database_2.EF.Tables;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string Name { get; set; } = null!;

    public string Department { get; set; } = null!;
}
