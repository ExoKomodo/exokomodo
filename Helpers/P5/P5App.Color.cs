using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Helpers.P5.Enums;
using System;
using System.Drawing;

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
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "background",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public void Clear()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "clear"
            );
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
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "fill",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public void NoErase()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noErase"
            );
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

        public void SetColorMode(ColorMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "colorMode",
                ColorModeToString(mode)
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
            _jsRuntime.InvokeVoid(
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