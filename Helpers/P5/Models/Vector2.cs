namespace ExoKomodo.Helpers.P5.Models
{
    public struct Vector2
    {
        #region Public

        #region Constructors
        public Vector2(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Members
        public double X { get; set; }
        public double Y { get; set; }
        #endregion

        #endregion
    }
}