using System.Numerics;

namespace Client.Pages.Users.Jorson.Games.CorporationTycoon.Helpers
{
    public abstract class GridEntry
    {
        #region Public

        #region Members
        public virtual Vector2 Position { get; set; }
        public virtual float UnitWidth { get; }
        #endregion

        #endregion
    }
}