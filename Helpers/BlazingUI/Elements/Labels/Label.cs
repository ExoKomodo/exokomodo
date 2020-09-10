using System;

namespace ExoKomodo.Helpers.BlazingUI.Elements.Labels
{
    public class Label<TId> : Element<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public string Text { get; set; }
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Label()
        {
            Text = "";
        }
        #endregion

        #endregion
    }
}
