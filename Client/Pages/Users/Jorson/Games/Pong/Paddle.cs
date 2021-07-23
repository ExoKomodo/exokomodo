using System;
using System.Drawing;
using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;

namespace Client.Pages.Users.Jorson.Games.Pong
{
    public class Paddle
    {
        #region Public

        #region Constructors
        public Paddle(PongApp application)
        {
            Application = application;
        }
        #endregion

        #region Members
        public readonly PongApp Application;
        public Rect Body;
        public Color FillColor;
        public float HalfHeight => Body.Height / 2f;
        public float HalfWidth => Body.Width / 2f;
        public uint Score { get; set; }
        public const float Speed = 100f;
        public Color? StrokeColor;
        #endregion
        
        #region Member Methods
        public void Draw()
        {
            Application.Push();
            if (StrokeColor.HasValue)
            {
                Application.Stroke(StrokeColor.Value);
            }
            Application.Fill(FillColor);
            Application.SetRectangleMode(RectangleMode.Center);
            Application.DrawRectangle(Body);
            Application.Pop();
        }

        public void UpdateAi()
        {
            var ball = Application.Ball;
            var delta = Application.DeltaTime;
            if (delta == 0)
            {
                return;
            }

            var plannedMove = Math.Min(
                Math.Abs(Body.Y - ball.Body.Y),
                Speed / delta
            );
            if (Body.Y > ball.Body.Y)
            {
                Body.Y -= plannedMove;
            }
            else if (Body.Y < ball.Body.Y)
            {
                Body.Y += plannedMove;
            }

            Body.Y = Math.Clamp(
                Body.Y,
                HalfHeight,
                Application.Height - HalfHeight
            );
        }

        public void UpdatePlayer()
        {
            Body.Y = Math.Clamp(
                Application.MouseY,
                HalfHeight,
                Application.Height - HalfHeight
            );
        }

        #endregion

        #endregion
    }
}
