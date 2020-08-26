using System.Numerics;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct CurveVertex
    {
        #region Public

        #region Constructors
        public CurveVertex(
            float x,
            float y,
            float z = 0
        ) : this(new Vector3(x, y, z)) {}
        
        public CurveVertex(Vector3 vertex)
        {
            _vertex = vertex;
        }
        #endregion

        #region Members
        public float X
        {
            get => Vertex.X;
            set => _vertex.X = value;
        }
        public float Y
        {
            get => Vertex.Y;
            set => _vertex.Y = value;
        }
        public float Z
        {
            get => Vertex.Z;
            set => _vertex.Z = value;
        }
        public Vector3 Vertex
        {
            get => _vertex;
            set => _vertex = value;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Vector3 _vertex;
        #endregion

        #endregion
    }
}