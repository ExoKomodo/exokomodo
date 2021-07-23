using System.Numerics;

namespace Client.Helpers.P5.Models
{
    public struct Line
    {
        #region Public

        #region Constructors
        public Line(
            float x1 = 0,
            float y1 = 0,
            float z1 = 0,
            float x2 = 0,
            float y2 = 0,
            float z2 = 0
        ) : this(new Vector3(x1, y1, z1), new Vector3(x2, y2, z2)) {}

        public Line(Vector3 start, Vector3 end)
        {
            End = end;
            Start = start;
        }
        #endregion

        #region Members
        public Vector3 End { get; set; }
        public Vector3 Start { get; set; }
        #endregion

        #endregion
    }
}