namespace WebApi.Models
{
    public class PersonModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Hmoid { get; set; }

        public string? IdNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? MaleOrFemale { get; set; }
    }
}
