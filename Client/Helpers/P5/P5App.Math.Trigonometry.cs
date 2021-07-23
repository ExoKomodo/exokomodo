using Client.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;

namespace Client.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void SetAngleMode(AngleMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "angleMode",
                AngleModeToString(mode)
            );
        }
        #endregion

        #region Static Methods
        public static string AngleModeToString(AngleMode mode) => mode switch
        {
            AngleMode.Degrees => "degrees",
            AngleMode.Radians => "radians",
            _ => throw new Exception("Invalid AngleMode"),
        };
        #endregion

        #endregion
    }
}