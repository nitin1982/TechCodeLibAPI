using System;

namespace TechCodeLib.DTOS
{
    public class AppUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ContactNo { get; set; }
    }
}
