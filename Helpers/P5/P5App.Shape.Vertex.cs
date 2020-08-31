using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;

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

        public void DrawBezierVertex(
            float x2,
            float y2,
            float x3,
            float y3,
            float x4,
            float y4
        ) => DrawBezierVertex(
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

        public void DrawBezierVertex(
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
            if (IsWebGl)
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

        public void DrawBezierVertex(
            Vector2 firstControl,
            Vector2 secondControl,
            Vector2 secondAnchor
        ) => DrawBezierVertex(
            firstControl.X,
            firstControl.Y,
            secondControl.X,
            secondControl.Y,
            secondAnchor.X,
            secondAnchor.Y
        );

        public void DrawBezierVertex(
            Vector3 firstControl,
            Vector3 secondControl,
            Vector3 secondAnchor
        ) => DrawBezierVertex(
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
        
        public void DrawBezierVertex(BezierVertex bezierVertex) => DrawBezierVertex(
            bezierVertex.FirstControl,
            bezierVertex.SecondControl,
            bezierVertex.SecondAnchor
        );

        public void DrawCurveVertex(
            float x,
            float y,
            float z = 0
        )
        {
            if (IsWebGl)
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

        public void DrawCurveVertex(Vector2 vertex) => DrawCurveVertex(
            vertex.X,
            vertex.Y
        );

        public void DrawCurveVertex(Vector3 vertex) => DrawCurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );
        
        public void DrawCurveVertex(CurveVertex vertex) => DrawCurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );

        public void DrawQuadraticVertex(
            float x1 = 0,
            float y1 = 0,
            float x2 = 0,
            float y2 = 0
        ) => DrawQuadraticVertex(
            x1,
            y1,
            0,
            x2,
            y2,
            0
        );
        
        public void DrawQuadraticVertex(
            float x1 = 0,
            float y1 = 0,
            float z1 = 0,
            float x2 = 0,
            float y2 = 0,
            float z2 = 0
        )
        {
            if (IsWebGl)
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

        public void DrawQuadraticVertex(
            Vector2 controlPoint,
            Vector2 anchorPoint
        ) => DrawQuadraticVertex(
            controlPoint.X,
            controlPoint.Y,
            anchorPoint.X,
            anchorPoint.Y
        );

        public void DrawQuadraticVertex(
            Vector3 controlPoint,
            Vector3 anchorPoint
        ) => DrawQuadraticVertex(
            controlPoint.X,
            controlPoint.Y,
            controlPoint.Z,
            anchorPoint.X,
            anchorPoint.Y,
            anchorPoint.Z
        );

        public void DrawQuadraticVertex(QuadraticVertex vertex) => DrawQuadraticVertex(
            vertex.ControlPoint,
            vertex.AnchorPoint
        );

        public void DrawVertex(float x, float y) => DrawVertex(x, y, 0);
        public void DrawVertex(float x, float y, float u, float v) => DrawVertex(x, y, 0, u, v);
        public void DrawVertex(float x, float y, float z)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "vertex",
                x,
                y,
                z
            );
        }
        public void DrawVertex(float x, float y, float z, float u, float v)
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

        public void DrawVertex(Vector2 position, Vector2? uv = null)
        {
            if (uv.HasValue)
            {
                DrawVertex(position.X, position.Y, uv.Value.X, uv.Value.Y);
            }
            else
            {
                DrawVertex(position);
            }
        }

        public void DrawVertex(Vector3 position, Vector2? uv = null)
        {
            if (uv.HasValue)
            {
                DrawVertex(
                    position.X,
                    position.Y,
                    position.Z,
                    uv.Value.X,
                    uv.Value.Y
                );
            }
            else
            {
                DrawVertex(position);
            }
        }

        public void DrawVertex(Vertex vertex) => DrawVertex(vertex.Position, vertex.UV);

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
        #endregion

        #endregion
    }
}