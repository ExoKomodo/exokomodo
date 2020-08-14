
using System;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public class Arc
    {
        #region Public

        #region Constructors
        public Arc(
            double x,
            double y,
            double w,
            double h,
            double startAngle,
            double stopAngle,
            ArcMode mode = ArcMode.Pie,
            uint detail = 25
        ) : this(
            new Vector2(x, y),
            new Vector2(w, h),
            startAngle,
            stopAngle,
            mode,
            detail
        ) {}

        public Arc(
            Vector2 position,
            Vector2 dimensions,
            double startAngle,
            double stopAngle,
            ArcMode mode = ArcMode.Pie,
            uint detail = 25
        )
        {
            _dimensions = dimensions;
            _position = position;
            StartAngle = startAngle;
            StopAngle = stopAngle;
            Mode = mode;
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
        public double StartAngle { get; set; }
        public double StopAngle { get; set; }
        public ArcMode Mode{ get; set; }
        public uint Detail { get; set; }
        #endregion

        #region Static Methods
        public static string ToString(ArcMode mode)
        {
            switch (mode)
            {
                case ArcMode.Chord:
                    return "chord";
                case ArcMode.Open:
                    return "open";
                case ArcMode.Pie:
                    return "pie";
                default:
                    throw new Exception("Invalid ArcMode");
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