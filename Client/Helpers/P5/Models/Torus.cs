using System;
using System.Numerics;
using Client.Helpers.P5.Enums;

namespace Client.Helpers.P5.Models
{
    public struct Torus
    {
        #region Public

        #region Constructors
        public Torus(
            float radius,
            float tubeRadius,
            uint detailX = DEFAULT_DETAIL_X,
            uint detailY = DEFAULT_DETAIL_Y
        )
        {
            _detailX = detailX > MAX_DETAIL_X ? MAX_DETAIL_X : detailX;
            _detailY = detailY > MAX_DETAIL_Y ? MAX_DETAIL_Y : detailY;
            Radius = radius;
            TubeRadius = tubeRadius;
        }
        #endregion

        #region Constants
        public const uint DEFAULT_DETAIL_X = 24;
        public const uint DEFAULT_DETAIL_Y = 16;
        public const uint MAX_DETAIL_X = 24;
        public const uint MAX_DETAIL_Y = 16;
        #endregion

        #region Members
        public uint DetailX
        {
            get => _detailX;
            set => _detailX = value > MAX_DETAIL_X ? MAX_DETAIL_X : value;
        }
        public uint DetailY
        {
            get => _detailY;
            set => _detailY = value > MAX_DETAIL_Y ? MAX_DETAIL_Y : value;
        }
        public float Radius { get; set; }
        public float TubeRadius { get; set; }
        #endregion

        #endregion

        #region Private

        #region Members
        private uint _detailX { get; set; }
        private uint _detailY { get; set; }
        #endregion

        #endregion
    }
}