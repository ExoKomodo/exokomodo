using System.Drawing;
using System.Numerics;
using ExoKomodo.Enums;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class World
    {
        #region Public

        #region Constructors
        public World(KaijuApp application)
        {
            _application = application;
        }
        #endregion

        #region Members
        public float Height { get; set; }
        public float Width { get; set; }
        #endregion

        #region Member Methods
        public void Draw()
        {
            _application.Background(Color.SkyBlue);
        }

        public bool HandleClick(Vector2 clickPosition, bool fallThrough = false)
            => true;
        
        public void HandleHover(Vector2 mousePosition) {}

        public void HandleInput(KeyCodes code)
        {
            switch (code)
            {
                case KeyCodes.Escape:
                    _shouldExitToMainMenu = true;
                    break;
            }
        }

        public void SetUiScale(float width, float height) {}

        public void Setup()
        {
            _shouldExitToMainMenu = false;
        }

        public void Update()
        {
            TryExit();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private KaijuApp _application { get; set; }
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