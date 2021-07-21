using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask CreateCanvas(uint width, uint height, bool useWebGl = false)
        {
            IsWebGl = useWebGl;
            return IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "createCanvas",
                width,
                height,
                "webgl"
            ) : _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "createCanvas",
                width,
                height
            );
        }

        public ValueTask NoCanvas() => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "noCanvas"
        );

        public ValueTask ResizeCanvas(uint width, uint height, bool noRedraw = false) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "resizeCanvas",
                width,
                height,
                noRedraw
            );

        public ValueTask SetAttributes(WebGlAttribute attribute, bool value) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "setAttributes",
                WebGlAttributeToString(attribute),
                value
            );

        public async Task SetAttributes(IDictionary<WebGlAttribute, bool> attributes)
        {
            if (attributes is null)
            {
                return;
            }
            foreach (var pair in attributes)
            {
                await SetAttributes(pair.Key, pair.Value);
            }
        }

        public ValueTask SetBlendMode(BlendMode mode) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "blendMode",
                BlendModeToString(mode)
            );
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