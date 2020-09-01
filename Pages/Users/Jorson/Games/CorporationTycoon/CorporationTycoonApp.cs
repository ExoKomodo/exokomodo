using System;
using System.Drawing;
using System.Linq;
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
        ) : base(jsRuntime, containerId) {}
        #endregion

        #region Constants
        public const decimal GAME_OVER_BALANCE = -1_000m;
        public const uint UNIT_SCALE = 100;
        #endregion

        #region Members
        public Bank Account { get; set; }
        public string CurrencySymbol { get; set; } = "$";
        public decimal SupervisionFactor { get; private set; }
        public decimal TimeScale { get; private set; } = 0.25m;
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

        [JSInvokable("keyPressed")]
        public override bool KeyPressed()
        {
            switch (Key)
            {
                case "1":
                    _roomType = typeof(Office);
                    if (!(_hoverRoom is Office))
                    {
                        _hoverRoom = new Office(this, Vector2.Zero);
                    }
                    break;
                case "2":
                    _roomType = typeof(PrivateOffice);
                    if (!(_hoverRoom is PrivateOffice))
                    {
                        _hoverRoom = new PrivateOffice(this, Vector2.Zero);
                    }
                    break;
                default:
                    break;
            }

            return true; // Event prevent default
        }

        [JSInvokable("mousePressed")]
        public override bool MousePressed()
        {
            switch (MouseButton)
            {
                case MouseButtons.Left:
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
            Reset();
        }
        #endregion

        #endregion

        #region Private

        #region Constants
        private const decimal OPTIMAL_SUPERVISION_RATIO = 6m;
        #endregion

        #region Members
        private Color _clearColor { get; set; }
        private Corporation _corporation { get; set; }
        private float _height { get; set; }
        private Room _hoverRoom { get; set; }
        private Employee _hoverEmployee { get; set; }
        private Type _roomType { get; set; }
        private GameState _state { get; set; }
        private float _width { get; set; }
        #endregion

        #region Member Methods
        private void CalculateSupervisionFactor()
        {
            SupervisionFactor = 0m;
            decimal workerCount = 0m;
            decimal supervisorCount = 0m;

            foreach (var room in _corporation)
            {
                var workers = room?.Employees?.Where(employee => employee is Worker)?.ToList();
                workerCount += workers is null ? 0 : workers.Count;

                var supervisors = room?.Employees?.Where(employee => employee is Supervisor)?.ToList();
                supervisorCount += supervisors is null ? 0 : supervisors.Count;
            }

            if (supervisorCount == 0)
            {
                SupervisionFactor = 1m;
                return;
            }
            var ratio = workerCount / supervisorCount;
            var difference = 1 + Math.Abs(OPTIMAL_SUPERVISION_RATIO - ratio);
            SupervisionFactor = Math.Max(
                0.1m,
                (
                    workerCount / OPTIMAL_SUPERVISION_RATIO
                )
                / difference
            );
        }

        private Vector2 ClampPositionToGridLines()
        {
            return new Vector2(
                MathF.Floor(MouseX / UNIT_SCALE),
                MathF.Floor(MouseY / UNIT_SCALE)
            ) * UNIT_SCALE;
        }

        private Room CreateRoom(Vector2 position)
        {
            if (_roomType == typeof(Office))
            {
                return new Office(this, position);
            }
            if (_roomType == typeof(PrivateOffice))
            {
                return new PrivateOffice(this, position);
            }
            throw new NotImplementedException("Room type not implemented");
        }

        private void DrawCorporation()
        {
            foreach (var room in _corporation)
            {
                room?.Draw();
            }
        }

        private void DrawHoverElements()
        {
            var position = ClampPositionToGridLines();
            var room = _corporation.Get(position);
            if (room is null)
            {
                if (!_corporation.IsValidPlacement(_hoverRoom, position))
                {
                    return;
                }
                DrawHoverRoom(position);
            }
            else
            {
                DrawHoverEmployee(room, position);
            }
        }

        private void DrawHoverEmployee(Room room, Vector2 position)
        {
            var renderPosition = position + (Vector2.One * UNIT_SCALE / 2f);
            switch (room)
            {
                case Office:
                    if (!(_hoverEmployee is Worker))
                    {
                        _hoverEmployee = new Worker(this, Vector2.Zero);
                    }
                    break;
                case PrivateOffice:
                    if (!(_hoverEmployee is Supervisor))
                    {
                        _hoverEmployee = new Supervisor(this, Vector2.Zero);
                    }
                    break;
                default:
                    throw new NotImplementedException($"Room of type {room.GetType()} not yet implemented");
            }
            _hoverEmployee.FillColor = Color.FromArgb(
                red: _hoverEmployee.FillColor.R,
                green: _hoverEmployee.FillColor.G,
                blue: _hoverEmployee.FillColor.B,
                alpha: 150
            );
            _hoverEmployee.Position = renderPosition;
            _hoverEmployee.Draw();
        }

        private void DrawHoverRoom(Vector2 position)
        {
            _hoverRoom.FillColor = Color.FromArgb(
                red: _hoverRoom.FillColor.R,
                green: _hoverRoom.FillColor.G,
                blue: _hoverRoom.FillColor.B,
                alpha: 150
            );
            _hoverRoom.Position = position;
            _hoverRoom.Draw();
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
                        room = CreateRoom(position);
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
                PrivateOffice privateOffice => privateOffice.Hire(new Supervisor(this, hirePosition)),
                _ => throw new NotImplementedException($"Room of type {room.GetType()} not yet implemented"),
            };
        }

        private void InitializeCanvas()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.8f;
            _height = _width / aspectRatio;
            _clearColor = Color.FromArgb(red: 0, green: 64, blue: 64);
            CreateCanvas((uint)(_width / 100) * 100, (uint)(_height / 100) * 100);
        }

        private void PostUpdate()
        {
            if (Account.Balance <= GAME_OVER_BALANCE)
            {
                Reset();
            }
        }

        private void PreUpdate()
        {
            CalculateSupervisionFactor();
        }

        private void Reset()
        {
            Account = new Bank(10_000m);
            _corporation = new Corporation(
                (uint)_width / UNIT_SCALE,
                (uint)_height / UNIT_SCALE,
                UNIT_SCALE
            );
            _roomType = typeof(Office);
            _hoverRoom = new Office(this, Vector2.Zero);
        }

        private void Update(float dt)
        {
            PreUpdate();

            foreach (var room in _corporation)
            {
                room?.Update(dt);
            }

            _hoverRoom.Position = new Vector2(MouseX, MouseY);

            PostUpdate();
        }
        #endregion

        #endregion
    }
}