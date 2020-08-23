using System;
using System.Collections.Generic;
using ExoKomodo.Pages.Users.Jorson.Helpers;

namespace ExoKomodo.Pages.Users.Jorson.Models
{
    public class TextAdventureInventory
    {
        #region Public

        #region Constructors
        public TextAdventureInventory()
        {
            _inventory = new Dictionary<string, Item>();
        }
        #endregion

        #region Members
        public IDictionary<string, Item> _inventory { get; private set; }
        #endregion

        #region Member Methods
        public bool HasItem(Item item)
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