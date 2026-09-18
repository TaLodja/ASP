using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Direction
{
    public byte direction_id { get; set; }

    public string? direction_name { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Discipline> disciplines { get; set; } = new List<Discipline>();
}
