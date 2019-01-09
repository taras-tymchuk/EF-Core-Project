namespace EF_Core_Demo.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
