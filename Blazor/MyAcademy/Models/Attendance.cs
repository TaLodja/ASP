using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Attendance
{
	public int student { get; set; }

	public long lesson { get; set; }

	public bool present { get; set; }

	public virtual Schedule lessonNavigation { get; set; } = null!;

	public virtual Student studentNavigation { get; set; } = null!;
}