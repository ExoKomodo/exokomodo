using System;
using System.Drawing;
using System.Net.Http;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Helpers;
using Microsoft.JSInterop;

namespace ExoKomodo.Pages.Users.Jorson.Games.Nox
{
    public class NoxApp : P5App
    {
        #region Public

        #region Constructors
        public NoxApp(
            IJSRuntime jsRuntime,
            string containerId,
            TextAdventure adventure
        ) : base(jsRuntime, containerId)
        {
            _adventure = adventure;
        }
        #endregion

        #region Members
        public bool IsFinished { get; private set; }
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Background(_clearColor);

            // Choose an option if input was provided.
            if (_currentOption > 0)
            {
                _adventure.Update(_currentOption - 1);
                _currentOption = 0;
            }

            var state = _adventure.CurrentState;
            Push();
            // Draw the main text of the State
            SetTextAlign(HorizontalTextAlign.Center, VerticalTextAlign.Top);
            SetTextSize(32);
            Fill(255);
            DrawText(state.Text, _width / 2, _height / 4);
            Pop();
            
            // Check for a deadend
            if (state.Options.Count == 0)
            {
                Push();
                SetImageMode(ImageMode.Center);
                Translate(_width * 0.5f, _height * 0.7f);
                
                Image image;
                if (_adventure.CurrentState.Id == "end")
                {
                    image = _cats;
                    Scale(0.7f);
                    if (!IsFinished)
                    {
                        Stop(_backgroundMusic);
                        SetIsSoundLooping(_victorySound, false);
                        Play(_victorySound);
                    }
                    IsFinished = true;
                }
                else
                {
                    image = _nox;
                    Scale(0.35f);
                }
                
                DrawImage(image);
                Pop();
                return;
            }

            if (_adventure.BlockedTransition)
            {
                Push();
                SetTextAlign(HorizontalTextAlign.Center, VerticalTextAlign.Top);
                SetTextSize(24);
                Fill(Color.FromArgb(red: 255, green: 0, blue: 0));
                DrawText(
                    "You can't do that",
                    _width / 2,
                    _height * 0.5f
                );
                Pop();
            }
            
            // Print out option prompt
            var prompt = "What do you do?\n";
            for (int i = 0; i < state.Options.Count; i++)
            {
                var option = state.Options[i];
                prompt += $"\n{i + 1}: {option}";
            }
            Push();
            SetTextAlign(HorizontalTextAlign.Left, VerticalTextAlign.Top);
            SetTextSize(16);
            Fill(255);
            DrawText(
                prompt,
                _width / 4,
                _height * 0.75f
            );
            Pop();
        }

        [JSInvokable("keyPressed")]
        public override bool KeyPressed()
        {
            switch (Key)
            {
                case "1":
                    _currentOption = 1;
                    break;
                case "2":
                    _currentOption = 2;
                    break;
                case "3":
                    _currentOption = 3;
                    break;
                case "4":
                    _currentOption = 4;
                    break;
                case "5":
                    _currentOption = 5;
                    break;
                case "6":
                    _currentOption = 6;
                    break;
                case "7":
                    _currentOption = 7;
                    break;
                case "8":
                    _currentOption = 8;
                    break;
                case "9":
                    _currentOption = 9;
                    break;
                case "0":
                    _currentOption = 10;
                    break;
                default:
                    break;
            }
            
            if (IsFinished)
            {
                Reset();
            }
            return true; // Event prevent default
        }

        [JSInvokable("preload")]
        public override void Preload()
        {
            _backgroundMusic = LoadSound("assets/jorson/games/nox/background.mp3");
            _victorySound = LoadSound("assets/jorson/games/nox/victory.mp3");
            _cats = LoadImage("img/jorson/nox_and_luna.jpg");
            _nox = LoadImage("img/jorson/nox_closeup.jpg");
        }

        public void Reset()
        {
            IsFinished = false;
            _adventure.Reset();
            _currentOption = 0;
            
            Stop(_victorySound);
            
            SetMasterVolume(0.1f);
            Play(_backgroundMusic);
            SetIsSoundLooping(_backgroundMusic, true);
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            InitializeCanvas();
            Reset();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private TextAdventure _adventure { get; set; }
        private Sound _backgroundMusic { get; set; }
        private Image _cats { get; set; }
        private Color _clearColor { get; set; }
        private float _height { get; set; }
        private Image _nox { get; set; }
        private float _width { get; set; }
        private int _currentOption { get; set; }
        private Sound _victorySound { get; set; }
        #endregion

        #region Member Methods
        private void InitializeCanvas()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.6f;
            _height = _width / aspectRatio;
            _clearColor = Color.FromArgb(red: 32, green: 32, blue: 32);
            CreateCanvas((uint)_width, (uint)_height);
        }
        #endregion

        #endregion
    }
}