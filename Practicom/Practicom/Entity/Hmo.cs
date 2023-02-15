using System;
using System.Collections.Generic;

namespace Repository.Entity;

public partial class Hmo
{
    public int Hmoid { get; set; }

    public string? Hmoname { get; set; }

    public virtual ICollection<Person> People { get; } = new List<Person>();
}
