namespace ExoKomodo.Helpers.P5.Models
{
    public class Image
    {
        #region Public

        #region Members
        public string Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Vector2 Position => new Vector2(X, Y);
        public double Width { get; set; }
        public double Height { get; set; }
        public Vector2 Dimensions => new Vector2(Width, Height);
        #endregion

        #endregion
    }
}