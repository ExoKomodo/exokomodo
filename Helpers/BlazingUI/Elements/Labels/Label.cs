using System;

namespace ExoKomodo.Helpers.BlazingUI.Elements.Buttons
{
    public class Label<TId> : Element<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public string Text { get; set; }
        #endregion

        #endregion
    }
}
