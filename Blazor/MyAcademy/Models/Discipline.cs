using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAcademy.Models;

public partial class Discipline
{
    [Key]
    public short discipline_id { get; set; }

    public string? discipline_name { get; set; }

    public int number_of_lessons { get; set; }

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Discipline> dependent_disciplines { get; set; } = new List<Discipline>();

    public virtual ICollection<Direction> directions { get; set; } = new List<Direction>();

    public virtual ICollection<Discipline> disciplines { get; set; } = new List<Discipline>();

    public virtual ICollection<Discipline> disciplinesNavigation { get; set; } = new List<Discipline>();

    public virtual ICollection<Group> groups { get; set; } = new List<Group>();

    public virtual ICollection<Discipline> required_disciplines { get; set; } = new List<Discipline>();

    public virtual ICollection<Teacher> teachers { get; set; } = new List<Teacher>();
}
