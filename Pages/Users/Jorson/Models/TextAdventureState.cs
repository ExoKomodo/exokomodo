using System.Collections.Generic;

namespace ExoKomodo.Pages.Users.Jorson.Models
{
    public class TextAdventureState : State
    {
        #region Public

        #region Members
        public IList<string> Options { get; set; }
        public Item RequiredItem { get; set; }
        public string Text { get; set; }
        #endregion

        #endregion
    }
}