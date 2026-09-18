using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Grade
{
    public int student { get; set; }

    public long lesson { get; set; }

    public byte? grade_1 { get; set; }

    public byte? grade_2 { get; set; }

    public virtual Schedule lessonNavigation { get; set; } = null!;

    public virtual Student studentNavigation { get; set; } = null!;
}
