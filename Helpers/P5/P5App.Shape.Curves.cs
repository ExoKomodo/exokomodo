using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void Bezier(
            double x1,
            double y1,
            double z1,
            double x2,
            double y2,
            double z2,
            double x3,
            double y3,
            double z3,
            double x4,
            double y4,
            double z4
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

        public void Bezier(
            Vector3 firstAnchor,
            Vector3 firstControl,
            Vector3 secondControl,
            Vector3 secondAnchor
        ) => Bezier(
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
        
        public void Bezier(Bezier bezier) => Bezier(
            bezier.FirstAnchor,
            bezier.FirstControl,
            bezier.SecondControl,
            bezier.SecondAnchor
        );

        public void BezierDetail(uint detail = 20)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "bezierDetail",
                detail
            );
        }

        public void BezierPoint(
            double firstPoint,
            double firstControl,
            double secondControl,
            double secondPoint,
            double t
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

        public void BezierTangent(
            double firstPoint,
            double firstControl,
            double secondControl,
            double secondPoint,
            double t
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

        public void Curve(
            double x1,
            double y1,
            double x2,
            double y2,
            double x3,
            double y3,
            double x4,
            double y4
        ) => Curve(
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

        public void Curve(
            double x1,
            double y1,
            double z1,
            double x2,
            double y2,
            double z2,
            double x3,
            double y3,
            double z3,
            double x4,
            double y4,
            double z4
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

        public void Curve(
            Vector2 beginningControl,
            Vector2 firstPoint,
            Vector2 secondPoint,
            Vector2 endingControl
        ) => Curve(
            beginningControl.X,
            beginningControl.Y,
            firstPoint.X,
            firstPoint.Y,
            secondPoint.X,
            secondPoint.Y,
            endingControl.X,
            endingControl.Y
        );

        public void Curve(
            Vector3 beginningControl,
            Vector3 firstPoint,
            Vector3 secondPoint,
            Vector3 endingControl
        ) => Curve(
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

        public void Curve(Curve curve) => Curve(
            curve.BeginningControl,
            curve.FirstPoint,
            curve.SecondPoint,
            curve.EndingControl
        );

        public void CurveDetail(uint detail = 20)
        {
            detail = Math.Max(3, detail);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curveDetail",
                detail
            );
        }

        public void CurvePoint(
            double firstControl,
            double firstPoint,
            double secondPoint,
            double secondControl,
            double t
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

        public void CurveTangent(
            double firstControl,
            double firstPoint,
            double secondPoint,
            double secondControl,
            double t
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

        public void CurveTightness(double amount)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curveTightness",
                amount
            );
        }
        #endregion

        #endregion
    }
}