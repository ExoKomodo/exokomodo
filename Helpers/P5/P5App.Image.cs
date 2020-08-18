using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void Image(Image image) => _jsRuntime.InvokeVoid(
            "p5Instance.imageDotnet",
            image.Id,
            image.X,
            image.Y,
            image.Width,
            image.Height
        );

        public uint ImageHeight(Image image) => _jsRuntime.Invoke<uint>(
            "p5Instance.imageHeightDotnet",
            image.Id
        );

        public void ImageMode(Enums.ImageMode mode)
        {
            var imageMode = "";
            switch (mode)
            {
                case Enums.ImageMode.Center:
                    imageMode = "center";
                    break;
                case Enums.ImageMode.Corner:
                    imageMode = "corner";
                    break;
                case Enums.ImageMode.Corners:
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

        public uint ImageWidth(Image image) => _jsRuntime.Invoke<uint>(
            "p5Instance.imageWidthDotnet",
            image.Id
        );

        public void SetImageFields(Image image)
        {
            image.Width = ImageWidth(image);
            image.Height = ImageHeight(image);
        }

        public Image LoadImage(string path) => _jsRuntime.Invoke<Image>(
            "p5Instance.loadImageDotnet",
            path
        );
        #endregion

        #endregion
    }
}