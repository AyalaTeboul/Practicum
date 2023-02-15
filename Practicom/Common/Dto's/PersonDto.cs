using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto_s
{
    public class PersonDto
    {
        public int PersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Hmoid { get; set; }

        public string? IdNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? MaleOrFemale { get; set; }
    }
}
