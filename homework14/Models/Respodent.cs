namespace homework14.Models
{
    public class Respodent
    {
#nullable enable
        public string? Id { get; set; }
#nullable restore
        public string CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
        public double Salary { get; set; }
        public double WorkExperience { get; set; }
        public Address PersonAddress { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int HomeNumber { get; set; }
    }
}
