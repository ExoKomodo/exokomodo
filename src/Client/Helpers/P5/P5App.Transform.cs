using Client.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void ApplyMatrix(
            float a,
            float b,
            float c,
            float d,
            float e,
            float f
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "applyMatrix",
                a,
                b,
                c,
                d,
                e,
                f
            );
        }

        public void ResetMatrix()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "resetMatrix"
            );
        }

        public void Rotate(float angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotate",
                angle
            );
        }

        public void RotateX(float angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateX",
                angle
            );
        }

        public void RotateY(float angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateY",
                angle
            );
        }

        public void RotateZ(float angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateZ",
                angle
            );
        }

        public void Scale(float scales)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "scale",
                scales
            );
        }
        
        public void Scale(float x, float y)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "scale",
                x,
                y
            );
        }

        public void Scale(float x, float y, float z)
        {
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "scale",
                    x,
                    y,
                    z
                );
            }
            else
            {
                Scale(x, y);
            }
        }

        public void ShearX(float angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "shearX",
                angle
            );
        }

        public void ShearY(float angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "shearY",
                angle
            );
        }

        public void Translate(
            float x,
            float y,
            float z = 0
        )
        {
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "translate",
                    x,
                    y,
                    z
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "translate",
                    x,
                    y
                );
            }
        }

        public void Translate(Vector2 translation) => Translate(
            translation.X,
            translation.Y,
            0
        );

        public void Translate(Vector3 translation) => Translate(
            translation.X,
            translation.Y,
            translation.Z
        );
        #endregion

        #endregion
    }
}