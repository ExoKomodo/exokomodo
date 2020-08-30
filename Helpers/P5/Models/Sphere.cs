using System;
using System.Numerics;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Sphere
    {
        #region Public

        #region Constructors
        public Sphere(
            float radius,
            uint detailX = MAX_DETAIL,
            uint detailY = MAX_DETAIL
        )
        {
            Radius = radius;
            _detailX = detailX > MAX_DETAIL ? MAX_DETAIL : detailX;
            _detailY = detailY > MAX_DETAIL ? MAX_DETAIL : detailY;
        }
        #endregion

        #region Constants
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
        public float Radius { get; set; }
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