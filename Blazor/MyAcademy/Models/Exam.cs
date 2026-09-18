using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Exam
{
    public int student { get; set; }

    public short discipline { get; set; }

    public DateOnly? date { get; set; }

    public byte? grade { get; set; }

    public virtual Discipline disciplineNavigation { get; set; } = null!;

    public virtual Student studentNavigation { get; set; } = null!;
}
