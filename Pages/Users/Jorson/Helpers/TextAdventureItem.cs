namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class TextAdventureItem
    {
        public string Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is TextAdventureItem other)
            {
                return Equals(other);
            }
            return false;
        }

        public bool Equals(TextAdventureItem other)
        {
            return Id == other.Id;
        }
    }
}