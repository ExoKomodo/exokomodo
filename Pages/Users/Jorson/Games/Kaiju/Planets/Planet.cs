using ExoKomodo.Helpers.P5.Models;
using System;
using System.Drawing;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Planets
{
    public abstract class Planet
    {
        #region Public

        #region Constructors
        public Planet(KaijuApp application)
        {
            Application = application;

            _circle = new Circle();
        }
        #endregion

        #region Members
        public KaijuApp Application { get; private set; }
        public float Circumference
        {
            get => MathF.PI * MathF.Pow(Radius, 2f);
            set => Radius = MathF.Sqrt(value / MathF.PI);
        }
        public float Diameter
        {
            get => _circle.Diameter;
            set => _circle.Diameter = value;
        }
        public Color GroundColor { get; set; }
        public Vector2 Position { get; set; }
        public float Radius
        {
            get => _circle.Diameter / 2f;
            set => _circle.Diameter = value * 2f;
        }
        public float Rotation { get; set; }
        public float RotationSpeed { get; set; }
        #endregion

        #region Member Methods
        public abstract void Draw();

        public Vector2 EdgePointToPosition(float edgePoint, float radiusOffset = 0f)
        {
            var position = Vector2.Transform(
                position: Vector2.UnitY,
                matrix: Matrix3x2.CreateRotation(
                    radians: EdgePointToRotationAngle(edgePoint),
                    centerPoint: Vector2.Zero
                )
            );
            return position * (Radius + radiusOffset) + Position;
        }

        public float EdgePointToRotationAngle(float edgePoint)
        {
            var circumference = Circumference;
            float circumferenceRatio = circumference == 0f ? 0 : edgePoint / circumference;
            return circumferenceRatio * 2f * MathF.PI + Rotation;
        }

        public void Update()
        {
            _delta = Application.DeltaTime / 1_000f;

            Rotation += RotationSpeed * _delta;
        }
        #endregion

        #endregion

        #region Protected

        #region Members
        protected Circle _circle;
        private float _delta;
        #endregion

        #endregion
    }
}
