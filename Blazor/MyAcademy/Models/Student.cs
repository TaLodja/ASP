using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Student
{
    public int stud_id { get; set; }

    public string last_name { get; set; } = null!;

    public string first_name { get; set; } = null!;

    public string? middle_name { get; set; }

    public DateOnly birth_date { get; set; }

    public string? email { get; set; }

    public string? phone { get; set; }

    public byte[]? photo { get; set; }

    public int? group { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Group? groupNavigation { get; set; }
}
