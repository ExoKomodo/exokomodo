using System.Numerics;

namespace ExoKomodo.Helpers.P5.Models
{
    public class Image
    {
        #region Public

        #region Members
        public string Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public Vector2 Position => new Vector2(X, Y);
        public float Width { get; set; }
        public float Height { get; set; }
        public Vector2 Dimensions => new Vector2(Width, Height);
        #endregion

        #endregion
    }
}