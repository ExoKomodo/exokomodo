using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Rooms;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees
{
    public abstract class Employee
    {
        #region Public

        #region Constants
        public const float Height = UnitHeight * CorporationTycoonApp.UNIT_SCALE;
        public abstract decimal HiringBonus { get; }
        public const float Width = UnitWidth * CorporationTycoonApp.UNIT_SCALE;
        public const float UnitHeight = 0.5f;
        public const float UnitWidth = 0.3f;
        #endregion

        #region Members
        public int Desk { get; set; } = -1;
        public Vector2? DeskPosition
        {
            get
            {
                if (!IsEmployed)
                {
                    return null;
                }
                return 
                    OfficeSpace.Position
                    // Offset X and Y to first desk
                    + (
                        Vector2.One
                        * CorporationTycoonApp.UNIT_SCALE / 2f
                    )
                    // Offset X to employee desk
                    + (
                        new Vector2(CorporationTycoonApp.UNIT_SCALE, 0f)
                        * Desk
                    )
                ;
            }
        }
        public Color FillColor;
        public bool IsEmployed => OfficeSpace is not null && Desk >= 0;
        public Room OfficeSpace { get; set; }
        public abstract decimal Salary { get; }
        public decimal SalaryFactor { get; set; } = 1m;
        public Color StrokeColor;
        public uint StrokeWeight { get; set; } = 0;

        public Vector2 Position
        {
            get => _rect.Position;
            set
            {
                _rect.Position = value;
            }
        }
        #endregion

        #region Member Methods
        public abstract Task Draw();

        public virtual async Task Update(double dt) =>
            await Task.Run(() => {
                _app.Account.Withdraw(
                    (
                        Salary
                        * _app.TimeScale
                        * (decimal)dt
                    ),
                    force: true
                );
            });
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Employee(
            CorporationTycoonApp application,
            Vector2 position,
            Color fillColor,
            Color strokeColor,
            uint strokeWeight
        )
        {
            _app = application;
            _rect = new Rect(
                position,
                new Vector2(Width, Height)
            );
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWeight = strokeWeight;
        }
        #endregion

        #region Members
        protected CorporationTycoonApp _app;
        protected Rect _rect;
        #endregion

        #endregion
    }
}
