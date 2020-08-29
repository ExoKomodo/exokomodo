using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using System.Numerics;

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
                  fillColor: new Color(red: 0, green: 0, blue: 64),
                  strokeColor: new Color(),
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
        }
        #endregion

        #endregion
    }
}
