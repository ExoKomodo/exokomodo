using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Helpers.P5.Enums;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask Background(byte grayscale)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "background",
                grayscale
            );
        }

        public ValueTask Background(Color color)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "background",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public ValueTask Clear()
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "clear"
            );
        }

        public ValueTask Erase(byte strengthFill = 255, byte strengthStroke = 255)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "erase",
                strengthFill,
                strengthStroke
            );
        }

        public ValueTask Fill(byte grayscale)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "fill",
                grayscale
            );
        }

        public ValueTask Fill(Color color)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "fill",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public ValueTask NoErase()
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "noErase"
            );
        }

        public ValueTask NoFill()
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "noFill"
            );
        }

        public ValueTask NoStroke()
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "noStroke"
            );
        }

        public ValueTask SetColorMode(ColorMode mode)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "colorMode",
                ColorModeToString(mode)
            );
        }

        public ValueTask Stroke(byte grayscale)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "stroke",
                grayscale
            );
        }

        public ValueTask Stroke(Color color)
        {
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "stroke",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }
        #endregion

        #region Static Methods
        public static string ColorModeToString(ColorMode mode) => mode switch
        {
            ColorMode.RGB => "rgb",
            ColorMode.HSB => "hsb",
            _ => throw new Exception("Invalid ColorMode"),
        };
        #endregion

        #endregion
    }
}