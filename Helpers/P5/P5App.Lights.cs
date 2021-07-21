using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask AmbientLight(byte grayscale, byte alpha = 255) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "ambientLight",
                grayscale,
                alpha
            ) : new ValueTask();

        public ValueTask AmbientLight(Color color) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "ambientLight",
                color.R,
                color.G,
                color.B,
                color.A
            ) : new ValueTask();

        public ValueTask DirectionalLight(Color color, float x, float y, float z) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "directionalLight",
                color.R,
                color.G,
                color.B,
                x,
                y,
                z
            ) : new ValueTask();

        public ValueTask DirectionalLight(Color color, Vector3 direction) => DirectionalLight(
            color,
            direction.X,
            direction.Y,
            direction.Z
        );

        public ValueTask LightFalloff(
            float constant = 1f,
            float linear = 0f,
            float quadratic = 0f
        ) => IsWebGl ? _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "lightFalloff",
            constant,
            linear,
            quadratic
        ) : new ValueTask();

        public ValueTask Lights() => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "lights"
        );

        public ValueTask NoLights() => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "noLights"
        );

        public ValueTask PointLight(Color color, float x, float y, float z) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "pointLight",
                color.R,
                color.G,
                color.B,
                x,
                y,
                z
            ) : new ValueTask();

        public ValueTask PointLight(Color color, Vector3 direction) => PointLight(
            color,
            direction.X,
            direction.Y,
            direction.Z
        );

        public ValueTask SpecularColor(Color color) => 
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "specularColor",
                color.R,
                color.G,
                color.B
            ) : new ValueTask();

        public ValueTask SpotLight(
            Color color,
            Vector3 position,
            Vector3 direction,
            float angle = (float)(Math.PI / 3),
            float concentration = 100f
        ) => IsWebGl ? _JS.InvokeVoidAsync(
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
            ) : new ValueTask();
        #endregion

        #endregion
    }
}
