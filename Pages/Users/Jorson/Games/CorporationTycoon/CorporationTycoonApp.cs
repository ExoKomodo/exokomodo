using System.Collections.Generic;
using System.Numerics;
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
        ) : base(jsRuntime, containerId)
        {
            _buildings = new List<Building>();
        }
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Update(DeltaTime / 1_000f);

            Background(_clearColor);

            DrawBuildings();
        }

        [JSInvokable("preload")]
        public override void Preload() {}

        [JSInvokable("setup")]
        public override void Setup()
        {
            InitializeCanvas();

            _buildings.Clear();
            _buildings.Add(new Office(new Vector2(0, 0)));
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IList<Building> _buildings { get; set; }
        private Color _clearColor { get; set; }
        private double _height { get; set; }
        private double _width { get; set; }
        #endregion

        #region Member Methods
        private void DrawBuildings()
        {
            foreach (var building in _buildings)
            {
                building.Draw(this);
            }
        }

        private void InitializeCanvas()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.6f;
            _height = _width / aspectRatio;
            _clearColor = new Color(32, 32, 32);
            CreateCanvas((uint)_width, (uint)_height);
        }

        private void Update(float dt)
        {
            foreach (var building in _buildings)
            {
                building.Update(this, dt);
            }
        }
        #endregion

        #endregion
    }
}