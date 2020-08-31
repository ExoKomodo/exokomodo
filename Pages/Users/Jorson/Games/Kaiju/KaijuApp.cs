using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class KaijuApp : P5App
    {
        #region Public

        #region Constructors
        public KaijuApp(IJSRuntime jsRuntime, string containerId)
            : base(jsRuntime, containerId) {}
        #endregion

        #region Members
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Background(200);

            Pan(_camera, _delta);

            if (FrameCount % 160 == 0)
            {
                _delta *= -1f;
            }

            RotateX(FrameCount * 0.01f);

            Translate(-100f, 0f, 0f);
            for (int i = 0; i < 10; i++)
            {
                Translate(0f, -30f, 0f);
                Push();
                for (int j = 0; j < 10; j++)
                {
                    Translate(30f, 0f, 0f);
                    DrawBox(20f, 20f, 20f);
                }
                Pop();
            }
        }

        [JSInvokable("preload")]
        public override void Preload()
        {
        }

        public void Reset()
        {
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            _clearColor = new Color(200);
            InitializeCanvas();
            Reset();
            _camera = CreateCamera();
            SetCamera(_camera);
            NormalMaterial();
            Pan(_camera, -0.8f);
        }

        [JSInvokable("windowResized")]
        public override void WindowResized()
        {
            QueryWindow();
            ResizeCanvas((uint)_width, (uint)_height);
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Camera _camera { get; set; }
        private float _delta { get; set; } = 0.01f;
        private Color _clearColor { get; set; }
        private float _height { get; set; }
        private Shader _mandelbrot { get; set; }
        private Model3D _teapot { get; set; }
        private float _width { get; set; }
        #endregion

        #region Member Methods
        private void DrawTeapot()
        {
            var frames = FrameCount;
            Push();
            Scale(0.4f);
            RotateX(frames * 0.01f);
            RotateY(frames * 0.01f);
            NormalMaterial();
            DrawModel(_teapot);
            Pop();
        }

        private void InitializeCanvas()
        {
            QueryWindow();
            CreateCanvas((uint)_width, (uint)_height, useWebGl: true);
        }

        private void QueryWindow()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.75f;
            _height = _width / aspectRatio;
        }
        #endregion

        #endregion
    }
}