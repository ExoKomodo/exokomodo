namespace ExoKomodo.Helpers.P5.Models
{
    public struct BezierVertex
    {
        #region Public

        #region Constructors
        public BezierVertex(
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
            new Vector3(x2, y2, z2),
            new Vector3(x3, y3, z3),
            new Vector3(x4, y4, z4)
        ) {}
        
        public BezierVertex(
            Vector3 firstControl,
            Vector3 secondControl,
            Vector3 secondAnchor
        )
        {
            FirstControl = firstControl;
            SecondControl = secondControl;
            SecondAnchor = secondAnchor;
        }
        #endregion

        #region Members
        public Vector3 FirstControl { get; set; }
        public Vector3 SecondControl { get; set; }
        public Vector3 SecondAnchor { get; set; }
        #endregion

        #endregion
    }
}