using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using ExoKomodo.Enums;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class World : Scene
    {
        #region Public

        #region Constructors
        public World(KaijuApp application)
            : base(application) {}
        #endregion

        #region Members
        public override ISet<GameStates> ActiveStates { get; protected set; }
            = new HashSet<GameStates>
            {
                GameStates.World,
            };
        #endregion

        #region Member Methods
        public override void Draw()
        {
            _application.Background(Color.SkyBlue);
        }

        public override void HandleInput(KeyCodes code)
        {
            switch (code)
            {
                case KeyCodes.Escape:
                    _shouldExitToMainMenu = true;
                    break;
            }
        }

        public override void Setup(float width, float height)
        {
            _shouldExitToMainMenu = false;
            SetUiScale(width, height);
        }

        public override void Update()
        {
            TryExit();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private bool _shouldExitToMainMenu { get; set; }
        #endregion

        #region Member Methods
        private void TryExit()
        {
            if (_shouldExitToMainMenu)
            {
                _application.GameState = GameStates.MainMenu;
                _shouldExitToMainMenu = false;
            }
        }
        #endregion

        #endregion
    }
}