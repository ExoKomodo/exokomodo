using System.Numerics;

namespace Client.Helpers.P5.Models
{
    public struct Square
    {
        #region Public

        #region Constructors
        public Square(
            float x,
            float y,
            float side,
            float topLeftRadius = 0,
            float topRightRadius = 0,
            float bottomRightRadius = 0,
            float bottomLeftRadius = 0
        ) : this(
            new Vector2(x, y),
            side,
            topLeftRadius,
            topRightRadius,
            bottomRightRadius,
            bottomLeftRadius
        ) {}

        public Square(
            Vector2 position,
            float side,
            float topLeftRadius = 0,
            float topRightRadius = 0,
            float bottomRightRadius = 0,
            float bottomLeftRadius = 0
        )
        {
            _position = position;
            Side = side;
            TopLeftRadius = topLeftRadius;
            TopRightRadius = topRightRadius;
            BottomRightRadius = bottomRightRadius;
            BottomLeftRadius = bottomLeftRadius;
        }
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
        public float Side { get; set; }
        public float TopLeftRadius { get; set; }
        public float TopRightRadius { get; set; }
        public float BottomLeftRadius { get; set; }
        public float BottomRightRadius { get; set; }
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Vector2 _position;
        #endregion

        #endregion
    }
}