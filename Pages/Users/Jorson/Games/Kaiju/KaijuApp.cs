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
            SetUniform(
                _mandelbrot,
                "r",
                (
                    1.5
                    * Math.Pow(
                        Math.E,
                        -6.5
                        * (
                            1
                            + Math.Sin(
                                Millis
                                / 2000
                            )
                        )
                    )
                )
            );
            DrawQuad(
                -1f, -1f,
                1f, -1f,
                1f, 1f,
                -1f, 1f
            );
        }

        [JSInvokable("preload")]
        public override void Preload()
        {
            _mandelbrot = LoadShader("assets/mandelbrot.vert", "assets/mandelbrot.frag");
            _teapot = LoadModel("assets/teapot.obj", true);
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

            UseShader(_mandelbrot);
            NoStroke();
            SetUniform(
                _mandelbrot,
                "p",
                new double[] {-0.74364388703, 0.13182590421 }
            );
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