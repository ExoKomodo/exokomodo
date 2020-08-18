using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void BlendMode(Enums.BlendMode mode)
        {
            var blendMode = "";
            switch (mode)
            {
                case Enums.BlendMode.Add:
                    blendMode = "lighter";
                    break;
                case Enums.BlendMode.Blend:
                    blendMode = "source-over";
                    break;
                case Enums.BlendMode.Burn:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "color-burn";
                    break;
                case Enums.BlendMode.Darkest:
                    blendMode = "darken";
                    break;
                case Enums.BlendMode.Difference:
                    blendMode = "difference";
                    break;
                case Enums.BlendMode.Dodge:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "color-dodge";
                    break;
                case Enums.BlendMode.Exclusion:
                    blendMode = "exclusion";
                    break;
                case Enums.BlendMode.HardLight:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "hard-light";
                    break;
                case Enums.BlendMode.Lightest:
                    blendMode = "lighten";
                    break;
                case Enums.BlendMode.Multiply:
                    blendMode = "multiply";
                    break;
                case Enums.BlendMode.Overlay:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "overlay";
                    break;
                case Enums.BlendMode.Remove:
                    blendMode = "destination-out";
                    break;
                case Enums.BlendMode.Replace:
                    blendMode = "copy";
                    break;
                case Enums.BlendMode.Screen:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "screen";
                    break;
                case Enums.BlendMode.SoftLight:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "soft-light";
                    break;
                case Enums.BlendMode.Subtract:
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
        #endregion

        #endregion
    }
}