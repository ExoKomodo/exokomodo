
using System;

namespace ExoKomodo.Helpers.P5.Models
{
    public class Circle
    {
        #region Public

        #region Constructors
        public Circle(
            double x,
            double y,
            double d
        ) : this(new Vector2(x, y), d) {}

        public Circle(
            Vector2 position,
            double d
        )
        {
            _position = position;
            D = d;
        }
        #endregion

        #region Members
        public double X
        {
            get => Position.X;
            set => _position.X = value;
        }
        public double Y
        {
            get => Position.Y;
            set => _position.Y = value;
        }
        public double D { get; set; }
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Vector2 _position;
        #endregion

        #endregion
    }
}