using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void BeginContour()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "beginContour"
            );
        }

        public void BeginShape()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "beginShape"
            );
        }

        public void BeginShape(ShapeKind kind)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "beginShape",
                (uint)kind
            );
        }

        public void BezierVertex(
            double x2,
            double y2,
            double x3,
            double y3,
            double x4,
            double y4
        ) => BezierVertex(
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

        public void BezierVertex(
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
            if (IsWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "bezierVertex",
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
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "bezierVertex",
                    x2,
                    y2,
                    x3,
                    y3,
                    x4,
                    y4
                );
            }
        }

        public void BezierVertex(
            Vector2 firstControl,
            Vector2 secondControl,
            Vector2 secondAnchor
        ) => BezierVertex(
            firstControl.X,
            firstControl.Y,
            secondControl.X,
            secondControl.Y,
            secondAnchor.X,
            secondAnchor.Y
        );

        public void BezierVertex(
            Vector3 firstControl,
            Vector3 secondControl,
            Vector3 secondAnchor
        ) => BezierVertex(
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
        
        public void BezierVertex(BezierVertex bezierVertex) => BezierVertex(
            bezierVertex.FirstControl,
            bezierVertex.SecondControl,
            bezierVertex.SecondAnchor
        );

        public void CurveVertex(
            double x,
            double y,
            double z = 0
        )
        {
            if (IsWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "curveVertex",
                    x,
                    y,
                    z
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "curveVertex",
                    x,
                    y
                );
            }
        }

        public void CurveVertex(Vector2 vertex) => CurveVertex(
            vertex.X,
            vertex.Y
        );

        public void CurveVertex(Vector3 vertex) => CurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );
        
        public void CurveVertex(CurveVertex vertex) => CurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );

        public void EndContour()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "endContour"
            );
        }

        public void EndShape(bool shouldClose = false)
        {
            if (shouldClose)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "endShape",
                    "close"
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "endShape"
                );
            }
        }

        public void QuadraticVertex(
            double x1 = 0,
            double y1 = 0,
            double x2 = 0,
            double y2 = 0
        ) => QuadraticVertex(
            x1,
            y1,
            0,
            x2,
            y2,
            0
        );
        
        public void QuadraticVertex(
            double x1 = 0,
            double y1 = 0,
            double z1 = 0,
            double x2 = 0,
            double y2 = 0,
            double z2 = 0
        )
        {
            if (IsWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "quadraticVertex",
                    x1,
                    y1,
                    z1,
                    x2,
                    y2,
                    z2
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "quadraticVertex",
                    x1,
                    y1,
                    x2,
                    y2
                );
            }
        }

        public void QuadraticVertex(
            Vector2 controlPoint,
            Vector2 anchorPoint
        ) => QuadraticVertex(
            controlPoint.X,
            controlPoint.Y,
            anchorPoint.X,
            anchorPoint.Y
        );

        public void QuadraticVertex(
            Vector3 controlPoint,
            Vector3 anchorPoint
        ) => QuadraticVertex(
            controlPoint.X,
            controlPoint.Y,
            controlPoint.Z,
            anchorPoint.X,
            anchorPoint.Y,
            anchorPoint.Z
        );

        public void QuadraticVertex(QuadraticVertex vertex) => QuadraticVertex(
            vertex.ControlPoint,
            vertex.AnchorPoint
        );

        public void Vertex(double x, double y) => Vertex(x, y, 0);
        public void Vertex(double x, double y, double u, double v) => Vertex(x, y, 0, u, v);
        public void Vertex(double x, double y, double z)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "vertex",
                x,
                y,
                z
            );
        }
        public void Vertex(double x, double y, double z, double u, double v)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "vertex",
                x,
                y,
                z,
                u,
                v
            );
        }

        public void Vertex(Vector2 position, Vector2? uv = null)
        {
            if (uv.HasValue)
            {
                Vertex(position.X, position.Y, uv.Value.X, uv.Value.Y);
            }
            else
            {
                Vertex(position);
            }
        }

        public void Vertex(Vector3 position, Vector2? uv = null)
        {
            if (uv.HasValue)
            {
                Vertex(
                    position.X,
                    position.Y,
                    position.Z,
                    uv.Value.X,
                    uv.Value.Y
                );
            }
            else
            {
                Vertex(position);
            }
        }

        public void Vertex(Vertex vertex) => Vertex(vertex.Position, vertex.UV);
        #endregion

        #endregion
    }
}