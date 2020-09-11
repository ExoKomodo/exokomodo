using ExoKomodo.Enums;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Ui;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class KaijuApp : P5App
    {
        #region Public

        #region Constructors
        public KaijuApp(IJSRuntime jsRuntime, string containerId)
            : base(jsRuntime, containerId)
        {
            _mainMenu = new MainMenu(this);
            _world = new World(this);
        }
        #endregion

        #region Members
        public GameStates GameState { get; set; }
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Update();
            
            switch (GameState)
            {
                case GameStates.MainMenu:
                    _mainMenu.Draw();
                    break;
                case GameStates.World:
                    _world.Draw();
                    break;
                case GameStates.GameOver:
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid GameStates enum value");
            };
        }

        [JSInvokable("keyPressed")]
        public override bool KeyPressed()
        {
            switch (GameState)
            {
                case GameStates.MainMenu:
                    _mainMenu.HandleInput(KeyCode);
                    break;
                case GameStates.GameOver:
                    break;
                case GameStates.World:
                    _world.HandleInput(KeyCode);
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid GameStates enum value");
            };

            return false; // Event prevent default
        }

        [JSInvokable("mouseClicked")]
        public override bool MouseClicked()
        {
            switch (GameState)
            {
                case GameStates.MainMenu:
                    _mainMenu.HandleClick(MousePosition);
                    break;
                case GameStates.GameOver:
                    break;
                case GameStates.World:
                    _world.HandleClick(MousePosition);
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid GameStates enum value");
            }   
            return true; // Event prevent default
        }

        [JSInvokable("mouseMoved")]
        public override bool MouseMoved()
        {
            switch (GameState)
            {
                case GameStates.MainMenu:
                    _mainMenu.HandleHover(MousePosition);
                    break;
                case GameStates.GameOver:
                    break;
                case GameStates.World:
                    _world.HandleHover(MousePosition);
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid GameStates enum value");
            }
            return true; // Event prevent default
        }

        [JSInvokable("preload")]
        public override void Preload() {}

        public void Reset()
        {
            GameState = GameStates.MainMenu;
            _mainMenu.Setup(_width, _height);
            _world.Setup();
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            FrameRate(30);
            UserStartAudio();
            InitializeCanvas();
            Reset();
        }

        [JSInvokable("windowResized")]
        public override void WindowResized()
        {
            QueryWindow();
            ResizeCanvas((uint)_width, (uint)_height);
            switch (GameState)
            {
                case GameStates.MainMenu:
                    _mainMenu.SetUiScale(_width, _height);
                    break;
                case GameStates.GameOver:
                    break;
                case GameStates.World:
                    _world.SetUiScale(_width, _height);
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid GameStates enum value");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private float _delta { get; set; } = 0.01f;
        private float _height { get; set; }
        private MainMenu _mainMenu { get; set; }
        private float _width { get; set; }
        private World _world { get; set; }
        #endregion

        #region Member Methods
        private void DrawCenterLines()
        {
            Push();
            Stroke(Color.Red);
            StrokeWeight(1);
            DrawLine(
                new Vector2(0f, _height / 2f),
                new Vector2(_width, _height / 2f)
            );
            DrawLine(
                new Vector2(_width / 2f, 0f),
                new Vector2(_width / 2f, _height)
            );
            Pop();
        }

        private void InitializeCanvas()
        {
            QueryWindow();
            CreateCanvas((uint)_width, (uint)_height, useWebGl: false);
        }

        private void HandleInputGameOver(KeyCodes code) {}
        
        private void HandleInputMainMenu(KeyCodes code) {}

        private void HandleInputWorld(KeyCodes code)
        {
            _world.HandleInput(code);
        }

        private void QueryWindow()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.75f;
            _height = _width / aspectRatio;
        }

        private void Update()
        {
            switch (GameState)
            {
                case GameStates.MainMenu:
                    _mainMenu.Update();
                    break;
                case GameStates.World:
                    _world.Update();
                    break;
                case GameStates.GameOver:
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid GameStates enum value");
            };
        }
        #endregion

        #endregion
    }
}