using System.Collections.Generic;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class TextAdventureInventory
    {
        #region Public

        #region Constructors
        public TextAdventureInventory()
        {
            _inventory = new HashSet<TextAdventureItem>();
        }
        #endregion

        #region Member Methods
        public bool Add(TextAdventureItem item) => item is not null && _inventory.Add(item);
        
        public void Clear() => _inventory.Clear();

        public bool Contains(TextAdventureItem item) => item is not null && _inventory.Contains(item);

        public bool Remove(TextAdventureItem item) => item is not null && _inventory.Remove(item);
        #endregion

        #endregion

        #region Private
        
        #region Members
        private ISet<TextAdventureItem> _inventory { get; set; }
        #endregion

        #endregion
    }
}