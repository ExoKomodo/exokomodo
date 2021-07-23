using ExoKomodo.Helpers.P5.Enums;
using Microsoft.JSInterop;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void SetDebugMode()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "debugMode"
            );
        }

        public void SetDebugMode(DebugMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "debugMode",
                DebugModeToString(mode)
            );
        }

        public void SetDebugMode(
            DebugMode mode,
            float gridSize
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "debugMode",
                DebugModeToString(mode),
                gridSize
            );
        }

        public void NoDebugMode()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noDebugMode"
            );
        }

        public void OrbitControl(float x = 1f, float y = 1f, float z = 1f)
        {
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "orbitControl",
                    x,
                    y,
                    z
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
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
