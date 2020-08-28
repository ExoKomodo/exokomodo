using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Buildings
{
    public class Office : Building
    {
        #region Public

        #region Constructors
        public Office(Vector2 position)
            : base(
                  position,
                  new Color(red: 128, green: 64, blue: 64),
                  new Color(),
                  strokeWeight: 0,
                  width: 3 * CorporationTycoonApp.UNIT_SCALE
            ) { }
        #endregion

        #region Member Methods
        public override void Draw(P5App application)
        {
            application.Push();

            application.Fill(FillColor);
            application.StrokeWeight(StrokeWeight);
            application.Stroke(StrokeColor);
            application.DrawRectangle(_rect);

            application.Pop();

            DrawEmployees(application);
        }

        public override bool Hire(Employee employee)
        {
            if (employee is Worker)
            {
                return base.Hire(employee);
            }
            return false;
        }

        public override void Update(P5App application, double dt)
        {

        }
        #endregion

        #endregion
    }
}
