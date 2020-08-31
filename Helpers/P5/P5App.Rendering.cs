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
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "blendMode",
                BlendModeToString(mode)
            );
        }
        #endregion

                #region Static Methods
        public static string BlendModeToString(BlendMode mode) => mode switch
        {
            BlendMode.Add => "lighter",
            BlendMode.Blend => "source-over",
            BlendMode.Burn when !Instance.IsWebGL => "color-burn",
            BlendMode.Darkest => "darken",
            BlendMode.Difference => "difference",
            BlendMode.Dodge when !Instance.IsWebGL => "color-dodge",
            BlendMode.Exclusion => "exclusion",
            BlendMode.HardLight when !Instance.IsWebGL => "hard-light",
            BlendMode.Lightest => "lighten",
            BlendMode.Multiply => "multiply",
            BlendMode.Overlay when !Instance.IsWebGL => "overlay",
            BlendMode.Remove => "destination-out",
            BlendMode.Replace => "copy",
            BlendMode.Screen when !Instance.IsWebGL => "screen",
            BlendMode.SoftLight when !Instance.IsWebGL => "soft-light",
            BlendMode.Subtract when Instance.IsWebGL => "subtract",
            _ => throw new Exception("Invalid BlendMode"),
        };
        #endregion

        #endregion
    }
}