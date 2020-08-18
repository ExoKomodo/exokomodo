using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void EllipseMode(Enums.EllipseMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ellipseMode",
                Models.Ellipse.ToString(mode)
            );
        }

        public void NoSmooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noSmooth"
            );
        }

        public void RectangleMode(Enums.RectangleMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rectMode",
                Models.Rectangle.ToString(mode)
            );
        }

        public void Smooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "smooth"
            );
        }

        public void StrokeCap(Enums.StrokeCap cap)
        {
            var mode = "";
            switch (cap)
            {
                case Enums.StrokeCap.Project:
                    mode = "project";
                    break;
                case Enums.StrokeCap.Round:
                    mode = "round";
                    break;
                case Enums.StrokeCap.Square:
                    mode = "square";
                    break;
                default:
                    throw new Exception("Invalid StrokeCap");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeCap",
                mode
            );
        }

        public void StrokeJoin(Enums.StrokeJoin join)
        {
            var mode = "";
            switch (join)
            {
                case Enums.StrokeJoin.Bevel:
                    mode = "bevel";
                    break;
                case Enums.StrokeJoin.Miter:
                    mode = "miter";
                    break;
                case Enums.StrokeJoin.Round:
                    mode = "round";
                    break;
                default:
                    throw new Exception("Invalid StrokeJoin");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeJoin",
                mode
            );
        }

        public void StrokeWeight(byte weight)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeWeight",
                weight
            );
        }
        #endregion

        #endregion
    }
}