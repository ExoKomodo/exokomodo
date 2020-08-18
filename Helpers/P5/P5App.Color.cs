using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void Background(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "background",
                grayscale
            );
        }

        public void Background(Color color)
        {
            switch (color.Mode)
            {
                case Enums.ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "background",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case Enums.ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "background",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        public void Clear()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "clear"
            );
        }

        public void ColorMode(Enums.ColorMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "colorMode",
                Models.Color.ToString(mode)
            );
        }

        public void Fill(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "fill",
                grayscale
            );
        }

        public void Fill(Color color)
        {
            switch (color.Mode)
            {
                case Enums.ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "fill",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case Enums.ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "fill",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        public void NoFill()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noFill"
            );
        }

        public void NoStroke()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noStroke"
            );
        }

        public void Stroke(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "stroke",
                grayscale
            );
        }

        public void Stroke(Color color)
        {
            switch (color.Mode)
            {
                case Enums.ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "stroke",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case Enums.ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "stroke",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        public void Erase(byte strengthFill = 255, byte strengthStroke = 255)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "erase",
                strengthFill,
                strengthStroke
            );
        }

        public void NoErase()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noErase"
            );
        }
        #endregion

        #endregion
    }
}