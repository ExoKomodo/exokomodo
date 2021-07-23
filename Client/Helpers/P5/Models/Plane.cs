using System;
using System.Numerics;
using Client.Helpers.P5.Enums;

namespace Client.Helpers.P5.Models
{
    public struct Plane
    {
        #region Public

        #region Constructors
        public Plane(
            float width,
            float height,
            uint detailX = DEFAULT_DETAIL,
            uint detailY = DEFAULT_DETAIL
        ) : this(
            new Vector2(width, height),
            detailX,
            detailY
        ) {}

        public Plane(
            Vector2 dimensions,
            uint detailX = DEFAULT_DETAIL,
            uint detailY = DEFAULT_DETAIL
        )
        {
            _dimensions = dimensions;
            DetailX = detailX;
            DetailY = detailY;
        }
        #endregion

        #region Constants
        public const uint DEFAULT_DETAIL = 1;
        #endregion

        #region Members
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
        public uint DetailX { get; set; }
        public uint DetailY { get; set; }
        #endregion

        #endregion

        #region Private

        #region Members
        private Vector2 _dimensions;
        #endregion

        #endregion
    }
}