using System;
using ExoKomodo.Helpers.BlazingUI.Enums;

namespace ExoKomodo.Helpers.BlazingUI.Elements.Containers
{
    public abstract class Container<TId> : Element<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public LayoutAlign Alignment { get; set; }
        public float Gap { get; set; }
        #endregion
        
        #endregion
    }
}
