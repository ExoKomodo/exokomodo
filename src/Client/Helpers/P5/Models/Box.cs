using System;
using System.Numerics;
using Client.Helpers.P5.Enums;

namespace Client.Helpers.P5.Models
{
    public struct Box
    {
        #region Public

        #region Constructors
        public Box(
            float width,
            float height,
            float depth,
            uint detailX = DEFAULT_DETAIL,
            uint detailY = DEFAULT_DETAIL
        ) : this(
            new Vector3(width, height, depth),
            detailX,
            detailY
        ) {}

        public Box(
            Vector3 dimensions,
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
        public const uint DEFAULT_DETAIL = 4;
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
        public float Depth
        {
            get => Dimensions.Z;
            set => _dimensions.Z = value;
        }
        public Vector3 Dimensions
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
        private Vector3 _dimensions;
        #endregion

        #endregion
    }
}