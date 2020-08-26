using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon
{
    public class CorporationTycoonApp : P5App
    {
        #region Public

        #region Constructors
        public CorporationTycoonApp(
            IJSRuntime jsRuntime,
            string containerId
        ) : base(jsRuntime, containerId) {}
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Background(_clearColor);
        }

        [JSInvokable("preload")]
        public override void Preload() {}

        [JSInvokable("setup")]
        public override void Setup()
        {
            InitializeCanvas();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Color _clearColor { get; set; }
        private double _height { get; set; }
        private double _width { get; set; }
        #endregion

        #region Member Methods
        private void InitializeCanvas()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            double aspectRatio = isVerticalDisplay ? 4d / 3d : 16d / 9d;
            _width = WindowWidth * 0.6d;
            _height = _width / aspectRatio;
            _clearColor = new Color(32, 32, 32);
            CreateCanvas((uint)_width, (uint)_height);
        }
        #endregion

        #endregion
    }
}