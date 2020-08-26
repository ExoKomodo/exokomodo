using System.Numerics;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Quad
    {
        #region Public

        #region Constructors
        public Quad(
            float x1,
            float y1,
            float x2,
            float y2,
            float x3,
            float y3,
            float x4,
            float y4
        ) : this(
            new Vector3(x1, y1, 0),
            new Vector3(x2, y2, 0),
            new Vector3(x3, y3, 0),
            new Vector3(x4, y4, 0)
        ) {}

        public Quad(
            float x1,
            float y1,
            float z1,
            float x2,
            float y2,
            float z2,
            float x3,
            float y3,
            float z3,
            float x4,
            float y4,
            float z4
        ) : this(
            new Vector3(x1, y1, z1),
            new Vector3(x2, y2, z2),
            new Vector3(x3, y3, z3),
            new Vector3(x4, y4, z4)
        ) {}

        public Quad(
            Vector2 v1,
            Vector2 v2,
            Vector2 v3,
            Vector2 v4
        ) : this(
            new Vector3(v1.X, v1.Y, 0),
            new Vector3(v2.X, v2.Y, 0),
            new Vector3(v3.X, v3.Y, 0),
            new Vector3(v4.X, v4.Y, 0)
        ) {}
        
        public Quad(
            Vector3 v1,
            Vector3 v2,
            Vector3 v3,
            Vector3 v4
        )
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
        }
        #endregion

        #region Members
        public Vector3 V1 { get; set; }
        public Vector3 V2 { get; set; }
        public Vector3 V3 { get; set; }
        public Vector3 V4 { get; set; }
        #endregion

        #endregion
    }
}