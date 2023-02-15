using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto_s
{
    public class FatherAndChildDto
    {
        public int FatherAndChildId { get; set; }

        public int? FatherId { get; set; }

        public int? ChildId { get; set; }
        public int? MotherId { get; set; }

      //  public virtual PersonDto? Child { get; set; }
       // public virtual PersonDto? Father { get; set; }
       // public virtual PersonDto? Mother { get; set; }
    }
}
