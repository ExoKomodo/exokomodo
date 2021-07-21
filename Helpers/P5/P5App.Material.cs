using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask AmbientMaterial(byte grayscale) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "ambientMaterial",
                grayscale
            ) : new ValueTask();

        public ValueTask AmbientMaterial(Color color) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "ambientMaterial",
                color.R,
                color.G,
                color.B
            ) : new ValueTask();

        public ValueTask EmissiveMaterial(Color color) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "emissiveMaterial",
                color.R,
                color.G,
                color.B,
                color.A
            ) : new ValueTask();

        public ValueTask<Shader> LoadShader(
            string vertexShaderPath,
            string fragmentShaderPath
        ) => _JS.InvokeAsync<Shader>(
            "p5Instance.loadShaderDotnet",
            vertexShaderPath,
            fragmentShaderPath
        );

        public ValueTask NormalMaterial() =>
            IsWebGl ?_JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "normalMaterial"
            ) : new ValueTask();

        public ValueTask ResetShader() =>
            IsWebGl ?_JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "resetShader"
            ) : new ValueTask();

        public ValueTask SetUniform(
            Shader shader,
            string uniformName,
            bool value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public ValueTask SetUniform(
            Shader shader,
            string uniformName,
            double value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public ValueTask SetUniform(
            Shader shader,
            string uniformName,
            float value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public ValueTask SetUniform(
            Shader shader,
            string uniformName,
            double[] value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );
        
        public ValueTask SetUniform(
            Shader shader,
            string uniformName,
            float[] value
        ) => SetUniformCommon(
            shader,
            uniformName,
            value
        );

        public ValueTask Shininess(float shininess = 1f)
        {
            if (IsWebGl)
            {
                if (shininess < 1f)
                {
                    shininess = 1f;
                }
                return _JS.InvokeVoidAsync(
                    _p5InvokeFunction,
                    "shininess",
                    shininess
                );
            }
            return new ValueTask();
        }

        public ValueTask SpecularMaterial(byte grayscale, byte alpha = 255) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "specularMaterial",
                grayscale,
                alpha
            ) : new ValueTask();

        public ValueTask SpecularMaterial(Color color) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "specularMaterial",
                color.R,
                color.G,
                color.B,
                color.A
            ) : new ValueTask();

        public ValueTask UseShader(Shader shader) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                "p5Instance.shaderDotnet",
                shader.Id
            ) : new ValueTask();
        #endregion

        #endregion

        #region Private

        #region Member Methods
        private ValueTask SetUniformCommon(
            Shader shader,
            string uniformName,
            object value
        ) => IsWebGl ?_JS.InvokeVoidAsync(
                "p5Instance.setUniformDotnet",
                shader.Id,
                uniformName,
                value
            ) : new ValueTask();
        #endregion

        #endregion
    }
}
