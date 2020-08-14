namespace ExoKomodo.Helpers.P5.Models
{
    public struct Curve
    {
        #region Public

        #region Constructors
        public Curve(
            double x1,
            double y1,
            double x2,
            double y2,
            double x3,
            double y3,
            double x4,
            double y4
        ) : this(
            new Vector3(x1, y1, 0),
            new Vector3(x2, y2, 0),
            new Vector3(x3, y3, 0),
            new Vector3(x4, y4, 0)
        ) {}

        public Curve(
            double x1,
            double y1,
            double z1,
            double x2,
            double y2,
            double z2,
            double x3,
            double y3,
            double z3,
            double x4,
            double y4,
            double z4
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