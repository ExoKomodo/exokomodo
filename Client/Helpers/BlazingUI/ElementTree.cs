using System;
using System.Numerics;
using Client.Helpers.BlazingUI.Elements;

namespace Client.Helpers.BlazingUI
{
    public abstract class ElementTree<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public Element<TId> Root { get; protected set; }
        #endregion

        #region Member Methods
        public Element<TId> GetElement(TId id)
            => Root?.GetChildRecursive(id);
        
        public bool HandleClick(Vector2 clickPosition, bool fallThrough = false)
            => Root is not null && Root.HandleClick(clickPosition, fallThrough: fallThrough);

        public void HandleHover(Vector2 mousePosition)
            => Root?.HandleHover(mousePosition);

        public bool RemoveElement(Element<TId> elementToRemove)
            => (
                elementToRemove.Parent?.RemoveChild(elementToRemove)
            ).GetValueOrDefault();

        public bool RemoveElement(TId id)
            => RemoveElement(GetElement(id));

        public void Render()
        {
            Root?.Render();
        }
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected ElementTree()
        {
            Root = new Body<TId>();
        }
        #endregion

        #endregion
    }
}
