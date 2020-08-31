using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Numerics;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void AmbientLight(byte grayscale, byte alpha = 255)
        {
            if (!IsWebGL)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ambientLight",
                grayscale,
                alpha
            );
        }

        public void AmbientLight(Color color)
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
                        "ambientLight",
                        color.Red,
                        color.Green,
                        color.Blue,
                        color.Alpha
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "ambientLight",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        public void DirectionalLight(Color color, float x, float y, float z)
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
                        "directionalLight",
                        color.Red,
                        color.Green,
                        color.Blue,
                        x,
                        y,
                        z
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "directionalLight",
                        color.Hue,
                        color.Saturation,
                        color.Brightness,
                        x,
                        y,
                        z
                    );
                    break;
            }
        }

        public void DirectionalLight(Color color, Vector3 direction) => DirectionalLight(
            color,
            direction.X,
            direction.Y,
            direction.Z
        );

        public void LightFalloff(
            float constant = 1f,
            float linear = 0f,
            float quadratic = 0f
        )
        {
            if (!IsWebGL)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "lightFalloff",
                constant,
                linear,
                quadratic
            );
        }

        public void Lights()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "lights"
            );
        }

        public void NoLights()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noLights"
            );
        }

        public void PointLight(Color color, float x, float y, float z)
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
                        "pointLight",
                        color.Red,
                        color.Green,
                        color.Blue,
                        x,
                        y,
                        z
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "pointLight",
                        color.Hue,
                        color.Saturation,
                        color.Brightness,
                        x,
                        y,
                        z
                    );
                    break;
            }
        }

        public void PointLight(Color color, Vector3 direction) => PointLight(
            color,
            direction.X,
            direction.Y,
            direction.Z
        );

        public void SpecularColor(Color color)
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
                        "specularColor",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "specularColor",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        public void SpotLight(
            Color color,
            Vector3 position,
            Vector3 direction,
            float angle = (float)(Math.PI / 3),
            float concentration = 100f
        )
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
                        "spotLight",
                        color.Red,
                        color.Green,
                        color.Blue,
                        position.X,
                        position.Y,
                        position.Z,
                        direction.X,
                        direction.Y,
                        direction.Z,
                        angle,
                        concentration
                    );
                    break;
                case ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "spotLight",
                        color.Hue,
                        color.Saturation,
                        color.Brightness,
                        position.X,
                        position.Y,
                        position.Z,
                        direction.X,
                        direction.Y,
                        direction.Z,
                        angle,
                        concentration
                    );
                    break;
            }
        }
        #endregion

        #endregion
    }
}
