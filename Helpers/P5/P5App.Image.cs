using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using System;
using ExoKomodo.Helpers.P5.Enums;
using System.Drawing;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask DrawImage(Image image) => _JS.InvokeVoidAsync(
            "p5Instance.imageDotnet",
            image.Id,
            image.X,
            image.Y,
            image.Width,
            image.Height
        );

        public ValueTask<uint> GetImageHeight(Image image) => _JS.InvokeAsync<uint>(
            "p5Instance.imageHeightDotnet",
            image.Id
        );

        public ValueTask<uint> GetImageWidth(Image image) => _JS.InvokeAsync<uint>(
            "p5Instance.imageWidthDotnet",
            image.Id
        );

        public ValueTask<Image> LoadImage(string path) => _JS.InvokeAsync<Image>(
            "p5Instance.loadImageDotnet",
            path
        );

        public ValueTask NoTint() => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "noTint"
        );

        public async Task SetImageFields(Image image)
        {
            image.Width = await GetImageWidth(image);
            image.Height = await GetImageHeight(image);
        }

        public ValueTask SetImageMode(ImageMode mode) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "imageMode",
            ImageModeToString(mode)
        );

        public ValueTask Tint(byte grayscale, byte alpha = 255) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "tint",
            grayscale,
            alpha
        );

        public ValueTask Tint(Color color) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "tint",
            color.R,
            color.G,
            color.B,
            color.A
        );
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