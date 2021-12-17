using Client.Helpers.P5.Enums;
using Client.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Drawing;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void AmbientMaterial(byte grayscale)
        {
            if (!IsWebGl)
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
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ambientMaterial",
                color.R,
                color.G,
                color.B
            );
        }

        public void EmissiveMaterial(Color color)
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "emissiveMaterial",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public Shader LoadShader(string vertexShaderPath, string fragmentShaderPath) => _jsRuntime.Invoke<Shader>(
            "p5Instance.loadShaderDotnet",
            vertexShaderPath,
            fragmentShaderPath
        );

        public void NormalMaterial()
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "normalMaterial"
            );
        }

        public void ResetShader()
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "resetShader"
            );
        }

        public void SetUniform(
            Shader shader,
            string uniformName,
            bool value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public void SetUniform(
            Shader shader,
            string uniformName,
            double value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public void SetUniform(
            Shader shader,
            string uniformName,
            float value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public void SetUniform(
            Shader shader,
            string uniformName,
            double[] value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );
        
        public void SetUniform(
            Shader shader,
            string uniformName,
            float[] value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public void Shininess(float shininess = 1f)
        {
            if (!IsWebGl)
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
            if (!IsWebGl)
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
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "specularMaterial",
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public void UseShader(Shader shader)
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                "p5Instance.shaderDotnet",
                shader.Id
            );
        }
        #endregion

        #endregion

        #region Private

        #region Member Methods
        private void SetUniformCommon(
            Shader shader,
            string uniformName,
            object value
        )
        {
            if (!IsWebGl)
            {
                return;
            }
            _jsRuntime.InvokeVoid(
                "p5Instance.setUniformDotnet",
                shader.Id,
                uniformName,
                value
            );
        }
        #endregion

        #endregion
    }
}
