namespace MusiSoft.Entities
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}