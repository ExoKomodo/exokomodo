using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Employees
{
    public class Worker : Employee
    {
        #region Public

        #region Constructors
        public Worker(Vector2 position)
            : base(
                  position,
                  new Color(red: 0, green: 64, blue: 0),
                  new Color(),
                  strokeWeight: 0
            )
        { }
        #endregion

        #region Member Methods
        public override void Draw(P5App application)
        {
            application.Push();

            application.SetRectangleMode(RectangleMode.Center);
            application.Fill(FillColor);
            application.StrokeWeight(StrokeWeight);
            application.Stroke(StrokeColor);
            application.DrawRectangle(_rect);

            application.Pop();
        }

        public override void Update(P5App application, double dt)
        {

        }
        #endregion

        #endregion
    }
}
