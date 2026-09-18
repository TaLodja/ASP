using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Salary
{
    public long payment_id { get; set; }

    public short teacher { get; set; }

    public decimal accrued { get; set; }

    public bool received { get; set; }

    public virtual Teacher teacherNavigation { get; set; } = null!;
}
