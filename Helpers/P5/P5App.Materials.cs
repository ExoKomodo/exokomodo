using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void AmbientMaterial(byte grayscale)
        {
            if (!IsWebGL)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ambientMaterial",
                grayscale
            );
        }

        public void AmbientMaterial(Color color)
        {
            if (!IsWebGL)
            {
                return;
            }
            switch (color.Mode)
            {
                case ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "ambientMaterial",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "ambientMaterial",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        public void EmissiveMaterial(Color color)
        {
            if (!IsWebGL)
            {
                return;
            }
            switch (color.Mode)
            {
                case ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "emissiveMaterial",
                        color.Red,
                        color.Green,
                        color.Blue,
                        color.Alpha
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "emissiveMaterial",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        public void NormalMaterial()
        {
            if (!IsWebGL)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "normalMaterial"
            );
        }

        public void Shininess(float shininess = 1f)
        {
            if (!IsWebGL)
            {
                return;
            }
            if (shininess < 1f)
            {
                shininess = 1f;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "shininess",
                shininess
            );
        }

        public void SpecularMaterial(byte grayscale, byte alpha = 255)
        {
            if (!IsWebGL)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "specularMaterial",
                grayscale,
                alpha
            );
        }

        public void SpecularMaterial(Color color)
        {
            if (!IsWebGL)
            {
                return;
            }
            switch (color.Mode)
            {
                case ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "specularMaterial",
                        color.Red,
                        color.Green,
                        color.Blue,
                        color.Alpha
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "specularMaterial",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }
        #endregion

        #endregion
    }
}
