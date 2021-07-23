using System;
using System.Linq;
using System.Numerics;
using Client.Helpers.BlazingUI.Elements.Containers;
using Client.Helpers.BlazingUI.Enums;

namespace Client.Helpers.BlazingUI.Elements.Containers
{
    public class HorizontalContainer<TId>
        : Container<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Constructors
        public HorizontalContainer()
            : base()
        {
            Alignment = LayoutAlign.Center;
            Gap = 10f;
        }
        #endregion

        #region Member Methods
        public override void Render()
        {
            var elementWidthOffset = -(
                Children.Sum(element => element.Width)
                + (
                    Children.Length
                    - 1
                ) * Gap
            ) / 2f;
            for (int i = 0; i < Children.Length; i++)
            {
                var child = Children[i];
                elementWidthOffset += child.HalfWidth;
                var layoutOffset = ContainerHelper.CalculateLayoutOffset(this, child);
                child.RenderPosition = (
                    RenderPosition
                    + layoutOffset
                    + new Vector2(
                        Gap
                        * i
                        + elementWidthOffset,
                        0f
                    )
                );
                child.Render();
                elementWidthOffset += child.HalfWidth;
            }
        }
        #endregion

        #endregion
    }
}
