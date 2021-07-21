using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask DrawText(string text, float x = 0, float y = 0) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "text",
                text,
                x,
                y
            );

        public ValueTask DrawText(string text, Vector2 position) => DrawText(
            text,
            position.X,
            position.Y
        );

        public ValueTask<Font> LoadFont(string path) =>
            _JS.InvokeAsync<Font>(
                "p5Instance.loadFontDotnet",
                path
            );

        public ValueTask TextFont(string font) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "textFont",
                font
            );

        public ValueTask TextFont(string font, float size) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "textFont",
                font,
                size
            );

        public ValueTask TextFont(Font font) =>
            _JS.InvokeVoidAsync(
                "p5Instance.textFontDotnet",
                font.Id
            );

        public ValueTask TextFont(Font font, float size) =>
            _JS.InvokeVoidAsync(
                "p5Instance.textFontDotnet",
                font.Id,
                size
            );
        #endregion

        #endregion
    }
}