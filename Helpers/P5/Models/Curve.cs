using System.Numerics;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Curve
    {
        #region Public

        #region Constructors
        public Curve(
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

        public Curve(
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

        public Curve(
            Vector2 beginningControl,
            Vector2 firstPoint,
            Vector2 secondPoint,
            Vector2 endingControl
        ) : this(
            new Vector3(beginningControl.X, beginningControl.Y, 0),
            new Vector3(firstPoint.X, firstPoint.Y, 0),
            new Vector3(secondPoint.X, secondPoint.Y, 0),
            new Vector3(endingControl.X, endingControl.Y, 0)
        ) {}
        
        public Curve(
            Vector3 beginningControl,
            Vector3 firstPoint,
            Vector3 secondPoint,
            Vector3 endingControl
        )
        {
            BeginningControl = beginningControl;
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            EndingControl = endingControl;
        }
        #endregion

        #region Members
        public Vector3 BeginningControl { get; set; }
        public Vector3 FirstPoint { get; set; }
        public Vector3 SecondPoint { get; set; }
        public Vector3 EndingControl { get; set; }
        #endregion

        #endregion
    }
}