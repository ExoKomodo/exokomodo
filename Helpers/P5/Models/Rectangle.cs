using System;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public class Rectangle
    {
        #region Public

        #region Constructors
        public Rectangle(
            double x,
            double y,
            double w,
            double? h = null,
            double topLeftRadius = 0,
            double topRightRadius = 0,
            double bottomRightRadius = 0,
            double bottomLeftRadius = 0,
            uint detailX = 25,
            uint detailY = 25
        )
        {
            TopLeftRadius = topLeftRadius;
            TopRightRadius = topRightRadius;
            BottomRightRadius = bottomRightRadius;
            BottomLeftRadius = bottomLeftRadius;
            var position = new Vector2(x, y);
            var dimensions = new Vector2(w, (h.HasValue ? h : w).Value);
            _position = position;
            _dimensions = dimensions;
            DetailX = detailX;
            DetailY = detailY;
        }

        public Rectangle(
            Vector2 position,
            Vector2 dimensions,
            double topLeftRadius = 0,
            double topRightRadius = 0,
            double bottomRightRadius = 0,
            double bottomLeftRadius = 0,
            uint detailX = 25,
            uint detailY = 25
        )
        {
            Dimensions = dimensions;
            Position = position;
            TopLeftRadius = topLeftRadius;
            TopRightRadius = topRightRadius;
            BottomRightRadius = bottomRightRadius;
            BottomLeftRadius = bottomLeftRadius;
            DetailX = detailX;
            DetailY = detailY;
        }
        #endregion

        #region Members
        public double X
        {
            get => Position.X;
            set => _position.X = value;
        }
        public double Y
        {
            get => Position.Y;
            set => _position.Y = value;
        }
        public double Width
        {
            get => Dimensions.X;
            set => _dimensions.X = value;
        }
        public double Height
        {
            get => Dimensions.Y;
            set => _dimensions.Y = value;
        }
        public double TopLeftRadius { get; set; }
        public double TopRightRadius { get; set; }
        public double BottomLeftRadius { get; set; }
        public double BottomRightRadius { get; set; }
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
        public static string ToString(RectangleMode mode)
        {
            switch (mode)
            {
                case RectangleMode.Center:
                    return "center";
                case RectangleMode.Corner:
                    return "corner";
                case RectangleMode.Corners:
                    return "corners";
                case RectangleMode.Radius:
                    return "radius";
                default:
                    throw new Exception("Invalid RectangleMode");
            }
        }
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