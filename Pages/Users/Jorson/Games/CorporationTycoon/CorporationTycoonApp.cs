using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Rooms;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon
{
    public class CorporationTycoonApp : P5App
    {
        #region Public

        #region Constructors
        public CorporationTycoonApp(
            IJSRuntime JS,
            string containerId
        ) : base(JS, containerId) {}
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
        public override async Task Draw() =>
            await Task.Run(async () => {
                Console.WriteLine("Starting draw");
                await Update(0);//(await DeltaTime) / 1_000f);

                await Background(_clearColor);

                await DrawCorporation();
                Console.WriteLine("Ending draw");
                // await DrawHoverElements();
                // await DrawUi();
            });

        [JSInvokable("keyPressed")]
        public override async Task<bool> KeyPressed() =>
            await Task.Run(async () => {
                switch (await KeyCode)
                {
                    case Enums.KeyCodes.Digit1:
                    case Enums.KeyCodes.NumPad1:
                        _roomType = typeof(Office);
                        if (!(_hoverRoom is Office))
                        {
                            _hoverRoom = new Office(this, Vector2.Zero);
                        }
                        break;
                    case Enums.KeyCodes.Digit2:
                    case Enums.KeyCodes.NumPad2:
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
            });

        [JSInvokable("mousePressed")]
        public override async Task<bool> MousePressed() =>
            await Task.Run(async () => {
                switch (await GetMouseButton())
                {
                    case MouseButtons.Left:
                        await HandleLeftMouse();
                        break;
                    default:
                        break;
                }
                return true; // Event prevent default
            });

        [JSInvokable("setup")]
        public override async Task Setup() =>
            await Task.Run(async () => {
                await InitializeCanvas();
                await Reset();
            });
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

        private Vector2 ClampPositionToGridLines(float mouseX, float mouseY) =>
            new Vector2(
                MathF.Floor(mouseX / UNIT_SCALE),
                MathF.Floor(mouseY / UNIT_SCALE)
            ) * UNIT_SCALE;

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

        private async Task DrawCorporation() =>
            await Task.Run(async () => {
                Console.WriteLine("\tStarting corporation");
                foreach (var room in _corporation)
                {
                    if (room is not null)
                    {
                        await room.Draw();
                    }
                }
                Console.WriteLine("\tEnding corporation");
            });

        private async Task DrawHoverElements() =>
            await Task.Run(async () => {
                var position = ClampPositionToGridLines(await MouseX, await MouseY);
                var room = _corporation.Get(position);
                if (room is null)
                {
                    if (!_corporation.IsValidPlacement(_hoverRoom, position))
                    {
                        return;
                    }
                    await DrawHoverRoom(position);
                }
                else
                {
                    await DrawHoverEmployee(room, position);
                }
            });

        private async Task DrawHoverEmployee(Room room, Vector2 position) =>
            await Task.Run(async () => {
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
                await _hoverEmployee.Draw();
            });

        private async Task DrawHoverRoom(Vector2 position) =>
            await Task.Run(async () => {
                _hoverRoom.FillColor = Color.FromArgb(
                    red: _hoverRoom.FillColor.R,
                    green: _hoverRoom.FillColor.G,
                    blue: _hoverRoom.FillColor.B,
                    alpha: 150
                );
                _hoverRoom.Position = position;
                await _hoverRoom.Draw();
            });

        private async Task DrawUi() =>
            await Task.Run(async () => {
                await DrawUiBalance();
            });

        private async Task DrawUiBalance() =>
            await Task.Run(async () => {
                await Push();
                await Fill(255);
                await SetTextAlign(HorizontalTextAlign.Left, VerticalTextAlign.Top);
                await SetTextSize(20);
                await DrawText(
                    $"Balance: {string.Format($"{{0:{CurrencySymbol}#,##0.00}}", Account.Balance)}",
                    Vector2.One * UNIT_SCALE / 10f
                );
                await Pop();
            });

        private async Task HandleLeftMouse() =>
            await Task.Run(async () => {
                switch (_state)
                {
                    case GameState.Default:
                        var position = ClampPositionToGridLines(await MouseX, await MouseY);
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
            });

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

        private async Task InitializeCanvas() =>
            await Task.Run(async () => {
                var windowWidth = await WindowWidth;
                var windowHeight = await WindowHeight;
                bool isVerticalDisplay = windowWidth / windowHeight < 1;
                float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
                _width = windowWidth * 0.8f;
                _height = _width / aspectRatio;
                _clearColor = Color.FromArgb(red: 0, green: 64, blue: 64);
                await CreateCanvas((uint)(_width / 100) * 100, (uint)(_height / 100) * 100);
            });

        private async Task PostUpdate() =>
            await Task.Run(async () => {
                if (Account.Balance <= GAME_OVER_BALANCE)
                {
                    await Reset();
                }
            });

        private async Task PreUpdate() =>
            await Task.Run(() => {
                CalculateSupervisionFactor();
            });

        private async Task Reset() =>
            await Task.Run(() => {
                Account = new Bank(10_000m);
                _corporation = new Corporation(
                    (uint)_width / UNIT_SCALE,
                    (uint)_height / UNIT_SCALE,
                    UNIT_SCALE
                );
                _roomType = typeof(Office);
                _hoverRoom = new Office(this, Vector2.Zero);
            });

        private async Task Update(float dt) =>
            await Task.Run(async () => {
                await PreUpdate();

                foreach (var room in _corporation)
                {
                    if (room is not null)
                    {
                        await room.Update(dt);
                    }
                }

                _hoverRoom.Position = new Vector2(await MouseX, await MouseY);

                await PostUpdate();
            });
        #endregion

        #endregion
    }
}