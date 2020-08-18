using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using System;
using ExoKomodo.Helpers.P5.Enums;

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

        public void SetImageFields(Image image)
        {
            image.Width = GetImageWidth(image);
            image.Height = GetImageHeight(image);
        }

        public void SetImageMode(ImageMode mode)
        {
            var imageMode = "";
            switch (mode)
            {
                case ImageMode.Center:
                    imageMode = "center";
                    break;
                case ImageMode.Corner:
                    imageMode = "corner";
                    break;
                case ImageMode.Corners:
                    imageMode = "corners";
                    break;
                default:
                    throw new Exception("Invalid ImageMode");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "imageMode",
                imageMode
            );
        }

        public Image LoadImage(string path) => _jsRuntime.Invoke<Image>(
            "p5Instance.loadImageDotnet",
            path
        );
        #endregion

        #endregion
    }
}