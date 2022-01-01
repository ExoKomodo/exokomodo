using System.Numerics;

namespace Client.Helpers.P5.Models
{
    public struct QuadraticVertex
    {
        #region Public

        #region Constructors
        public QuadraticVertex(
            float x1 = 0,
            float y1 = 0,
            float x2 = 0,
            float y2 = 0
        ) : this(new Vector3(x1, y1, 0), new Vector3(x2, y2, 0)) {}
        
        public QuadraticVertex(
            float x1 = 0,
            float y1 = 0,
            float z1 = 0,
            float x2 = 0,
            float y2 = 0,
            float z2 = 0
        ) : this(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2)) {}

        public QuadraticVertex(Vector2 controlPoint, Vector2 anchorPoint)
            : this(
                new Vector3(controlPoint.X, controlPoint.Y, 0),
                new Vector3(anchorPoint.X, anchorPoint.Y, 0)
            ) {}

        public QuadraticVertex(Vector3 controlPoint, Vector3 anchorPoint)
        {
            AnchorPoint = anchorPoint;
            ControlPoint = controlPoint;
        }
        #endregion

        #region Members
        public Vector3 AnchorPoint { get; set; }
        public Vector3 ControlPoint { get; set; }
        #endregion

        #endregion
    }
}