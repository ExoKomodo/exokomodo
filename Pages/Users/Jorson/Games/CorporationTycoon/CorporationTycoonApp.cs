using System;
using System.Numerics;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Rooms;
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
            Account = new Bank(10_000m);
        }
        #endregion

        #region Constants
        public const uint UNIT_SCALE = 100;
        #endregion

        #region Members
        public Bank Account { get; set; }
        public string CurrencySymbol { get; set; } = "$";
        public decimal TimeScale { get; private set; } = 1m;
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Update(DeltaTime / 1_000f);

            Background(_clearColor);

            DrawCorporation();
            DrawHoverElements();
            DrawUi();
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
            _corporation = new Grid<Room>(
                (uint)_width / UNIT_SCALE,
                (uint)_height / UNIT_SCALE,
                UNIT_SCALE
            );
            _hoverRoom = new Office(this, Vector2.Zero);
            _hoverEmployee = new Worker(this, Vector2.Zero);
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Color _clearColor { get; set; }
        private Grid<Room> _corporation { get; set; }
        private Room _hoverRoom { get; set; }
        private Employee _hoverEmployee { get; set; }
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
            foreach (var room in _corporation)
            {
                room?.Draw(this);
            }
        }

        private void DrawHoverElements()
        {
            var position = ClampPositionToGridLines();
            if (_corporation.Get(position) is null)
            {
                DrawHoverRoom(position);
            }
            else
            {
                DrawHoverEmployee(position);
            }
        }

        private void DrawHoverEmployee(Vector2 position)
        {
            var renderPosition = position + (Vector2.One * UNIT_SCALE / 2f);
            _hoverEmployee.FillColor.Alpha = 150;
            _hoverEmployee.Position = renderPosition;
            _hoverEmployee.Draw();
        }

        private void DrawHoverRoom(Vector2 position)
        {
            _hoverRoom.FillColor.Alpha = 150;
            _hoverRoom.Position = position;
            _hoverRoom.Draw(this);
        }

        private void DrawUi()
        {
            DrawUiBalance();
        }

        private void DrawUiBalance()
        {
            Push();
            Fill(255);
            SetTextAlign(HorizontalTextAlign.Left, VerticalTextAlign.Top);
            SetTextSize(20);
            DrawText(
                $"Balance: {string.Format($"{{0:{CurrencySymbol}#,##0.00}}", Account.Balance)}",
                Vector2.One * UNIT_SCALE / 10f
            );
            Pop();
        }

        private void HandleLeftMouse()
        {
            switch (_state)
            {
                case GameState.Default:
                    var position = ClampPositionToGridLines();
                    // If a room exists, add an employee instead
                    var room = _corporation.Get(position);
                    if (room is null)
                    {
                        room = new Office(this, position);
                        if (Account.Withdraw(room.BuildCost))
                        {
                            _corporation.Add(room);
                        }
                        break;
                    }
                    Hire(room, position);
                    break;
                default:
                    break;
            }
        }

        private bool Hire(Room room, Vector2 hirePosition)
        {
            if (room is null)
            {
                return false;
            }
            hirePosition += new Vector2(UNIT_SCALE / 2f, UNIT_SCALE / 2f);
            return room switch
            {
                Office office => office.Hire(new Worker(this, hirePosition)),
                _ => throw new NotImplementedException($"Room of type {room.GetType()} not yet implemented"),
            };
        }

        private void InitializeCanvas()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.8f;
            _height = _width / aspectRatio;
            _clearColor = new Color(0, 64, 64);
            CreateCanvas((uint)(_width / 100) * 100, (uint)(_height / 100) * 100);
        }

        private void Update(float dt)
        {
            foreach (var room in _corporation)
            {
                room?.Update(dt);
            }

            _hoverRoom.Position = new Vector2(MouseX, MouseY);
        }
        #endregion

        #endregion
    }
}