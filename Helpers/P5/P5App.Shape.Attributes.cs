using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask NoSmooth() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "noSmooth"
            );

        public ValueTask SetEllipseMode(EllipseMode mode) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "ellipseMode",
                Ellipse.EllipseModeToString(mode)
            );
        
        public ValueTask SetRectangleMode(RectangleMode mode) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "rectMode",
                Rect.RectangleModeToString(mode)
            );

        public ValueTask SetStrokeCap(StrokeCap cap)
        {
            var mode = "";
            switch (cap)
            {
                case StrokeCap.Project:
                    mode = "project";
                    break;
                case StrokeCap.Round:
                    mode = "round";
                    break;
                case StrokeCap.Square:
                    mode = "square";
                    break;
                default:
                    throw new Exception("Invalid StrokeCap");
            }
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "strokeCap",
                mode
            );
        }

        public ValueTask SetStrokeJoin(StrokeJoin join)
        {
            var mode = "";
            switch (join)
            {
                case StrokeJoin.Bevel:
                    mode = "bevel";
                    break;
                case StrokeJoin.Miter:
                    mode = "miter";
                    break;
                case StrokeJoin.Round:
                    mode = "round";
                    break;
                default:
                    throw new Exception("Invalid StrokeJoin");
            }
            return _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "strokeJoin",
                mode
            );
        }

        public ValueTask StrokeWeight(uint weight) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "strokeWeight",
                weight
            );

        public ValueTask Smooth() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "smooth"
            );
        #endregion

        #endregion
    }
}