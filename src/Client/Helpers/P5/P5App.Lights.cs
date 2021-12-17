using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Numerics;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void AmbientLight(byte grayscale, byte alpha = 255)
        {
            if (!IsWebGl)
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
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ambientLight",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public void DirectionalLight(Color color, float x, float y, float z)
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "directionalLight",
                color.R,
                color.G,
                color.B,
                x,
                y,
                z
            );
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
            if (!IsWebGl)
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
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "pointLight",
                color.R,
                color.G,
                color.B,
                x,
                y,
                z
            );
        }

        public void PointLight(Color color, Vector3 direction) => PointLight(
            color,
            direction.X,
            direction.Y,
            direction.Z
        );

        public void SpecularColor(Color color)
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "specularColor",
                color.R,
                color.G,
                color.B
            );
        }

        public void SpotLight(
            Color color,
            Vector3 position,
            Vector3 direction,
            float angle = (float)(Math.PI / 3),
            float concentration = 100f
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "spotLight",
                color.R,
                color.G,
                color.B,
                position.X,
                position.Y,
                position.Z,
                direction.X,
                direction.Y,
                direction.Z,
                angle,
                concentration
            );
        }
        #endregion

        #endregion
    }
}
