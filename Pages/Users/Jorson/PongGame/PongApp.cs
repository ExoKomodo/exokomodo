using System.Collections.Generic;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;

namespace ExoKomodo.Pages.Users.Jorson.PongGame
{
    public class PongApp : P5App
    {
        #region Public

        #region Constructors
        public PongApp(IJSRuntime jsRuntime, string containerId) : base(jsRuntime, containerId)
        {
            _paddles = new List<Paddle>
            {
                new Paddle(this)
                {
                    FillColor = new Color(10, 170, 195)
                },
                new Paddle(this)
                {
                    FillColor = new Color(180, 25, 25)
                },
            };
            Ball = new Ball(this)
            {
                FillColor = new Color(145, 20, 185)
            };
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
                _width / 2,
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

            var paddleDimensions = new Vector2(_width / 40, _height / 10);
            PaddleOne.Body = new Rectangle(
                new Vector2(paddleDimensions.X * 2, _height / 2),
                paddleDimensions
            );
            PaddleTwo.Body = new Rectangle(
                new Vector2(_width - (paddleDimensions.X * 2), _height / 2),
                paddleDimensions
            );
        }

        public void ResetBall()
        {
            Ball.Speed = _width / 10;
            Ball.Acceleration = Ball.Speed / 3;
            Ball.Body = new Circle(_width / 2, _height / 4, _width / 60);
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            double aspectRatio = isVerticalDisplay ? 4d / 3d : 16d / 9d;
            _width = WindowWidth * 0.75d;
            _height = _width / aspectRatio;
            _clearColor = new Color(hue: 0, saturation: 255, brightness: 255);
            CreateCanvas((uint)_width, (uint)_height);
            SetImageFields(_image);

            Reset();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Color _clearColor { get; set; }
        private Font _font { get; set; }
        private double _height { get; set; }
        private Image _image { get; set; }
        private IList<Paddle> _paddles { get; set; }
        private double _width { get; set; }
        #endregion

        #endregion
    }
}