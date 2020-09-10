using System;
using System.Linq;
using System.Numerics;
using ExoKomodo.Helpers.BlazingUI.Elements.Containers;
using ExoKomodo.Helpers.BlazingUI.Enums;

namespace ExoKomodo.Helpers.BlazingUI.Elements.Containers
{
    public class VerticalContainer<TId>
        : Container<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Constructors
        public VerticalContainer()
            : base()
        {
            Alignment = LayoutAlign.Center;
            Gap = 10f;
        }
        #endregion

        #region Member Methods
        public override void Render()
        {
            var elementHeightOffset = -(
                Children.Sum(element => element.Height)
                + (
                    Children.Length
                    - 1
                ) * Gap
            ) / 2f;
            for (int i = 0; i < Children.Length; i++)
            {
                var child = Children[i];
                elementHeightOffset += child.HalfHeight;
                var layoutOffset = ContainerHelper.CalculateLayoutOffset(this, child);
                child.RenderPosition = (
                    RenderPosition
                    + layoutOffset
                    + new Vector2(
                        0f,
                        Gap
                        * i
                        + elementHeightOffset
                    )
                );
                child.Render();
                elementHeightOffset += child.HalfHeight;
            }
        }
        #endregion

        #endregion
    }
}
