using System;
using System.Numerics;
using Client.Helpers.P5.Enums;

namespace Client.Helpers.P5.Models
{
    public struct Cylinder
    {
        #region Public

        #region Constructors
        public Cylinder(
            float radius,
            float height,
            uint detailX = DEFAULT_DETAIL_X,
            uint detailY = DEFAULT_DETAIL_Y,
            bool showBottomCap = true,
            bool showTopCap = true
        )
        {
            Height = height;
            Radius = radius;
            ShowBottomCap = showBottomCap;
            ShowTopCap = showTopCap;
            _detailX = detailX > MAX_DETAIL ? MAX_DETAIL : detailX;
            _detailY = detailY > MAX_DETAIL ? MAX_DETAIL : detailY;
        }
        #endregion

        #region Constants
        public const uint DEFAULT_DETAIL_X = 24;
        public const uint DEFAULT_DETAIL_Y = 1;
        public const uint MAX_DETAIL = 24;
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
        public float Height { get; set; }
        public float Radius { get; set; }
        public bool ShowBottomCap { get; set; }
        public bool ShowTopCap { get; set; }
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