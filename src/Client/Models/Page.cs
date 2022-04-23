namespace Client.Models
{
    public class Page : Model<string>
    {
        public string Name { get; set; }
        public string Link => $"/{Id}";
        public string LinkOverride { get; set; }
        public bool IsDisabled { get; set; }
    }
}