using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers;
using System.Numerics;


namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Buildings
{
    public abstract class Building : GridEntry
    {
        #region Public

        #region Constants
        public const float Height = UnitHeight * CorporationTycoonApp.UNIT_SCALE;
        public const float UnitHeight = 1f;
        #endregion

        #region Members
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public uint StrokeWeight { get; set; } = 0;

        public override Vector2 Position
        {
            get => _rect.Position;
            set
            {
                _rect.Position = value;
            }
        }

        public override float UnitWidth => Width / CorporationTycoonApp.UNIT_SCALE;

        public float Width
        {
            get => _rect.Width;
            set
            {
                _rect.Width = value < 0 ? 0 : value;
            }
        }
        #endregion

        #region Member Methods
        public abstract void Draw(P5App application);

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
                || _employees[desk] != null
            )
            {
                return false;
            }
            _employees[desk] = employee;
            employee.OfficeSpace = this;
            employee.Desk = desk;
            // Start employee at their desk
            employee.Position = employee.DeskPosition.Value;
            return true;
        }

        public abstract void Update(P5App application, double dt);
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Building(
            Vector2 position,
            Color fillColor,
            Color strokeColor,
            uint strokeWeight,
            uint width
        )
        {
            _rect = new Rectangle(
                position,
                new Vector2(width, CorporationTycoonApp.UNIT_SCALE)
            );
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWeight = strokeWeight;

            _employees = new Employee[(int)UnitWidth];
        }
        #endregion

        #region Members
        protected Employee[] _employees;
        protected Rectangle _rect;
        #endregion

        #region Member Methods
        protected void DrawEmployees(P5App application)
        {
            foreach (var employee in _employees)
            {
                employee?.Draw(application);
            }
        }
        #endregion

        #endregion
    }
}
