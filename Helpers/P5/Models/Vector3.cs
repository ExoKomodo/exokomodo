namespace ExoKomodo.Helpers.P5.Models
{
    public struct Vector3
    {
        #region Public

        #region Constructors
        public Vector3(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #endregion

        #region Members
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        #endregion

        #endregion
    }
}