namespace ExoKomodo.Helpers.P5.Models
{
    public class Square
    {
        #region Public

        #region Constructors
        public Square(
            double x,
            double y,
            double side,
            double topLeftRadius = 0,
            double topRightRadius = 0,
            double bottomRightRadius = 0,
            double bottomLeftRadius = 0
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
            double side,
            double topLeftRadius = 0,
            double topRightRadius = 0,
            double bottomRightRadius = 0,
            double bottomLeftRadius = 0
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
        public double Side { get; set; }
        public double TopLeftRadius { get; set; }
        public double TopRightRadius { get; set; }
        public double BottomLeftRadius { get; set; }
        public double BottomRightRadius { get; set; }
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