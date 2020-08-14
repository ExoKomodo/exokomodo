namespace ExoKomodo.Helpers.P5.Models
{
    public struct Bezier
    {
        #region Public

        #region Constructors
        public Bezier(
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
        
        public Bezier(
            Vector3 firstAnchor,
            Vector3 firstControl,
            Vector3 secondControl,
            Vector3 secondAnchor
        )
        {
            FirstAnchor = firstAnchor;
            FirstControl = firstControl;
            SecondControl = secondControl;
            SecondAnchor = secondAnchor;
        }
        #endregion

        #region Members
        public Vector3 FirstAnchor { get; set; }
        public Vector3 FirstControl { get; set; }
        public Vector3 SecondControl { get; set; }
        public Vector3 SecondAnchor { get; set; }
        #endregion

        #endregion
    }
}