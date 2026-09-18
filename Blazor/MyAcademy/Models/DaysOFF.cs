using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class DaysOFF
{
    public DateOnly date { get; set; }

    public byte holiday { get; set; }

    public virtual Holiday holidayNavigation { get; set; } = null!;
}
