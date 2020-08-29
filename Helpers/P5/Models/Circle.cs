
using System;
using System.Numerics;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Circle
    {
        #region Public

        #region Constructors
        public Circle(
            float x,
            float y,
            float diameter
        ) : this(new Vector2(x, y), diameter) {}

        public Circle(
            Vector2 position,
            float diameter
        )
        {
            _position = position;
            Diameter = diameter;
        }
        #endregion

        #region Members
        public float X
        {
            get => Position.X;
            set => _position.X = value;
        }
        public float Y
        {
            get => Position.Y;
            set => _position.Y = value;
        }
        public float Diameter { get; set; }
        public float Radius => Diameter / 2;
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