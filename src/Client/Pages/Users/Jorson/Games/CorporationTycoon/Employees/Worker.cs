using Client.Helpers.P5;
using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using System.Drawing;
using System.Numerics;

namespace Client.Pages.Users.Jorson.Games.CorporationTycoon.Employees
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
        public override void Draw()
        {
            _app.Push();

            _app.SetRectangleMode(RectangleMode.Center);
            _app.Fill(FillColor);
            _app.StrokeWeight(StrokeWeight);
            _app.Stroke(StrokeColor);
            _app.DrawRectangle(_rect);

            _app.Pop();
        }

        public override void Update(double dt)
        {
            base.Update(dt);

            _app.Account.Deposit(
                Profit
                * _app.TimeScale
                * _app.SupervisionFactor
                * (decimal)dt
            );
        }
        #endregion

        #endregion
    }
}
