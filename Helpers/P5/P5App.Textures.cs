using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask SetTextureMode(TextureMode mode) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "textureMode",
            TextureModeToString(mode)
        );

        public ValueTask SetTextureWrap(TextureWrap wrap) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "textureWrap",
            TextureWrapToString(wrap)
        );

        public ValueTask SetTextureWrap(TextureWrap wrapX, TextureWrap wrapY) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "textureWrap",
            TextureWrapToString(wrapX),
            TextureWrapToString(wrapY)
        );
        
        public ValueTask Texture(Image image) => _JS.InvokeVoidAsync(
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