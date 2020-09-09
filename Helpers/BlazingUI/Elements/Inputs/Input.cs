using System;
using System.Numerics;

namespace ExoKomodo.Helpers.BlazingUI.Elements.Inputs
{
    public abstract class Input<TId, TInput, TOutput> : Element<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public TOutput Value { get; protected set; }
        #endregion

        #region Member Methods
        public abstract void HandleInput(TInput value);
        #endregion

        #endregion
    }
}
