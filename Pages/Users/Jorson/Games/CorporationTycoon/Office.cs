using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon
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
                  width: 3 * UNIT_SCALE
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
        }

        public override void Update(P5App application, double dt)
        {

        }
        #endregion

        #endregion
    }
}
