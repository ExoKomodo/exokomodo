using ExoKomodo.Helpers.P5.Models;

namespace ExoKomodo.Pages.Users.Jorson.PongGame
{
    public class Ball
    {
        #region Public

        #region Constructors
        public Ball(PongApp application)
        {
            Application = application;
            _direction = new Vector2(1, 0.7);
        }
        #endregion

        #region Members
        public readonly PongApp Application;
        public Circle Body { get; set; }
        public Color FillColor { get; set; }
        public double Speed { get; set; }
        public Color? StrokeColor { get; set; }
        #endregion

        #region Member Methods
        public bool Collides(Paddle paddle)
        {
            if (
                (
                    (Body.X - Body.Radius) > paddle.Body.X + paddle.HalfWidth
                    || (Body.X + Body.Radius) < paddle.Body.X - paddle.HalfWidth
                ) || (
                    (Body.Y - Body.Radius) > paddle.Body.Y + paddle.HalfHeight
                    || (Body.Y + Body.Radius) < paddle.Body.Y - paddle.HalfHeight
                )
            )
            {
                return false;
            }
            return true;
        }

        public void Draw()
        {
            Application.Push();
            if (StrokeColor.HasValue)
            {
                Application.Stroke(StrokeColor.Value);
            }
            Application.Fill(FillColor);
            Application.DrawCircle(Body);
            Application.Pop();
        }

        public bool Update()
        {
            var delta = Application.DeltaTime;
            if (delta == 0)
            {
                return false;
            }
            Body.X += _direction.X * Speed / delta;
            Body.Y += _direction.Y * Speed / delta;
            if (Body.Y - Body.Radius <= 0)
            {
                Body.Y = Body.Radius;
                _direction.Y *= -1;
            }
            var height = Application.Height;
            if (Body.Y + Body.Radius >= height)
            {
                Body.Y = height - Body.Radius;
                _direction.Y *= -1;
            }
            if (
                Collides(Application.PaddleOne)
                || Collides(Application.PaddleTwo)
            )
            {
                Speed += 5;
                if (
                    Body.X < Application.PaddleOne.Body.X + Application.PaddleOne.HalfWidth
                    || Body.X > Application.PaddleTwo.Body.X - Application.PaddleTwo.HalfWidth
                )
                {
                    _direction.Y *= -1;
                }
                else
                {
                    _direction.X *= -1;
                }
            }

            if (Body.X - Body.Radius <= 0)
            {
                Application.PaddleOne.Score++;
                return true;
            }
            if (Body.X + Body.Radius >= Application.Width)
            {
                Application.PaddleTwo.Score++;
                return true;
            }
            return false;
        }

        #endregion

        #endregion

        #region Private

        #region Members
        private Vector2 _direction;
        #endregion

        #endregion
    }

}