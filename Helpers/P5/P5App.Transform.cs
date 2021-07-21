using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask ApplyMatrix(
            float a,
            float b,
            float c,
            float d,
            float e,
            float f
        ) =>_JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "applyMatrix",
                a,
                b,
                c,
                d,
                e,
                f
            );

        public ValueTask ResetMatrix() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "resetMatrix"
            );

        public ValueTask Rotate(float angle) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "rotate",
                angle
            );

        public ValueTask RotateX(float angle) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "rotateX",
                angle
            );

        public ValueTask RotateY(float angle) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "rotateY",
                angle
            );

        public ValueTask RotateZ(float angle) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "rotateZ",
                angle
            );

        public ValueTask Scale(float scales) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "scale",
                scales
            );
        
        public ValueTask Scale(float x, float y) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "scale",
                x,
                y
            );

        public ValueTask Scale(float x, float y, float z) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "scale",
                x,
                y,
                z
            ) : Scale(x, y);

        public ValueTask ShearX(float angle) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "shearX",
                angle
            );

        public ValueTask ShearY(float angle) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "shearY",
                angle
            );

        public ValueTask Translate(
            float x,
            float y,
            float z = 0
        ) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "translate",
                x,
                y,
                z
            ) : _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "translate",
                x,
                y
            );

        public ValueTask Translate(Vector2 translation) => Translate(
            translation.X,
            translation.Y,
            0
        );

        public ValueTask Translate(Vector3 translation) => Translate(
            translation.X,
            translation.Y,
            translation.Z
        );
        #endregion

        #endregion
    }
}