using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void SetAngleMode(AngleMode mode)
        {
            var angleMode = "";
            switch (mode)
            {
                case AngleMode.Degrees:
                    angleMode = "degrees";
                    break;
                case AngleMode.Radians:
                    angleMode = "radians";
                    break;
                default:
                    throw new Exception("Invalid AngleMode");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "angleMode",
                angleMode
            );
        }
        #endregion

        #endregion
    }
}