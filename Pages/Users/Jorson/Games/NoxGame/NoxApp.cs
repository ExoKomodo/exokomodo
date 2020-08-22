using System.Collections.Generic;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;

namespace ExoKomodo.Pages.Users.Jorson.Games.NoxGame
{
    public class NoxApp : P5App
    {
        #region Public

        #region Constructors
        public NoxApp(IJSRuntime jsRuntime, string containerId) : base(jsRuntime, containerId)
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

        [JSInvokable("setup")]
        public override void Setup()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            double aspectRatio = isVerticalDisplay ? 4d / 3d : 16d / 9d;
            _width = WindowWidth * 0.75d;
            _height = _width / aspectRatio;
            _clearColor = new Color(32, 32, 32);
            CreateCanvas((uint)_width, (uint)_height);
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Color _clearColor { get; set; }
        private double _height { get; set; }
        private double _width { get; set; }
        #endregion

        #endregion
    }
}