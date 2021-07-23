using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Numerics;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void SetTextureMode(TextureMode mode) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textureMode",
            TextureModeToString(mode)
        );

        public void SetTextureWrap(TextureWrap wrap) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textureWrap",
            TextureWrapToString(wrap)
        );

        public void SetTextureWrap(TextureWrap wrapX, TextureWrap wrapY) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textureWrap",
            TextureWrapToString(wrapX),
            TextureWrapToString(wrapY)
        );
        
        public void Texture(Image image) => _jsRuntime.InvokeVoid(
            "p5Instance.textureDotnet",
            image.Id
        );
        #endregion

        #region Static Methods
        public static string TextureModeToString(TextureMode mode) => mode switch
        {
            TextureMode.Image => "image",
            TextureMode.Normal => "normal",
            _ => throw new Exception("Invalid TextureMode"),
        };

        public static string TextureWrapToString(TextureWrap wrap) => wrap switch
        {
            TextureWrap.Clamp => "image",
            TextureWrap.Mirror => "mirror",
            TextureWrap.Repeat => "repeat",
            _ => throw new Exception("Invalid TextureWrap"),
        };
        #endregion

        #endregion
    }
}