using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void DrawText(string text, float x = 0, float y = 0)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "text",
                text,
                x,
                y
            );
        }

        public void DrawText(string text, Vector2 position) => DrawText(
            text,
            position.X,
            position.Y
        );

        public Font LoadFont(string path) => _jsRuntime.Invoke<Font>(
            "p5Instance.loadFontDotnet",
            path
        );

        public void TextFont(string font) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textFont",
            font
        );

        public void TextFont(string font, float size) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textFont",
            font,
            size
        );

        public void TextFont(Font font) => _jsRuntime.InvokeVoid(
            "p5Instance.textFontDotnet",
            font.Id
        );

        public void TextFont(Font font, float size) => _jsRuntime.InvokeVoid(
            "p5Instance.textFontDotnet",
            font.Id,
            size
        );
        #endregion

        #endregion
    }
}