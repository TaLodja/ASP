using System;
using System.Collections.Generic;

namespace MyAcademy.Models;

public partial class Holiday
{
    public byte holiday_id { get; set; }

    public string holiday_name { get; set; } = null!;

    public byte duration { get; set; }

    public byte? month { get; set; }

    public byte? day { get; set; }

    public virtual ICollection<DaysOFF> DaysOFFs { get; set; } = new List<DaysOFF>();
}
