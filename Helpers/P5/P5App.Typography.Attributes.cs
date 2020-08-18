using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Enums;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void TextAlign(HorizontalTextAlign align)
        {
            var textAlign = "";
            switch (align)
            {
                case HorizontalTextAlign.Center:
                    textAlign = "center";
                    break;
                case HorizontalTextAlign.Left:
                    textAlign = "left";
                    break;
                case HorizontalTextAlign.Right:
                    textAlign = "right";
                    break;
                default:
                    throw new Exception("Invalid HorizontalTextAlign");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "textAlign",
                textAlign
            );
        }

        public void TextAlign(HorizontalTextAlign horizontalAlign, VerticalTextAlign verticalAlign)
        {
            var horizontalTextAlign = "";
            switch (horizontalAlign)
            {
                case HorizontalTextAlign.Center:
                    horizontalTextAlign = "center";
                    break;
                case HorizontalTextAlign.Left:
                    horizontalTextAlign = "left";
                    break;
                case HorizontalTextAlign.Right:
                    horizontalTextAlign = "right";
                    break;
                default:
                    throw new Exception("Invalid HorizontalTextAlign");
            }
            var verticalTextAlign = "";
            switch (verticalAlign)
            {
                case VerticalTextAlign.Baseline:
                    verticalTextAlign = "alphabetic";
                    break;
                case VerticalTextAlign.Bottom:
                    verticalTextAlign = "bottom";
                    break;
                case VerticalTextAlign.Center:
                    verticalTextAlign = "center";
                    break;
                case VerticalTextAlign.Top:
                    verticalTextAlign = "top";
                    break;
                default:
                    throw new Exception("Invalid VerticalTextAlign");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "textAlign",
                horizontalTextAlign,
                verticalTextAlign
            );
        }

        public double TextAscent() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textAscent"
        );

        public double TextDescent() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textDescent"
        );

        public double TextLeading() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textLeading"
        );

        public void TextLeading(double leading) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textLeading",
            leading
        );

        public double TextSize() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textSize"
        );

        public void TextSize(double size) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textSize",
            size
        );

        public Enums.TextStyle TextStyle()
        {
            var style = _jsRuntime.Invoke<string>(
                _p5InvokeFunctionAndReturn,
                "textStyle"
            );
            switch (style)
            {
                case "bold":
                    return Enums.TextStyle.Bold;
                case "bold italic":
                    return Enums.TextStyle.BoldItalic;
                case "italic":
                    return Enums.TextStyle.Italic;
                case "normal":
                    return Enums.TextStyle.Normal;
                default:
                    throw new Exception("Invalid TextStyle");
            }
        }

        public void TextStyle(Enums.TextStyle style)
        {
            var textStyle = "";
            switch (style)
            {
                case Enums.TextStyle.Bold:
                    textStyle = "bold";
                    break;
                case Enums.TextStyle.BoldItalic:
                    textStyle = "bold italic";
                    break;
                case Enums.TextStyle.Italic:
                    textStyle = "italic";
                    break;
                case Enums.TextStyle.Normal:
                    textStyle = "normal";
                    break;
                default:
                    throw new Exception("Invalid TextStyle");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "textStyle",
                textStyle
            );
        }

        public double TextWidth(string text) => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textWidth",
            text
        );
        #endregion

        #endregion
    }
}