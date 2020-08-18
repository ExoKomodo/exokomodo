using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void Rotate(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotate",
                angle
            );
        }

        public void RotateX(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateX",
                angle
            );
        }

        public void RotateY(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateY",
                angle
            );
        }

        public void RotateZ(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateZ",
                angle
            );
        }

        public void Scale(double[] scales)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "scale",
                scales
            );
        }

        public void ShearX(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "shearX",
                angle
            );
        }

        public void ShearY(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "shearY",
                angle
            );
        }

        public void Translate(
            double x,
            double y,
            double z = 0
        )
        {
            if (IsWebGL)
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