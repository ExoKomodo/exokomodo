using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

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
                  fillColor: Color.FromArgb(red: 128, green: 128, blue: 128),
                  strokeColor: Color.Black,
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
        public override async Task Draw() =>
            await Task.Run(async () => {
                await _app.Push();

                await _app.Fill(FillColor);
                await _app.StrokeWeight(StrokeWeight);
                await _app.Stroke(StrokeColor);
                await _app.DrawRectangle(_rect);

                await _app.Pop();

                await DrawWindows();
                await DrawEmployees();
            });

        public override bool Hire(Employee employee)
        {
            if (employee is Supervisor)
            {
                return base.Hire(employee);
            }
            return false;
        }

        public override async Task Update(double dt) => await base.Update(dt);
        #endregion

        #endregion
    }
}
