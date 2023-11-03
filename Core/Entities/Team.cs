using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Team : BaseEntity
{

    public string Name { get; set; } = null!;

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
