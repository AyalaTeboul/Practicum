using System;
using System.Collections.Generic;

namespace Repository.Entity;

public partial class Person
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Hmoid { get; set; }

    public string? IdNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? MaleOrFemale { get; set; }

    public virtual ICollection<FatherAndChild> FatherAndChildChildren { get; } = new List<FatherAndChild>();
    public virtual ICollection<FatherAndChild> FatherAndChildFathers { get; } = new List<FatherAndChild>();
    public virtual ICollection<FatherAndChild> FatherAndChildMothers { get; } = new List<FatherAndChild>();

    public virtual Hmo? Hmo { get; set; }
}
