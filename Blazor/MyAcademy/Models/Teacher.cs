using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Teacher
{
    public short teacher_id { get; set; }

    public string? last_name { get; set; }

    public string? first_name { get; set; }

    public string? middle_name { get; set; }

    public DateOnly? birth_date { get; set; }

    public string? email { get; set; }

    public string? phone { get; set; }

    public byte[]? photo { get; set; }

    public DateOnly? work_since { get; set; }

    public decimal? rate { get; set; }

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Discipline> disciplines { get; set; } = new List<Discipline>();
}
