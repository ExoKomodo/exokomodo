using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using ExoKomodo.Enums;
using ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Monsters;
using ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Planets;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class World : Scene
    {
        #region Public

        #region Constructors
        public World(KaijuApp application)
            : base(application)
        {
            ActiveStates = new HashSet<GameStates>
            {
                GameStates.World,
            };
            _monsters = new List<Monster>();
        }
        #endregion

        #region Members
        public override ISet<GameStates> ActiveStates { get; protected set; }
        public Monster Player { get; private set; }
        #endregion

        #region Member Methods
        public override void Draw()
        {
            DrawSky();
            _planet?.Draw();
            DrawBuildings();
            DrawMonsters();
        }

        public override void HandleInputUp(KeyCodes code)
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

            _planet = new Earth(Application)
            {
                GroundColor = Color.ForestGreen,
                Position = new Vector2(width / 2f, height / 2f),
                Diameter = MathF.Min(width, height) * 0.75f,
            };
            
            _monsters.Clear();
            Player = new Squog(Application)
            {
                CurrentPlanet = _planet,
            };
            _monsters.Add(Player);
        }

        public override void Update()
        {
            TryExit();

            if (Application.IsKeyDown(KeyCodes.A) || Application.IsKeyDown(KeyCodes.Left))
            {
                Player.Move(-Player.BaseVelocity);
            }
            if (Application.IsKeyDown(KeyCodes.D) || Application.IsKeyDown(KeyCodes.Right))
            {
                Player.Move(Player.BaseVelocity);
            }

            _planet?.Update();
            foreach (var monster in _monsters)
            {
                monster.Update();
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private IList<Monster> _monsters { get; set; }
        private Planet _planet { get; set; }
        private bool _shouldExitToMainMenu { get; set; }
        private bool _shouldMoveLeft { get; set; }
        private bool _shouldMoveRight { get; set; }
        #endregion

        #region Member Methods
        private void DrawBuildings()
        {
        }

        private void DrawMonsters()
        {
            foreach (var monster in _monsters)
            {
                monster.Draw();
            }
        }

        private void DrawSky()
        {
            Application.Background(Color.SkyBlue);
        }

        private void TryExit()
        {
            if (_shouldExitToMainMenu)
            {
                Application.GameState = GameStates.MainMenu;
                _shouldExitToMainMenu = false;
            }
        }
        #endregion

        #endregion
    }
}