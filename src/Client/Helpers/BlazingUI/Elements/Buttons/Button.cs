using System;
using System.Numerics;

namespace Client.Helpers.BlazingUI.Elements.Buttons
{
    public abstract class Button<TId> : Element<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Event Args
        public abstract class ClickEventArgs<TButton>
            : EventArgs
            where TButton : Button<TId>
        {
            #region Public

            #region Members
            public readonly Vector2 ClickPosition;
            #endregion

            #endregion

            #region Protected

            #region Constructors
            public ClickEventArgs(TButton clickedButton, Vector2 clickPosition)
            {
                _clickedButton = clickedButton;
                ClickPosition = clickPosition;
            }
            #endregion

            #region Members
            protected readonly Button<TId> _clickedButton;
            #endregion

            #endregion
        }
        #endregion

        #region Member Methods
        public abstract void Click();
        #endregion

        #endregion
    }
}
