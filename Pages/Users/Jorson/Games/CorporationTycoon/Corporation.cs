using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Helpers;
using ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon.Rooms;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon
{
    public class Corporation : Grid<Room>
    {
        #region Public

        #region Constructors
        public Corporation(uint width, uint height, uint unitScale)
            : base(width, height, unitScale) {}
        #endregion

        #endregion
    }
}
