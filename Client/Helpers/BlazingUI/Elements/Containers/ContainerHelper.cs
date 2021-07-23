using System;
using System.Numerics;
using Client.Helpers.BlazingUI.Enums;

namespace Client.Helpers.BlazingUI.Elements.Containers
{
    public static class ContainerHelper
    {
        #region Public

        #region Static Methods
        public static Vector2 CalculateLayoutOffset<TId, TContainer>(
            TContainer container,
            Element<TId> element
        )
            where TId : IEquatable<TId>
            where TContainer : Container<TId>
        {
            var left = 0f;
            var centerX = (container.Width / 2f) - (element.Width / 2f);
            var right = container.Width - element.Width;

            var top = 0f;
            var centerY = (container.Height / 2f) - (element.Height / 2f);
            var bottom = container.Height - element.Height;

            return container.Alignment switch
            {
                LayoutAlign.TopLeft => new Vector2(left, top),
                LayoutAlign.TopCenter => new Vector2(centerX, top),
                LayoutAlign.TopRight => new Vector2(right, top),

                LayoutAlign.CenterLeft => new Vector2(left, centerY),
                LayoutAlign.Center => new Vector2(centerX, centerY),
                LayoutAlign.CenterRight => new Vector2(right, centerY),

                LayoutAlign.BottomLeft => new Vector2(left, bottom),
                LayoutAlign.BottomCenter => new Vector2(centerX, bottom),
                LayoutAlign.BottomRight => new Vector2(right, bottom),

                _ => throw new Exception("Invalid LayoutAlign"),
            };
        }
        #endregion

        #endregion
    }
}
