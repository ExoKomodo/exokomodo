using System.Numerics;

namespace Client.Helpers.P5.Models
{
    public struct Triangle
    {
        #region Public

        #region Constructors
        public Triangle(
            float x1,
            float y1,
            float x2,
            float y2,
            float x3,
            float y3
        ) : this(
            new Vector2(x1, y1),
            new Vector2(x2, y2),
            new Vector2(x3, y3)
        ) {}
        
        public Triangle(Vector2 v1, Vector2 v2, Vector2 v3)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
        }
        #endregion

        #region Members
        public Vector2 V1 { get; set; }
        public Vector2 V2 { get; set; }
        public Vector2 V3 { get; set; }
        #endregion

        #endregion
    }
}