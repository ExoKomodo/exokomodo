using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Rooms
{
    public abstract class Room : GridEntry
    {
        #region Public

        #region Constants
        public abstract decimal BuildCost { get; }
        public const float Height = UnitHeight * CorporationTycoonApp.UNIT_SCALE;
        public const float UnitHeight = 1f;
        #endregion

        #region Members
        public decimal BuildCostFactor { get; set; } = 1m;
        public Employee[] Employees { get; protected set; }
        public Color FillColor;
        public override Vector2 Position
        {
            get => _rect.Position;
            set
            {
                _rect.Position = value;
            }
        }
        public Color StrokeColor;
        public uint StrokeWeight { get; set; } = 0;
        public override float UnitWidth => Width / CorporationTycoonApp.UNIT_SCALE;
        public abstract decimal UpkeepCost { get; }
        public decimal UpkeepCostFactor { get; set; } = 1m;
        public float Width
        {
            get => _rect.Width;
            set
            {
                _rect.Width = value < 0 ? 0 : value;
            }
        }
        public Color WindowFillColor => Color.FromArgb(red: 32, green: 32, blue: 32);
        public Color WindowStrokeColor => Color.Black;
        public uint WindowStrokeWeight { get; set; } = 0;
        #endregion

        #region Member Methods
        public abstract Task Draw();

        public virtual bool Hire(Employee employee)
        {
            if (employee is null)
            {
                return false;
            }
            int desk = (int)(
                (
                    employee.Position.X
                    - Position.X
                )
                / CorporationTycoonApp.UNIT_SCALE
            );
            if (
                desk >= Width
                || Employees[desk] is not null
                || !_app.Account.Withdraw(employee.HiringBonus)
            )
            {
                return false;
            }
            Employees[desk] = employee;
            employee.OfficeSpace = this;
            employee.Desk = desk;
            // Start employee at their desk
            employee.Position = employee.DeskPosition.Value;
            return true;
        }

        public virtual async Task Update(double dt) =>
            await Task.Run(async () => {
                _app.Account.Withdraw(
                    (
                        UpkeepCost
                        * _app.TimeScale
                        * (decimal)dt
                    ),
                    force: true
                );

                foreach (var employee in Employees)
                {
                    if (employee is not null)
                    {
                        await employee.Update(dt);
                    }
                }
            });
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Room(
            CorporationTycoonApp application,
            Vector2 position,
            Color fillColor,
            Color strokeColor,
            uint strokeWeight,
            uint windowStrokeWeight,
            uint width
        )
        {
            _app = application;
            _rect = new Rect(
                position,
                new Vector2(width, CorporationTycoonApp.UNIT_SCALE)
            );
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWeight = strokeWeight;
            WindowStrokeWeight = windowStrokeWeight;

            Employees = new Employee[(int)UnitWidth];
        }
        #endregion

        #region Members
        protected CorporationTycoonApp _app;
        protected Rect _rect;
        #endregion

        #region Member Methods
        protected async Task DrawEmployees() =>
            await Task.Run(() => {
                foreach (var employee in Employees)
                {
                    if (employee is not null)
                    {
                        employee.Draw();
                    }
                }
            });

        protected async Task DrawWindows() =>
            await Task.Run(async () => {
                var rootPosition = Position + (
                    Vector2.One
                    * 0.5f
                    * CorporationTycoonApp.UNIT_SCALE
                );
                var windowDimensions = Vector2.One * CorporationTycoonApp.UNIT_SCALE * 0.8f;

                await _app.Push();

                await _app.SetRectangleMode(RectangleMode.Center);
                await _app.Fill(WindowFillColor);
                await _app.StrokeWeight(WindowStrokeWeight);
                await _app.Stroke(WindowStrokeColor);
                for (int i = 0; i < UnitWidth; i++)
                {
                    await _app.DrawRectangle(
                        new Rect(
                            position: rootPosition,
                            dimensions: windowDimensions
                        )
                    );
                    rootPosition.X += CorporationTycoonApp.UNIT_SCALE;
                }

                await _app.Pop();
            });
        #endregion

        #endregion
    }
}
