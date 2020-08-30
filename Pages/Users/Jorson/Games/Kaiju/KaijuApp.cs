using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class KaijuApp : P5App
    {
        #region Public

        #region Constructors
        public KaijuApp(IJSRuntime jsRuntime, string containerId) : base(jsRuntime, containerId)
        {
            
        }
        #endregion

        #region Members
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Background(_clearColor);
        }

        [JSInvokable("preload")]
        public override void Preload()
        {
        }

        public void Reset()
        {
        }

        public void ResetBall()
        {
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            InitializeCanvas();
            Reset();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Color _clearColor { get; set; }
        private float _height { get; set; }
        private float _width { get; set; }
        #endregion

        #region Member Methods
        private void InitializeCanvas()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.75f;
            _height = _width / aspectRatio;
            _clearColor = new Color(red:205, green: 102, blue: 94);
            CreateCanvas((uint)_width, (uint)height, useWebGL: true);
        }
        #endregion

        #endregion
    }
}