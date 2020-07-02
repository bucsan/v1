namespace v1.Models
{
    public class MyLoggedUser
    {
        public string Id { get; set; }
        public string  Name { get; set; }
        public string Credentials { get; set; }
        public bool IsAdmin { get; set; }
    }
}