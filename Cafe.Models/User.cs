namespace Cafe.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? Birthday { get; set; } // string (3) //byte
        public IEnumerable<UserRole> UserRoles { get; set; }

        public static User Admin => new User { Id = 1,Name="admin",Password="12345"};

    }

    //Id,Name,Password,Birthday, UserRoleId,UserRoleId
}
