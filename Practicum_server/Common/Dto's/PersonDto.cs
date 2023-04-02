using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto_s
{
    public class PersonDto
    {
        public int personId { get; set; }

        public string? firstName { get; set; }

        public string? lastName { get; set; }

        public int? hmoid { get; set; }

        public string? idNumber { get; set; }

        public DateTime? dateOfBirth { get; set; }

        public bool? maleOrFemale { get; set; }
    }
}
