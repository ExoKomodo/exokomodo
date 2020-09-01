using System;
using System.Numerics;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Rectangle
    {
        #region Public

        #region Constructors
        public Rectangle(
            float x,
            float y,
            float width,
            float? height = null,
            float topLeftRadius = 0,
            float topRightRadius = 0,
            float bottomRightRadius = 0,
            float bottomLeftRadius = 0,
            uint detailX = DEFAULT_DETAIL,
            uint detailY = DEFAULT_DETAIL
        )
        {
            TopLeftRadius = topLeftRadius;
            TopRightRadius = topRightRadius;
            BottomRightRadius = bottomRightRadius;
            BottomLeftRadius = bottomLeftRadius;
            var position = new Vector2(x, y);
            var dimensions = new Vector2(
                width,
                height.HasValue ? height.Value : width
            );
            _position = position;
            _dimensions = dimensions;
            DetailX = detailX;
            DetailY = detailY;
        }

        public Rectangle(
            Vector2 position,
            Vector2 dimensions,
            float topLeftRadius = 0,
            float topRightRadius = 0,
            float bottomRightRadius = 0,
            float bottomLeftRadius = 0,
            uint detailX = DEFAULT_DETAIL,
            uint detailY = DEFAULT_DETAIL
        )
        {
            _dimensions = dimensions;
            _position = position;
            TopLeftRadius = topLeftRadius;
            TopRightRadius = topRightRadius;
            BottomRightRadius = bottomRightRadius;
            BottomLeftRadius = bottomLeftRadius;
            DetailX = detailX;
            DetailY = detailY;
        }
        #endregion

        #region Constants
        public const uint DEFAULT_DETAIL = 25;
        #endregion

        #region Members
        public float X
        {
            get => Position.X;
            set => _position.X = value;
        }
        public float Y
        {
            get => Position.Y;
            set => _position.Y = value;
        }
        public float Width
        {
            get => Dimensions.X;
            set => _dimensions.X = value;
        }
        public float Height
        {
            get => Dimensions.Y;
            set => _dimensions.Y = value;
        }
        public float TopLeftRadius { get; set; }
        public float TopRightRadius { get; set; }
        public float BottomLeftRadius { get; set; }
        public float BottomRightRadius { get; set; }
        public Vector2 Dimensions
        {
            get => _dimensions;
            set => _dimensions = value;
        }
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public uint DetailX { get; set; }
        public uint DetailY { get; set; }
        #endregion

        #region Static Methods
        public static string RectangleModeToString(RectangleMode mode) => mode switch
        {
            RectangleMode.Center => "center",
            RectangleMode.Corner => "corner",
            RectangleMode.Corners => "corners",
            RectangleMode.Radius => "radius",
            _ => throw new Exception("Invalid RectangleMode"),
        };
        #endregion

        #endregion

        #region Private

        #region Members
        private Vector2 _dimensions;
        private Vector2 _position;
        #endregion

        #endregion
    }
}