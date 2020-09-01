using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using System;
using ExoKomodo.Helpers.P5.Enums;
using System.Drawing;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void DrawImage(Image image) => _jsRuntime.InvokeVoid(
            "p5Instance.imageDotnet",
            image.Id,
            image.X,
            image.Y,
            image.Width,
            image.Height
        );

        public uint GetImageHeight(Image image) => _jsRuntime.Invoke<uint>(
            "p5Instance.imageHeightDotnet",
            image.Id
        );

        public uint GetImageWidth(Image image) => _jsRuntime.Invoke<uint>(
            "p5Instance.imageWidthDotnet",
            image.Id
        );

        public Image LoadImage(string path) => _jsRuntime.Invoke<Image>(
            "p5Instance.loadImageDotnet",
            path
        );

        public void NoTint()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noTint"
            );
        }

        public void SetImageFields(Image image)
        {
            image.Width = GetImageWidth(image);
            image.Height = GetImageHeight(image);
        }

        public void SetImageMode(ImageMode mode) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "imageMode",
            ImageModeToString(mode)
        );

        public void Tint(byte grayscale, byte alpha = 255)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "tint",
                grayscale,
                alpha
            );
        }

        public void Tint(Color color)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "tint",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }
        #endregion

        #region Static Methods
        public static string ImageModeToString(ImageMode mode) => mode switch
        {
            ImageMode.Center => "center",
            ImageMode.Corner => "corner",
            ImageMode.Corners => "corners",
            _ => throw new Exception("Invalid ImageMode"),
        };
        #endregion

        #endregion
    }
}