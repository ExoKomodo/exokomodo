using Client.Pages.Webring.Jorson.Games.CorporationTycoon.Helpers;
using Client.Pages.Webring.Jorson.Games.CorporationTycoon.Rooms;

namespace Client.Pages.Webring.Jorson.Games.CorporationTycoon
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
