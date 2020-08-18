using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void CreateCanvas(uint width, uint height, bool useWebGL = false)
        {
            IsWebGL = useWebGL;
            if (useWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "createCanvas",
                    width,
                    height,
                    "webgl"
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "createCanvas",
                    width,
                    height
                );
            }
        }

        public void NoCanvas()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noCanvas"
            );
        }

        public void ResizeCanvas(uint width, uint height, bool noRedraw = false)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "resizeCanvas",
                width,
                height,
                noRedraw
            );
        }

        public void SetBlendMode(BlendMode mode)
        {
            var blendMode = "";
            switch (mode)
            {
                case BlendMode.Add:
                    blendMode = "lighter";
                    break;
                case BlendMode.Blend:
                    blendMode = "source-over";
                    break;
                case BlendMode.Burn:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "color-burn";
                    break;
                case BlendMode.Darkest:
                    blendMode = "darken";
                    break;
                case BlendMode.Difference:
                    blendMode = "difference";
                    break;
                case BlendMode.Dodge:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "color-dodge";
                    break;
                case BlendMode.Exclusion:
                    blendMode = "exclusion";
                    break;
                case BlendMode.HardLight:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "hard-light";
                    break;
                case BlendMode.Lightest:
                    blendMode = "lighten";
                    break;
                case BlendMode.Multiply:
                    blendMode = "multiply";
                    break;
                case BlendMode.Overlay:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "overlay";
                    break;
                case BlendMode.Remove:
                    blendMode = "destination-out";
                    break;
                case BlendMode.Replace:
                    blendMode = "copy";
                    break;
                case BlendMode.Screen:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "screen";
                    break;
                case BlendMode.SoftLight:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "soft-light";
                    break;
                case BlendMode.Subtract:
                    if (!IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for non-WebGL");
                    }
                    blendMode = "subtract";
                    break;
                default:
                    throw new Exception("Invalid BlendMode");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "blendMode",
                blendMode
            );
        }
        #endregion

        #endregion
    }
}