
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
            double diameter
        ) : this(new Vector2(x, y), diameter) {}

        public Circle(
            Vector2 position,
            double diameter
        )
        {
            _position = position;
            Diameter = diameter;
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
        public double Diameter { get; set; }
        public double Radius => Diameter / 2;
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