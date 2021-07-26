namespace Client.Models
{
    public class User : Model<string>
    {
        public string FullName { get; set; }
        public string HomePage => $"/users/{Id}";
    }
}