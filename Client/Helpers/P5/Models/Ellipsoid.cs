using System;
using System.Numerics;
using Client.Helpers.P5.Enums;

namespace Client.Helpers.P5.Models
{
    public struct Ellipsoid
    {
        #region Public

        #region Constructors
        public Ellipsoid(
            float radiusX,
            float radiusY,
            float radiusZ,
            uint detailX = DEFAULT_DETAIL_X,
            uint detailY = DEFAULT_DETAIL_Y
        ) : this(
            new Vector3(radiusX, radiusY, radiusZ),
            detailX,
            detailY
        ) {}

        public Ellipsoid(
            Vector3 dimensions,
            uint detailX = DEFAULT_DETAIL_X,
            uint detailY = DEFAULT_DETAIL_Y
        )
        {
            _detailX = detailX > MAX_DETAIL ? MAX_DETAIL : detailX;
            _detailY = detailY > MAX_DETAIL ? MAX_DETAIL : detailY;
            _dimensions = dimensions;
        }
        #endregion

        #region Constants
        public const uint DEFAULT_DETAIL_X = 24;
        public const uint DEFAULT_DETAIL_Y = 16;
        public const uint MAX_DETAIL = 150;
        #endregion

        #region Members
        public uint DetailX
        {
            get => _detailX;
            set => _detailX = value > MAX_DETAIL ? MAX_DETAIL : value;
        }
        public uint DetailY
        {
            get => _detailY;
            set => _detailY = value > MAX_DETAIL ? MAX_DETAIL : value;
        }
        public Vector3 Dimensions
        {
            get => _dimensions;
            set => _dimensions = value;
        }
        public float RadiusX
        {
            get => Dimensions.X;
            set => _dimensions.X = value;
        }
        public float RadiusY
        {
            get => Dimensions.Y;
            set => _dimensions.Y = value;
        }
        public float RadiusZ
        {
            get => Dimensions.Z;
            set => _dimensions.Z = value;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private uint _detailX { get; set; }
        private uint _detailY { get; set; }
        private Vector3 _dimensions;
        #endregion

        #endregion
    }
}