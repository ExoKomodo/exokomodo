using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace ExoKomodo.Helpers.BlazingUI.Elements
{
    public abstract class Element<TId>
        : IEnumerable<Element<TId>>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public Element<TId>[] Children => _children.Values.ToArray();

        public Vector2 Dimensions;

        public float HalfHeight => Height / 2f;

        public float HalfWidth => Width / 2f;

        public float Height
        {
            get => Dimensions.Y;
            set => Dimensions.Y = value < 0f ? 0f : value;
        }

        public readonly TId Id;

        public bool IsHovered { get; protected set; }

        public uint LocalId { get; protected set; }

        public Vector2 Offset
        {
            get => _offset;
            set
            {
                _cachedRenderPosition = null;
                _offset = value;
            }
        }

        public Element<TId> Parent
        {
            get => _parent;
            protected set
            {
                _cachedRenderPosition = null;
                _parent = value;
            }
        }

        public Vector2 RenderPosition
        {
            get
            {
                if (_cachedRenderPosition.HasValue)
                {
                    return _cachedRenderPosition.Value;
                }
                else if (_renderPositionOverride.HasValue)
                {
                    _cachedRenderPosition = _renderPositionOverride;
                }
                else if (Parent is null)
                {
                    _cachedRenderPosition = Offset;
                }
                else
                {
                    _cachedRenderPosition = Offset + Parent.RenderPosition;
                }
                return _cachedRenderPosition.Value;
            }
            set
            {
                _cachedRenderPosition = null;
                _renderPositionOverride = value;
            }
        }

        public float Width
        {
            get => Dimensions.X;
            set => Dimensions.X = value < 0f ? 0f : value;
        }
        #endregion

        #region Events
        public event EventHandler<EventArgs> OnHoverEnter;
        public event EventHandler<EventArgs> OnHoverExit;
        #endregion

        #region Member Methods
        public bool AddChild(Element<TId> child)
        {
            if (child.Parent is not null)
            {
                return false;
            }
            child.LocalId = _nextLocalId++;
            _children[child.LocalId] = child;
            child.Parent = this;
            return true;
        }

        public virtual bool Contains(Vector2 queryPosition) => new RectangleF(
            RenderPosition.X,
            RenderPosition.Y,
            Width,
            Height
        ).Contains(queryPosition.X, queryPosition.Y);

        public Element<TId> GetChild(TId id) => Children.FirstOrDefault(element => element.Id.Equals(id));

        public Element<TId> GetChildByLocalId(uint localId)
        {
            if (!_children.ContainsKey(localId))
            {
                return null;
            }
            return _children[localId];
        }

        public Element<TId> GetChildRecursive(TId id)
        {
            var element = GetChild(id);
            if (element is not null)
            {
                return element;
            }
            foreach (var child in Children)
            {
                element = child.GetChildRecursive(id);
                if (element is not null)
                {
                    return element;
                }
            }
            return null;
        }

        public virtual bool HandleClick(Vector2 clickPosition, bool fallThrough = false)
        {
            var clickHandled = false;
            foreach (var child in Children)
            {
                if (child.HandleClick(clickPosition, fallThrough: fallThrough))
                {
                    clickHandled = true;
                }
            }
            return clickHandled;
        }

        public virtual void HandleHover(Vector2 mousePosition)
        {
            if (Contains(mousePosition))
            {
                if (!IsHovered)
                {
                    IsHovered = true;
                    OnHoverEnter?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                if (IsHovered)
                {
                    IsHovered = false;
                    OnHoverExit?.Invoke(this, new EventArgs());
                }
            }
            foreach (var child in Children)
            {
                child.HandleHover(mousePosition);
            }
        }

        public bool RemoveChild(Element<TId> elementToRemove)
        {
            if (
                elementToRemove is null
                && !ReferenceEquals(elementToRemove.Parent, this)
            )
            {
                return false;
            }
            elementToRemove.Parent = null;
            return _children.Remove(elementToRemove.LocalId);
        }

        public bool RemoveChild(TId id) => RemoveChild(GetChild(id));

        public bool RemoveChildByLocalId(uint localId)
            => RemoveChild(GetChildByLocalId(localId));

        public bool RemoveChildRecursive(TId id)
        {
            var child = GetChildRecursive(id);
            if (child?.Parent is null)
            {
                return false;
            }
            return child.Parent.RemoveChild(id);
        }

        public virtual void Render()
        {
            foreach (var child in Children)
            {
                child.Render();
            }
        }
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Element()
        {
            _children = new SortedDictionary<uint, Element<TId>>();
        }
        #endregion

        #region Members
        protected IDictionary<uint, Element<TId>> _children { get; set; }
        protected float _height { get; set; }
        protected uint _nextLocalId { get; set; }
        protected Vector2 _offset { get; set; }
        protected Element<TId> _parent { get; set; }
        protected Vector2? _renderPositionOverride { get; set; }
        protected Vector2? _cachedRenderPosition { get; set; }
        protected float _width { get; set; }
        #endregion

        #endregion

        #region Comparer
        protected class ElementComparer : Comparer<uint>
        {
            public override int Compare(uint x, uint y) => x.CompareTo(y);
        }
        #endregion

        #region IEnumerable Support
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<Element<TId>> GetEnumerator()
        {
            foreach (var pair in _children)
            {
                yield return pair.Value;
            }
        }
        #endregion
    }
}
