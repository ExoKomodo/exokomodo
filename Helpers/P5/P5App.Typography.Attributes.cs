using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Enums;
using System;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask<float> GetTextAscent() =>
            _JS.InvokeAsync<float>(
                _p5InvokeFunctionAndReturn,
                "textAscent"
            );

        public ValueTask<float> GetTextDescent() =>
            _JS.InvokeAsync<float>(
                _p5InvokeFunctionAndReturn,
                "textDescent"
            );

        public ValueTask<float> GetTextLeading() =>
            _JS.InvokeAsync<float>(
                _p5InvokeFunctionAndReturn,
                "textLeading"
            );

        public ValueTask<float> GetTextSize() =>
            _JS.InvokeAsync<float>(
                _p5InvokeFunctionAndReturn,
                "textSize"
            );

        public async Task<TextStyle> GetTextStyle()
        {
            var style = await _JS.InvokeAsync<string>(
                _p5InvokeFunctionAndReturn,
                "textStyle"
            );
            switch (style)
            {
                case "bold":
                    return TextStyle.Bold;
                case "bold italic":
                    return TextStyle.BoldItalic;
                case "italic":
                    return TextStyle.Italic;
                case "normal":
                    return TextStyle.Normal;
                default:
                    throw new Exception("Invalid TextStyle");
            }
        }

        public ValueTask<float> GetTextWidth(string text) => _JS.InvokeAsync<float>(
            _p5InvokeFunctionAndReturn,
            "textWidth",
            text
        );

        public ValueTask SetTextAlign(HorizontalTextAlign align) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "textAlign",
                HorizontalTextAlignToString(align)
            );

        public ValueTask SetTextAlign(
            HorizontalTextAlign horizontalAlign,
            VerticalTextAlign verticalAlign
        ) => _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "textAlign",
                HorizontalTextAlignToString(horizontalAlign),
                VerticalTextAlignToString(verticalAlign)
            );

        public ValueTask SetTextLeading(float leading) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "textLeading",
                leading
            );

        public ValueTask SetTextSize(float size) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "textSize",
                size
            );

        public ValueTask SetTextStyle(TextStyle style) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "textStyle",
                TextStyleToString(style)
            );
        #endregion

        #region Static Methods

        public static string HorizontalTextAlignToString(HorizontalTextAlign align) =>
            align switch {
                HorizontalTextAlign.Center => "center",
                HorizontalTextAlign.Left => "left",
                HorizontalTextAlign.Right => "right",
                _ => throw new Exception("Invalid HorizontalTextAlign"),
            };

        public static string TextStyleToString(TextStyle style) =>
            style switch {
                TextStyle.Bold => "bold",
                TextStyle.BoldItalic => "bold italic",
                TextStyle.Italic => "italic",
                TextStyle.Normal => "normal",
                _ => throw new Exception("Invalid TextStyle"),
            };
        
        public static string VerticalTextAlignToString(VerticalTextAlign align) =>
            align switch {
                VerticalTextAlign.Baseline => "alphabetic",
                VerticalTextAlign.Bottom => "bottom",
                VerticalTextAlign.Center => "center",
                VerticalTextAlign.Top => "top",
                _ => throw new Exception("Invalid VerticalTextAlign"),
            };

        #endregion

        #endregion
    }
}