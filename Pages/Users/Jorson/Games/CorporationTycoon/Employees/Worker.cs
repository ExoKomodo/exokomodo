using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees
{
    public class Worker : Employee
    {
        #region Public

        #region Constructors
        public Worker(CorporationTycoonApp application, Vector2 position)
            : base(
                  application: application,
                  position: position,
                  fillColor: Color.FromArgb(red: 0, green: 64, blue: 0),
                  strokeColor: Color.Black,
                  strokeWeight: 0
            )
        { }
        #endregion

        #region Constants
        public override decimal HiringBonus => 100m;
        #endregion

        #region Members
        public decimal Profit => ProfitFactor * Salary;
        public decimal ProfitFactor { get; set; } = 1.4m;
        public override decimal Salary => 40m * SalaryFactor;
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

        public override async Task Update(double dt) =>
            await Task.Run(async () => {
                await base.Update(dt);

                _app.Account.Deposit(
                    Profit
                    * _app.TimeScale
                    * _app.SupervisionFactor
                    * (decimal)dt
                );
            });
        #endregion

        #endregion
    }
}
