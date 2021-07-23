using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Numerics;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void DrawBezier(
            float x1,
            float y1,
            float z1,
            float x2,
            float y2,
            float z2,
            float x3,
            float y3,
            float z3,
            float x4,
            float y4,
            float z4
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "bezier",
                x1,
                y1,
                z1,
                x2,
                y2,
                z2,
                x3,
                y3,
                z3,
                x4,
                y4,
                z4
            );
        }

        public void DrawBezier(
            Vector3 firstAnchor,
            Vector3 firstControl,
            Vector3 secondControl,
            Vector3 secondAnchor
        ) => DrawBezier(
            firstAnchor.X,
            firstAnchor.Y,
            firstAnchor.Z,
            firstControl.X,
            firstControl.Y,
            firstControl.Z,
            secondControl.X,
            secondControl.Y,
            secondControl.Z,
            secondAnchor.X,
            secondAnchor.Y,
            secondAnchor.Z
        );
        
        public void DrawBezier(Bezier bezier) => DrawBezier(
            bezier.FirstAnchor,
            bezier.FirstControl,
            bezier.SecondControl,
            bezier.SecondAnchor
        );

        public void DrawBezierPoint(
            float firstPoint,
            float firstControl,
            float secondControl,
            float secondPoint,
            float t
        )
        {
            t = Math.Clamp(t, 0, 1);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "bezierPoint",
                firstPoint,
                firstControl,
                secondControl,
                secondPoint,
                t
            );
        }

        public void DrawBezierTangent(
            float firstPoint,
            float firstControl,
            float secondControl,
            float secondPoint,
            float t
        )
        {
            t = Math.Clamp(t, 0, 1);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "bezierTangent",
                firstPoint,
                firstControl,
                secondControl,
                secondPoint,
                t
            );
        }

        public void DrawCurve(
            float x1,
            float y1,
            float x2,
            float y2,
            float x3,
            float y3,
            float x4,
            float y4
        ) => DrawCurve(
            x1,
            y1,
            0,
            x2,
            y2,
            0,
            x3,
            y3,
            0,
            x4,
            y4,
            0
        );

        public void DrawCurve(
            float x1,
            float y1,
            float z1,
            float x2,
            float y2,
            float z2,
            float x3,
            float y3,
            float z3,
            float x4,
            float y4,
            float z4
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curve",
                x1,
                y1,
                z1,
                x2,
                y2,
                z2,
                x3,
                y3,
                z3,
                x4,
                y4,
                z4
            );
        }

        public void DrawCurve(
            Vector2 beginningControl,
            Vector2 firstPoint,
            Vector2 secondPoint,
            Vector2 endingControl
        ) => DrawCurve(
            beginningControl.X,
            beginningControl.Y,
            firstPoint.X,
            firstPoint.Y,
            secondPoint.X,
            secondPoint.Y,
            endingControl.X,
            endingControl.Y
        );

        public void DrawCurve(
            Vector3 beginningControl,
            Vector3 firstPoint,
            Vector3 secondPoint,
            Vector3 endingControl
        ) => DrawCurve(
            beginningControl.X,
            beginningControl.Y,
            beginningControl.Z,
            firstPoint.X,
            firstPoint.Y,
            firstPoint.Z,
            secondPoint.X,
            secondPoint.Y,
            secondPoint.Z,
            endingControl.X,
            endingControl.Y,
            endingControl.Z
        );

        public void DrawCurve(Curve curve) => DrawCurve(
            curve.BeginningControl,
            curve.FirstPoint,
            curve.SecondPoint,
            curve.EndingControl
        );

        public void DrawCurvePoint(
            float firstControl,
            float firstPoint,
            float secondPoint,
            float secondControl,
            float t
        )
        {
            t = Math.Clamp(t, 0, 1);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curvePoint",
                firstControl,
                firstPoint,
                secondPoint,
                secondControl,
                t
            );
        }

        public void DrawCurveTangent(
            float firstControl,
            float firstPoint,
            float secondPoint,
            float secondControl,
            float t
        )
        {
            t = Math.Clamp(t, 0, 1);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curveTangent",
                firstControl,
                firstPoint,
                secondPoint,
                secondControl,
                t
            );
        }

        public void DrawCurveTightness(float amount)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curveTightness",
                amount
            );
        }

        public void SetBezierDetail(uint detail = 20)
        {
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "bezierDetail",
                    detail
                );
            }
        }

        public void SetCurveDetail(uint detail = 20)
        {
            if (IsWebGl)
            {
                detail = Math.Max(3, detail);
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "curveDetail",
                    detail
                );
            }
        }
        #endregion

        #endregion
    }
}