using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Rooms
{
    public class PrivateOffice : Room
    {
        #region Public

        #region Constructors
        public PrivateOffice(CorporationTycoonApp application, Vector2 position)
            : base(
                  application: application,
                  position: position,
                  fillColor: new Color(red: 128, green: 128, blue: 128),
                  strokeColor: new Color(),
                  strokeWeight: 0,
                  windowStrokeWeight: 0,
                  width: 3 * CorporationTycoonApp.UNIT_SCALE
            )
        { }
        #endregion

        #region Constants
        public override decimal BuildCost => 2_000m * BuildCostFactor;
        public override decimal UpkeepCost => 30m * UpkeepCostFactor;
        #endregion

        #region Member Methods
        public override void Draw()
        {
            _app.Push();

            _app.Fill(FillColor);
            _app.StrokeWeight(StrokeWeight);
            _app.Stroke(StrokeColor);
            _app.DrawRectangle(_rect);

            _app.Pop();

            DrawWindows();
            DrawEmployees();
        }

        public override bool Hire(Employee employee)
        {
            if (employee is Supervisor)
            {
                return base.Hire(employee);
            }
            return false;
        }

        public override void Update(double dt)
        {
            base.Update(dt);
        }
        #endregion

        #endregion
    }
}
