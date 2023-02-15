using System;
using System.Collections.Generic;

namespace Repository.Entity;

public partial class FatherAndChild
{
    public int FatherAndChildId { get; set; }

    public int? FatherId { get; set; }
    public int? MotherId { get; set; }

    public int? ChildId { get; set; }

    public virtual Person? Child { get; set; }
    public virtual Person? Mother { get; set; }

    public virtual Person? Father { get; set; }
}
