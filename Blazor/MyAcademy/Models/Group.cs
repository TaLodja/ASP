using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Group
{
    public int group_id { get; set; }

    public string group_name { get; set; } = null!;

    public byte direction { get; set; }

    public byte? weekdays { get; set; }

    public TimeOnly? start_time { get; set; }

    public DateOnly? start_date { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Direction directionNavigation { get; set; } = null!;

    public virtual ICollection<Discipline> disciplines { get; set; } = new List<Discipline>();
}
