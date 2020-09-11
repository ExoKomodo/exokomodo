using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using System.Drawing;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Monsters
{
    public class Squog : Monster
    {
        #region Public

        #region Constructors
        public Squog(KaijuApp application)
            : base(application)
        {
            _body = new Rect(
                position: Vector2.Zero,
                dimensions: new Vector2(40f, 80f)
            );
        }
        #endregion

        #region Members
        public override float BaseVelocity => CurrentPlanet is null ? 0f : CurrentPlanet.Diameter * 30f;
        #endregion

        #region Member Methods
        public override void Draw()
        {
            if (CurrentPlanet is null)
            {
                return;
            }
            Application.Push();

            Application.Fill(Color.DarkSlateGray);

            var translation = CurrentPlanet.EdgePointToPosition(EdgePoint, radiusOffset: _body.Height * 0.5f);
            Application.Translate(translation);
            
            var rotation = CurrentPlanet.EdgePointToRotationAngle(EdgePoint);
            Application.Rotate(rotation);

            Application.SetRectangleMode(RectangleMode.Center);
            Application.DrawRectangle(_body);

            Application.Pop();
        }

        public override void Update()
        {
            base.Update();

        }
        #endregion

        #endregion
    }
}
