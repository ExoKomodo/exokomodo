using System;
using System.Collections.Generic;

namespace Client.Pages.Webring.Jorson.Helpers
{
    public class TextAdventureState<TId> : State<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public IList<TId> Options { get; set; }
        public TextAdventureItem AcquiredItem { get; set; }
        public TextAdventureItem RequiredItem { get; set; }
        public string Text { get; set; }
        public string BlockedText { get; set; }
        public bool IsTerminal => Options is null || Options.Count == 0;
        #endregion

        #endregion
    }
}