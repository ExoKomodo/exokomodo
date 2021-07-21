// using System;
// using System.Drawing;
// using System.Numerics;

// namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Planets
// {
//     public class Earth : Planet
//     {
//         #region Public

//         #region Constructors
//         public Earth(KaijuApp application)
//             : base(application)
//         {
//             GroundColor = Color.ForestGreen;
//             Rotation = MathF.PI;
//             RotationSpeed = MathF.PI / 60f;
//         }
//         #endregion

//         #region Member Methods
//         public override void Draw(float baseRotation = 0f)
//         {
//             Application.Push();

//             Application.Translate(Position);
//             Application.Rotate(baseRotation + Rotation);

//             Application.NoStroke();
//             Application.Fill(GroundColor);
//             Application.DrawCircle(_circle);

//             DrawDebugLines();

//             Application.Pop();
//         }
//         #endregion

//         #endregion

//         #region Private

//         #region Member Methods
//         private void DrawDebugLines()
//         {
//             Application.Stroke(Color.Yellow);
//                 Application.DrawLine(
//                     -Vector2.UnitY* Radius,
//                     Vector2.UnitY* Radius
//                 );

//             Application.Stroke(Color.Red);
//                 Application.DrawLine(
//                     -Vector2.UnitX* Radius,
//                     Vector2.UnitX* Radius
//                 );
//         }
//         #endregion

//         #endregion
//     }
// }
