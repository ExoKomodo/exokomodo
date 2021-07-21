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
        public ValueTask SetDebugMode() => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "debugMode"
        );

        public ValueTask SetDebugMode(DebugMode mode) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "debugMode",
            DebugModeToString(mode)
        );

        public ValueTask SetDebugMode(
            DebugMode mode,
            float gridSize
        ) => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "debugMode",
            DebugModeToString(mode),
            gridSize
        );

        public ValueTask NoDebugMode() => _JS.InvokeVoidAsync(
            _p5InvokeFunction,
            "noDebugMode"
        );

        public ValueTask OrbitControl(float x = 1f, float y = 1f, float z = 1f)
        {
            if (IsWebGl)
            {
                return _JS.InvokeVoidAsync(
                    _p5InvokeFunction,
                    "orbitControl",
                    x,
                    y,
                    z
                );
            }
            else
            {
                return _JS.InvokeVoidAsync(
                    _p5InvokeFunction,
                    "orbitControl",
                    x,
                    y
                );
            }
        }
        #endregion

        #region Static Methods
        public static string DebugModeToString(DebugMode mode) => mode switch
        {
            DebugMode.Axes => "axes",
            DebugMode.Grid => "grid",
            _ => throw new Exception("Invalid DebugMode"),
        };
        #endregion

        #endregion
    }
}
