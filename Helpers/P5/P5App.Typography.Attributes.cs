using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Enums;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public double GetTextAscent() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textAscent"
        );

        public double GetTextDescent() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textDescent"
        );

        public double GetTextLeading() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textLeading"
        );

        public double GetTextSize() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textSize"
        );

        public TextStyle GetTextStyle()
        {
            var style = _jsRuntime.Invoke<string>(
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

        public double GetTextWidth(string text) => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textWidth",
            text
        );

        public void SetTextAlign(HorizontalTextAlign align)
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

        public void SetTextAlign(HorizontalTextAlign horizontalAlign, VerticalTextAlign verticalAlign)
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

        public void SetTextLeading(double leading) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textLeading",
            leading
        );

        public void SetTextSize(double size) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textSize",
            size
        );

        public void SetTextStyle(TextStyle style)
        {
            var textStyle = "";
            switch (style)
            {
                case TextStyle.Bold:
                    textStyle = "bold";
                    break;
                case TextStyle.BoldItalic:
                    textStyle = "bold italic";
                    break;
                case TextStyle.Italic:
                    textStyle = "italic";
                    break;
                case TextStyle.Normal:
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
        #endregion

        #endregion
    }
}