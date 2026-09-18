using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Schedule
{
    public long lesson_id { get; set; }

    public int group { get; set; }

    public short discipline { get; set; }

    public short teacher { get; set; }

    public DateOnly? date { get; set; }

    public TimeOnly? time { get; set; }

    public bool spent { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Discipline disciplineNavigation { get; set; } = null!;

    public virtual Group groupNavigation { get; set; } = null!;

    public virtual Teacher teacherNavigation { get; set; } = null!;
}
