using System;
using System.Collections.Generic;
using System.Numerics;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Buildings;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers;
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
        }
        #endregion

        #region Constants
        public const uint UNIT_SCALE = 100;
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Update(DeltaTime / 1_000f);

            Background(_clearColor);

            DrawCorporation();
        }

        [JSInvokable("mousePressed")]
        public override bool MousePressed()
        {
            switch (MouseButton)
            {
                case MouseButtons.LeftMouseButton:
                    HandleLeftMouse();
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
            _corporation = new Grid<Building>(
                (uint)_width / UNIT_SCALE,
                (uint)_height / UNIT_SCALE
            );
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Color _clearColor { get; set; }
        private Grid<Building> _corporation { get; set; }
        private float _height { get; set; }
        private float _width { get; set; }
        private GameState _state { get; set; }
        #endregion

        #region Member Methods
        private Vector2 ClampPositionToGridLines()
        {
            return new Vector2(
                MathF.Floor(MouseX / UNIT_SCALE),
                MathF.Floor(MouseY / UNIT_SCALE)
            ) * UNIT_SCALE;
        }

        private void DrawCorporation()
        {
            foreach (var building in _corporation)
            {
                if (building is null)
                {
                    continue;
                }
                building.Draw(this);
            }
        }

        private void HandleLeftMouse()
        {
            switch (_state)
            {
                case GameState.Default:
                    var position = ClampPositionToGridLines();
                    // If a building exists, add an employee instead
                    var building = _corporation.Get(position);
                    if (building is null)
                    {
                        _corporation.Add(new Office(position));
                        break;
                    }
                    Hire(building, position);
                    break;
                default:
                    break;
            }
        }

        private bool Hire(Building building, Vector2 hirePosition)
        {
            if (building is null)
            {
                return false;
            }
            hirePosition += new Vector2(UNIT_SCALE / 2f, UNIT_SCALE / 2f);
            return building switch
            {
                Office office => office.Hire(new Worker(hirePosition)),
                _ => throw new NotImplementedException($"Building of type {building.GetType()} not yet implemented"),
            };
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
            foreach (var building in _corporation)
            {
                building?.Update(this, dt);
            }
        }
        #endregion

        #endregion
    }
}