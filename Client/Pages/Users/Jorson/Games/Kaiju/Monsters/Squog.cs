using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using System.Drawing;
using System.Numerics;

namespace Client.Pages.Users.Jorson.Games.Kaiju.Monsters
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
        public override void Draw(float baseRotation = 0f, bool isFocused = false)
        {
            if (CurrentPlanet is null)
            {
                return;
            }
            Application.Push();

            Application.Fill(Color.DarkSlateGray);

            var halfHeight = _body.Height * 0.5f;
            Vector2 translation;
            if (!isFocused)
            {
                translation = CurrentPlanet.EdgePointToPosition(EdgePoint, radiusOffset: halfHeight);
            }
            else
            {
                translation = CurrentPlanet.Position + (-Vector2.UnitY * (CurrentPlanet.Radius + halfHeight));
            }
            Application.Translate(translation);
            
            var rotation = CurrentPlanet.EdgePointToRotationAngle(EdgePoint);
            Application.Rotate(baseRotation + rotation);

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
