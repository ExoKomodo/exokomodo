using System;
using System.Drawing;
using System.Net.Http;
using Client.Helpers.P5;
using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using Client.Pages.Webring.Jorson.Helpers;
using Microsoft.JSInterop;

namespace Client.Pages.Webring.Jorson.Games.Nox
{
    public class NoxApp : P5App
    {
        #region Public

        #region Constructors
        public NoxApp(
            IJSRuntime jsRuntime,
            string containerId,
            TextAdventure<string> adventure
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
            if (state.IsTerminal)
            {
                Push();
                SetImageMode(ImageMode.Center);
                Translate(_width * 0.5f, _height * 0.7f);

                if (_adventure.CurrentState.Info == "end")
                {
                    Scale(0.7f);
                    if (!IsFinished)
                    {
                        Stop(_backgroundMusic);
                        SetIsSoundLooping(_victorySound, false);
                        Play(_victorySound);
                    }
                    DrawImage(_cats);
                    IsFinished = true;
                }
                else
                {
                    IsFinished = true;
                    Scale(0.35f);
                    DrawImage(_nox);
                }

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
            switch (KeyCode)
            {
                case Enums.KeyCodes.NumPad0:
                case Enums.KeyCodes.Digit0:
                    _currentOption = 10;
                    break;

                case Enums.KeyCodes.Digit1:
                case Enums.KeyCodes.Digit2:
                case Enums.KeyCodes.Digit3:
                case Enums.KeyCodes.Digit4:
                case Enums.KeyCodes.Digit5:
                case Enums.KeyCodes.Digit6:
                case Enums.KeyCodes.Digit7:
                case Enums.KeyCodes.Digit8:
                case Enums.KeyCodes.Digit9:
                    _currentOption = KeyCode - Enums.KeyCodes.Digit0;
                    break;

                case Enums.KeyCodes.NumPad1:
                case Enums.KeyCodes.NumPad2:
                case Enums.KeyCodes.NumPad3:
                case Enums.KeyCodes.NumPad4:
                case Enums.KeyCodes.NumPad5:
                case Enums.KeyCodes.NumPad6:
                case Enums.KeyCodes.NumPad7:
                case Enums.KeyCodes.NumPad8:
                case Enums.KeyCodes.NumPad9:
                    _currentOption = KeyCode - Enums.KeyCodes.NumPad0;
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
            
            Stop(_backgroundMusic);
            Stop(_victorySound);
            
            SetMasterVolume(0.1f);
            Play(_backgroundMusic);
            SetIsSoundLooping(_backgroundMusic, true);
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            UserStartAudio();
            
            InitializeCanvas();
            Reset();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private TextAdventure<string> _adventure { get; set; }
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