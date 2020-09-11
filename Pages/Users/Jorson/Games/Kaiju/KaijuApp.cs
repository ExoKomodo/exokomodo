using ExoKomodo.Enums;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Ui;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
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
            _scenes = new List<Scene>();
        }
        #endregion

        #region Members
        public GameStates GameState { get; set; }
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            foreach (var scene in _scenes)
            {
                if (scene.ActiveStates.Contains(GameState))
                {
                    scene.Update();
                }
            }
            foreach (var scene in _scenes)
            {
                if (scene.ActiveStates.Contains(GameState))
                {
                    scene.Draw();
                }
            }
        }

        [JSInvokable("keyPressed")]
        public override bool KeyPressed()
        {
            foreach (var scene in _scenes)
            {
                if (scene.ActiveStates.Contains(GameState))
                {
                    scene.HandleInput(KeyCode);
                }
            }

            return false; // Event prevent default
        }

        [JSInvokable("mouseClicked")]
        public override bool MouseClicked()
        {
            foreach (var scene in _scenes)
            {
                if (scene.ActiveStates.Contains(GameState))
                {
                    scene.HandleClick(MousePosition);
                }
            }
            return true; // Event prevent default
        }

        [JSInvokable("mouseMoved")]
        public override bool MouseMoved()
        {
            foreach (var scene in _scenes)
            {
                if (scene.ActiveStates.Contains(GameState))
                {
                    scene.HandleHover(MousePosition);
                }
            }
            return true; // Event prevent default
        }

        [JSInvokable("preload")]
        public override void Preload() {}

        public void Reset()
        {
            GameState = GameStates.MainMenu;
            foreach (var scene in _scenes)
            {
                scene.Setup(_width, _height);
            }
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            FrameRate(30);
            UserStartAudio();

            _scenes.Add(new MainMenu(this));
            _scenes.Add(new World(this));

            InitializeCanvas();
            Reset();
        }

        [JSInvokable("windowResized")]
        public override void WindowResized()
        {
            QueryWindow();
            ResizeCanvas((uint)_width, (uint)_height);
            foreach (var scene in _scenes)
            {
                if (scene.ActiveStates.Contains(GameState))
                {
                    scene.SetUiScale(_width, _height);
                }
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private float _delta { get; set; } = 0.01f;
        private float _height { get; set; }
        private IList<Scene> _scenes { get; set; }
        private float _width { get; set; }
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

        private void QueryWindow()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.75f;
            _height = _width / aspectRatio;
        }
        #endregion

        #endregion
    }
}