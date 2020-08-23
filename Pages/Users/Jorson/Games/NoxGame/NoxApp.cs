using System;
using System.Net.Http;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Helpers;
using Microsoft.JSInterop;

namespace ExoKomodo.Pages.Users.Jorson.Games.NoxGame
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
            Fill(255);
            SetTextAlign(HorizontalTextAlign.Center, VerticalTextAlign.Top);
            SetTextSize(32);
            DrawText(state.Text, _width / 2, _height / 2);
            
            // Check for a deadend
            SetTextSize(16);
            if (state.Options.Count == 0)
            {
                DrawText(
                    "End!",
                    _width / 2,
                    _height * 0.75
                );
                IsFinished = true;
                return;
            }
            
            // Print out option prompt
            var prompt = "What do you do?";
            for (int i = 0; i < state.Options.Count; i++)
            {
                var option = state.Options[i];
                prompt += $"\n\n{i + 1}: {option}";
            }
            SetTextAlign(HorizontalTextAlign.Left, VerticalTextAlign.Top);
            DrawText(
                prompt,
                _width / 4,
                _height * 0.75
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
        }

        public void Reset()
        {
            IsFinished = false;
            _adventure.Reset();
            _currentOption = 0;
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            _currentOption = 0;
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            double aspectRatio = isVerticalDisplay ? 4d / 3d : 16d / 9d;
            _width = WindowWidth * 0.75d;
            _height = _width / aspectRatio;
            _clearColor = new Color(32, 32, 32);
            CreateCanvas((uint)_width, (uint)_height);
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private TextAdventure _adventure { get; set; }
        private Color _clearColor { get; set; }
        private double _height { get; set; }
        private double _width { get; set; }
        private int _currentOption { get; set; }
        #endregion

        #endregion
    }
}