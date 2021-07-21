using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask DrawBezier(
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
        ) => _JS.InvokeVoidAsync(
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

        public ValueTask DrawBezier(
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
        
        public ValueTask DrawBezier(Bezier bezier) => DrawBezier(
            bezier.FirstAnchor,
            bezier.FirstControl,
            bezier.SecondControl,
            bezier.SecondAnchor
        );

        public ValueTask DrawBezierPoint(
            float firstPoint,
            float firstControl,
            float secondControl,
            float secondPoint,
            float t
        ) => _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "bezierPoint",
                firstPoint,
                firstControl,
                secondControl,
                secondPoint,
                Math.Clamp(t, 0, 1)
            );

        public ValueTask DrawBezierTangent(
            float firstPoint,
            float firstControl,
            float secondControl,
            float secondPoint,
            float t
        ) => _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "bezierTangent",
                firstPoint,
                firstControl,
                secondControl,
                secondPoint,
                Math.Clamp(t, 0, 1)
            );

        public ValueTask DrawCurve(
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

        public ValueTask DrawCurve(
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
        ) => _JS.InvokeVoidAsync(
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

        public ValueTask DrawCurve(
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

        public ValueTask DrawCurve(
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

        public ValueTask DrawCurve(Curve curve) => DrawCurve(
            curve.BeginningControl,
            curve.FirstPoint,
            curve.SecondPoint,
            curve.EndingControl
        );

        public ValueTask DrawCurvePoint(
            float firstControl,
            float firstPoint,
            float secondPoint,
            float secondControl,
            float t
        ) => _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "curvePoint",
                firstControl,
                firstPoint,
                secondPoint,
                secondControl,
                Math.Clamp(t, 0, 1)
            );

        public ValueTask DrawCurveTangent(
            float firstControl,
            float firstPoint,
            float secondPoint,
            float secondControl,
            float t
        ) => _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "curveTangent",
                firstControl,
                firstPoint,
                secondPoint,
                secondControl,
                Math.Clamp(t, 0, 1)
            );

        public ValueTask DrawCurveTightness(float amount) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "curveTightness",
                amount
            );

        public ValueTask SetBezierDetail(uint detail = 20) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "bezierDetail",
                detail
            ) : new ValueTask();

        public ValueTask SetCurveDetail(uint detail = 20) =>
            IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "curveDetail",
                Math.Max(3, detail)
            ) : new ValueTask();
        #endregion

        #endregion
    }
}