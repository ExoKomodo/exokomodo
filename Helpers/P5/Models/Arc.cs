using System;
using System.Numerics;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Arc
    {
        #region Public

        #region Constructors
        public Arc(
            float x,
            float y,
            float width,
            float height,
            float startAngle,
            float stopAngle,
            ArcMode mode = ArcMode.Pie,
            uint detail = DEFAULT_DETAIL
        ) : this(
            new Vector2(x, y),
            new Vector2(width, height),
            startAngle,
            stopAngle,
            mode,
            detail
        ) {}

        public Arc(
            Vector2 position,
            Vector2 dimensions,
            float startAngle,
            float stopAngle,
            ArcMode mode = ArcMode.Pie,
            uint detail = DEFAULT_DETAIL
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
        public float StartAngle { get; set; }
        public float StopAngle { get; set; }
        public ArcMode Mode{ get; set; }
        public uint Detail { get; set; }
        #endregion

        #region Static Methods
        public static string ArcModeToString(ArcMode mode) => mode switch
        {
            ArcMode.Chord => "chord",
            ArcMode.Open => "open",
            ArcMode.Pie => "pie",
            _ => throw new Exception("Invalid ArcMode"),
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