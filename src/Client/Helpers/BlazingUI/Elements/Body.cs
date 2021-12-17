using System;
using System.Numerics;

namespace Client.Helpers.BlazingUI.Elements
{
    public class Body<TId>
        : Element<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Constructors
        public Body()
            : base() {}
        #endregion

        #endregion
    }
}
