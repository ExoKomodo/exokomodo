using System;
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

        [JSInvokable("mousePressed")]
        public override bool MousePressed()
        {
            Console.WriteLine("pressed");
            switch (_state)
            {
                case GameState.Default:
                    var position = ClampPositionToGridLines();
                    _grid.Add(new Office(position));
                    break;
                default:
                    break;
            }
            return true; // Event prevent default
        }

        [JSInvokable("preload")]
        public override void Preload() {}

        [JSInvokable("setup")]
        public override void Setup()
        {
            InitializeCanvas();
            _buildings.Clear();
            _grid = new Grid(
                (uint)_width / Building.UNIT_SCALE,
                (uint)_height / Building.UNIT_SCALE
            );
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IList<Building> _buildings { get; set; }
        private Color _clearColor { get; set; }
        private Grid _grid { get; set; }
        private float _height { get; set; }
        private float _width { get; set; }
        private GameState _state { get; set; }
        #endregion

        #region Member Methods
        private Vector2 ClampPositionToGridLines()
        {
            return new Vector2(
                MathF.Floor(MouseX / Building.UNIT_SCALE),
                MathF.Floor(MouseY / Building.UNIT_SCALE)
            ) * Building.UNIT_SCALE;
        }

        private void DrawBuildings()
        {
            foreach (var building in _grid)
            {
                building?.Draw(this);
            }
        }

        private void InitializeCanvas()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.6f;
            _height = _width / aspectRatio;
            _clearColor = new Color(0, 64, 64);
            CreateCanvas((uint)(_width / 100) * 100, (uint)(_height / 100) * 100);
        }

        private void Update(float dt)
        {
            foreach (var building in _grid)
            {
                building?.Update(this, dt);
            }
        }
        #endregion

        #endregion
    }
}