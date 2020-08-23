using System;
using System.Collections.Generic;
using ExoKomodo.Pages.Users.Jorson.Helpers;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class TextAdventureInventory
    {
        #region Public

        #region Constructors
        public TextAdventureInventory()
        {
            _inventory = new Dictionary<string, TextAdventureItem>();
        }
        #endregion

        #region Members
        public IDictionary<string, TextAdventureItem> _inventory { get; private set; }
        #endregion

        #region Member Methods
        public bool HasItem(TextAdventureItem item)
        {
            return HasItem(item?.Id);
        }

        public bool HasItem(string itemId)
        {
            return _inventory.ContainsKey(itemId);
        }

        public void Reset()
        {
            _inventory.Clear();
        }
        #endregion

        #endregion
    }
}