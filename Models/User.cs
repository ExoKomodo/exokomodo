namespace ExoKomodo.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string HomePage => $"/users/{Id}";
    }
}