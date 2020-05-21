namespace MusiSoft.Entities
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int MusicalGenreId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ResidenceCity { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}