using System;
using System.Numerics;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Ellipse
    {
        #region Public

        #region Constructors
        public Ellipse(
            float x,
            float y,
            float width,
            float? height = null,
            uint detail = DEFAULT_DETAIL
        )
        {
            var dimensions = new Vector2(
                width,
                height.HasValue ? height.Value : width
            );
            var position = new Vector2(x, y);
            _dimensions = dimensions;
            _position = position;
            Detail = detail;
        }

        public Ellipse(
            Vector2 position,
            Vector2 dimensions,
            uint detail = DEFAULT_DETAIL
        )
        {
            _dimensions = dimensions;
            _position = position;
            Detail = detail;
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
        public static string EllipseModeToString(EllipseMode mode) => mode switch
        {
            EllipseMode.Center => "center",
            EllipseMode.Corner => "corner",
            EllipseMode.Corners => "corners",
            EllipseMode.Radius => "radius",
            _ => throw new Exception("Invalid EllipseMode"),
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