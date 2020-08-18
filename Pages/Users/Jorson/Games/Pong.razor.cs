using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Pages.Users.Jorson.Games
{
    public partial class Pong : IDisposable
    {
        #region Public

        #region Constructors
        public Pong()
        {
            _base = new PongBase();
            _base.Initialize();
        }
        #endregion

        #region Constants
        public const string UserId = "jorson";
        #endregion

        #region Member Methods
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            _base.Dispose();
            _application.Dispose();

            GC.SuppressFinalize(this);
            _isDisposed = true;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override async Task OnInitializedAsync()
        {
            _self = (await _http.GetFromJsonAsync<List<User>>("data/users.json")).Where(user => user.Id == UserId).FirstOrDefault();
            if (_self == null)
            {
                throw new Exception($"Could not find user {UserId}");
            }

            _application = new PongApplication(_jsRuntime, "pong-container");
            _application.Start();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private P5App _application { get; set; }
        [Inject]
        private HttpClient _http { get; set; }
        private bool _isDisposed { get; set; }
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private PageBase _base { get; set; }
        private User _self;
        #endregion

        #region Classes

        private class PongBase : PageBase
        {
            #region Public

            #region Member Methods
            public override void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
            #endregion

            #endregion
        }

        private class Ball
        {
            public Ball(PongApplication application)
            {
                Application = application;
                _direction = new Vector2(1, 0.7);
            }
            public readonly PongApplication Application;
            public Circle Body { get; set; }
            public double Speed { get; set; }
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
                Application.NoStroke();
                Application.Fill(255);
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
                    Speed += 2.5;
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

            private Vector2 _direction;
        }

        private class Paddle
        {
            public readonly PongApplication Application;
            public const double Speed = 100;
            public uint Score { get; set; }
            public double HalfHeight => Body.Height / 2;
            public double HalfWidth => Body.Width / 2;
            public Rectangle Body { get; set; }
            public Paddle(PongApplication application)
            {
                Application = application;
            }
            public void Draw()
            {
                Application.Push();
                Application.NoStroke();
                Application.Fill(255);
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
        }

        private class PongApplication : P5App
        {
            #region Public

            #region Constructors
            public PongApplication(IJSRuntime jsRuntime, string containerId) : base(jsRuntime, containerId)
            {
                _paddles = new List<Paddle>
                {
                    new Paddle(this),
                    new Paddle(this),
                };
                Ball = new Ball(this);
            }
            #endregion

            #region Members
            public Ball Ball { get; set; }
            public Paddle PaddleOne => _paddles[0];
            public Paddle PaddleTwo => _paddles[1];
            #endregion

            #region Member Methods
            [JSInvokable("draw")]
            public override void Draw()
            {
                Background(new Color(150, 250, 150));

                PaddleOne.UpdatePlayer();
                PaddleTwo.UpdateAi();
                if (Ball.Update())
                {
                    ResetBall();
                }
                foreach (var paddle in _paddles)
                {
                    paddle.Draw();
                }
                Ball.Draw();

                Push();
                SetTextAlign(HorizontalTextAlign.Center, VerticalTextAlign.Top);
                SetTextSize(32);
                DrawText(
                    $"{PaddleOne.Score} - {PaddleTwo.Score}",
                    Width / 2,
                    10
                );
                Pop();
            }

            [JSInvokable("preload")]
            public override void Preload()
            {
                _image = LoadImage("assets/jorson/knuckles.jpg");
                _font = LoadFont("assets/jorson/Roboto-Regular.ttf");
            }

            public void Reset()
            {
                ResetBall();

                var paddleDimensions = new Vector2(Width / 20, Height / 10);
                PaddleOne.Body = new Rectangle(
                    new Vector2(paddleDimensions.X * 2, Height / 2),
                    paddleDimensions
                );
                PaddleTwo.Body = new Rectangle(
                    new Vector2(Width - (paddleDimensions.X * 2), Height / 2),
                    paddleDimensions
                );
            }

            public void ResetBall()
            {
                Ball.Speed = 30;
                Ball.Body = new Circle(Width / 2, Height / 4, Width / 30);
            }

            [JSInvokable("setup")]
            public override void Setup()
            {
                _clearColor = new Color(hue: 0, saturation: 255, brightness: 255);
                CreateCanvas(600, 600);
                SetImageFields(_image);

                Reset();
            }
            #endregion

            #endregion

            #region Private

            #region Members
            private Color _clearColor { get; set; }
            private Font _font { get; set; }
            private IList<Paddle> _paddles { get; set; }
            private Image _image { get; set; }
            #endregion

            #endregion
        }

        #endregion

        #endregion
    }
}