using System.Collections.Generic;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class TextAdventureState : State
    {
        #region Public

        #region Members
        public IList<string> Options { get; set; }
        public TextAdventureItem RequiredItem { get; set; }
        public string Text { get; set; }
        #endregion

        #endregion
    }
}