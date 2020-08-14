using System;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public class Ellipse
    {
        #region Public

        #region Constructors
        public Ellipse(
            double x,
            double y,
            double w,
            double? h = null,
            uint detail = 25
        )
        {
            var dimensions = new Vector2(w, (h.HasValue ? h : w).Value);
            var position = new Vector2(x, y);
            _dimensions = dimensions;
            _position = position;
            Detail = detail;
        }

        public Ellipse(
            Vector2 position,
            Vector2 dimensions,
            uint detail = 25
        )
        {
            _dimensions = dimensions;
            _position = position;
            Detail = detail;
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
        public double W
        {
            get => Dimensions.X;
            set => _dimensions.X = value;
        }
        public double H
        {
            get => Dimensions.Y;
            set => _dimensions.Y = value;
        }
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

        public uint Detail { get; set; }
        #endregion

        #region Static Methods
        public static string ToString(EllipseMode mode)
        {
            switch (mode)
            {
                case EllipseMode.Center:
                    return "center";
                case EllipseMode.Corner:
                    return "corner";
                case EllipseMode.Corners:
                    return "corners";
                case EllipseMode.Radius:
                    return "radius";
                default:
                    throw new Exception("Invalid EllipseMode");
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