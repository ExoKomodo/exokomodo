using System.Numerics;

namespace Client.Helpers.P5.Models
{
    public struct Vertex
    {
        #region Public

        #region Constructors
        public Vertex(
            float x = 0,
            float y = 0
        ) : this(new Vector3(x, y, 0)) {}

        public Vertex(
            float x = 0,
            float y = 0,
            float u = 0,
            float v = 0
        ) : this(new Vector3(x, y, 0), new Vector2(u, v)) {}
        
        public Vertex(
            float x = 0,
            float y = 0,
            float z = 0
        ) : this(new Vector3(x, y, z)) {}

        public Vertex(
            float x = 0,
            float y = 0,
            float z = 0,
            float u = 0,
            float v = 0
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
        public float Z
        {
            get => Position.Z;
            set => _position.Z = value;
        }
        public float? U
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
        public float? V
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