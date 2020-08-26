using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void NoSmooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noSmooth"
            );
        }

        public void SetEllipseMode(EllipseMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ellipseMode",
                Ellipse.ToString(mode)
            );
        }
        
        public void SetRectangleMode(RectangleMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rectMode",
                Rectangle.ToString(mode)
            );
        }

        public void SetStrokeCap(StrokeCap cap)
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
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeCap",
                mode
            );
        }

        public void SetStrokeJoin(StrokeJoin join)
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
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeJoin",
                mode
            );
        }

        public void StrokeWeight(uint weight)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeWeight",
                weight
            );
        }

        public void Smooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "smooth"
            );
        }
        #endregion

        #endregion
    }
}