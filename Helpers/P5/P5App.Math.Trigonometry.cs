using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask SetAngleMode(AngleMode mode) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "angleMode",
            AngleModeToString(mode)
        );
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