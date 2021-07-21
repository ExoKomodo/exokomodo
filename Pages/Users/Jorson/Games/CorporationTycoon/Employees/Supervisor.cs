using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees
{
    public class Supervisor : Employee
    {
        #region Public

        #region Constructors
        public Supervisor(CorporationTycoonApp application, Vector2 position)
            : base(
                  application: application,
                  position: position,
                  fillColor: Color.FromArgb(red: 0, green: 0, blue: 64),
                  strokeColor: Color.Black,
                  strokeWeight: 0
            )
        { }
        #endregion

        #region Constants
        public override decimal HiringBonus => 200m;
        #endregion

        #region Members
        public override decimal Salary => 60m * SalaryFactor;
        #endregion

        #region Member Methods
        public override async Task Draw() =>
            await Task.Run(async () => {
                await _app.Push();

                await _app.SetRectangleMode(RectangleMode.Center);
                await _app.Fill(FillColor);
                await _app.StrokeWeight(StrokeWeight);
                await _app.Stroke(StrokeColor);
                await _app.DrawRectangle(_rect);

                await _app.Pop();
            });

        public override async Task Update(double dt) => await base.Update(dt);
        #endregion

        #endregion
    }
}
