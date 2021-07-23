using System;
using System.Collections.Generic;

namespace Client.Pages.Users.Jorson.Helpers
{
    public class TextAdventureItem
        : IEquatable<TextAdventureItem>
    {
        #region Public

        #region Constructors
        public TextAdventureItem(string id) 
        {
            this.Id = id;
        }
        #endregion

        #region Members
        public string Id { get; set; }
        #endregion

        #region Member Methods
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion

        #endregion

        #region IEquatable support
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
        #endregion
    }
}