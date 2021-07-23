using Client.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void CreateCanvas(uint width, uint height, bool useWebGl = false)
        {
            IsWebGl = useWebGl;
            if (useWebGl)
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

        public void SetAttributes(WebGlAttribute attribute, bool value)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "setAttributes",
                WebGlAttributeToString(attribute),
                value
            );
        }

        public void SetAttributes(IDictionary<WebGlAttribute, bool> attributes)
        {
            if (attributes is null)
            {
                return;
            }
            foreach (var pair in attributes)
            {
                SetAttributes(pair.Key, pair.Value);
            }
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
            BlendMode.Burn when !Instance.IsWebGl => "color-burn",
            BlendMode.Darkest => "darken",
            BlendMode.Difference => "difference",
            BlendMode.Dodge when !Instance.IsWebGl => "color-dodge",
            BlendMode.Exclusion => "exclusion",
            BlendMode.HardLight when !Instance.IsWebGl => "hard-light",
            BlendMode.Lightest => "lighten",
            BlendMode.Multiply => "multiply",
            BlendMode.Overlay when !Instance.IsWebGl => "overlay",
            BlendMode.Remove => "destination-out",
            BlendMode.Replace => "copy",
            BlendMode.Screen when !Instance.IsWebGl => "screen",
            BlendMode.SoftLight when !Instance.IsWebGl => "soft-light",
            BlendMode.Subtract when Instance.IsWebGl => "subtract",
            _ => throw new Exception("Invalid BlendMode"),
        };

        public static string WebGlAttributeToString(WebGlAttribute attribute) => attribute switch
        {
            WebGlAttribute.Alpha => "alpha",
            WebGlAttribute.AntiAlias => "antialias",
            WebGlAttribute.Depth => "depth",
            WebGlAttribute.PerPixelLighting => "perPixelLighting",
            WebGlAttribute.PreMultipliedAlpha => "premultipliedAlpha",
            WebGlAttribute.PreserveDrawingBuffer => "preserveDrawingBuffer",
            WebGlAttribute.Stencil => "stencil",
            _ => throw new Exception("Invalid WebGlAttribute"),
        };
        #endregion

        #endregion
    }
}