namespace DOMAIN
{
    public class RespodentDTO
    {
        public int Id { get; set; }
        public string CreateDate { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobPosition { get; set; }
        public double Salary { get; set; }
        public double WorkExperience { get; set; }
        public string Role { get; set; }
        public AddressDTO Address { get; set; }
    }

    public class RespodentAutheDTO : RespodentDTO
    {
        public string Password { get; set; }
    }


    public class Respodent : RespodentDTO
    {

        public string Password { get; set; }
        public new Address Address { get; set; }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class Roles
    {
        public static string Admin = "Admin";
        public static string User = "user";
    }

    public class RefreshTokenDto
    {
        public string token { get; set; }
    }
}
