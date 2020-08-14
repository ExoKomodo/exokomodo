namespace ExoKomodo.Helpers.P5.Models
{
    public struct Vertex
    {
        #region Public

        #region Constructors
        public Vertex(
            double x = 0,
            double y = 0
        ) : this(new Vector3(x, y, 0)) {}

        public Vertex(
            double x = 0,
            double y = 0,
            double u = 0,
            double v = 0
        ) : this(new Vector3(x, y, 0), new Vector2(u, v)) {}
        
        public Vertex(
            double x = 0,
            double y = 0,
            double z = 0
        ) : this(new Vector3(x, y, z)) {}

        public Vertex(
            double x = 0,
            double y = 0,
            double z = 0,
            double u = 0,
            double v = 0
        ) : this(new Vector3(x, y, z), new Vector2(u, v)) {}

        public Vertex(Vector2 position, Vector2? uv = null)
            : this(
                new Vector3(position.X, position.Y, 0),
                uv
            ) {}

        public Vertex(Vector3 position, Vector2? uv = null)
        {
            _position = position;
            _uv = uv;
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
        public double Z
        {
            get => Position.Z;
            set => _position.Z = value;
        }
        public double? U
        {
            get => UV?.X;
            set
            {
                if (!_uv.HasValue)
                {
                    return;
                }
                if (!value.HasValue)
                {
                    value = 0;
                }
                _uv = new Vector2(value.Value, _uv.Value.Y);
            }
        }
        public double? V
        {
            get => UV?.Y;
            set
            {
                if (!_uv.HasValue)
                {
                    return;
                }
                if (!value.HasValue)
                {
                    value = 0;
                }
                _uv = new Vector2(_uv.Value.X, value.Value);
            }
        }
        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }
        public Vector2? UV
        {
            get => _uv;
            set => _uv = value;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Vector3 _position;
        private Vector2? _uv;
        #endregion

        #endregion
    }
}