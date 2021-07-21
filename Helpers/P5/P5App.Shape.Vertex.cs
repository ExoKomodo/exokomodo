using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System.Numerics;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public ValueTask BeginContour() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "beginContour"
            );

        public ValueTask BeginShape() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "beginShape"
            );

        public ValueTask BeginShape(ShapeKind kind) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "beginShape",
                (uint)kind
            );

        public ValueTask DrawBezierVertex(
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

        public ValueTask DrawBezierVertex(
            float x2,
            float y2,
            float z2,
            float x3,
            float y3,
            float z3,
            float x4,
            float y4,
            float z4
        ) => IsWebGl ? _JS.InvokeVoidAsync(
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
            ) : _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "bezierVertex",
                x2,
                y2,
                x3,
                y3,
                x4,
                y4
            );

        public ValueTask DrawBezierVertex(
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

        public ValueTask DrawBezierVertex(
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
        
        public ValueTask DrawBezierVertex(BezierVertex bezierVertex) => DrawBezierVertex(
            bezierVertex.FirstControl,
            bezierVertex.SecondControl,
            bezierVertex.SecondAnchor
        );

        public ValueTask DrawCurveVertex(
            float x,
            float y,
            float z = 0
        ) => IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "curveVertex",
                x,
                y,
                z
            ) : _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "curveVertex",
                x,
                y
            );

        public ValueTask DrawCurveVertex(Vector2 vertex) => DrawCurveVertex(
            vertex.X,
            vertex.Y
        );

        public ValueTask DrawCurveVertex(Vector3 vertex) => DrawCurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );
        
        public ValueTask DrawCurveVertex(CurveVertex vertex) => DrawCurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );

        public ValueTask DrawQuadraticVertex(
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
        
        public ValueTask DrawQuadraticVertex(
            float x1 = 0,
            float y1 = 0,
            float z1 = 0,
            float x2 = 0,
            float y2 = 0,
            float z2 = 0
        ) => IsWebGl ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "quadraticVertex",
                x1,
                y1,
                z1,
                x2,
                y2,
                z2
            ) : _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "quadraticVertex",
                x1,
                y1,
                x2,
                y2
            );

        public ValueTask DrawQuadraticVertex(
            Vector2 controlPoint,
            Vector2 anchorPoint
        ) => DrawQuadraticVertex(
            controlPoint.X,
            controlPoint.Y,
            anchorPoint.X,
            anchorPoint.Y
        );

        public ValueTask DrawQuadraticVertex(
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

        public ValueTask DrawQuadraticVertex(QuadraticVertex vertex) => DrawQuadraticVertex(
            vertex.ControlPoint,
            vertex.AnchorPoint
        );

        public ValueTask DrawVertex(float x, float y) => DrawVertex(x, y, 0);
        public ValueTask DrawVertex(float x, float y, float u, float v) => DrawVertex(x, y, 0, u, v);
        public ValueTask DrawVertex(float x, float y, float z) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "vertex",
                x,
                y,
                z
            );
        public ValueTask DrawVertex(float x, float y, float z, float u, float v) =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "vertex",
                x,
                y,
                z,
                u,
                v
            );

        public ValueTask DrawVertex(Vector2 position, Vector2? uv = null) =>
            uv.HasValue ? DrawVertex(
                position.X,
                position.Y,
                uv.Value.X,
                uv.Value.Y
            ) : DrawVertex(position);

        public ValueTask DrawVertex(Vector3 position, Vector2? uv = null) =>
            uv.HasValue ? DrawVertex(
                position.X,
                position.Y,
                position.Z,
                uv.Value.X,
                uv.Value.Y
            ) : DrawVertex(position);

        public ValueTask DrawVertex(Vertex vertex) => DrawVertex(vertex.Position, vertex.UV);

        public ValueTask EndContour() =>
            _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "endContour"
            );

        public ValueTask EndShape(bool shouldClose = false) =>
            shouldClose ? _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "endShape",
                "close"
            ) : _JS.InvokeVoidAsync(
                _p5InvokeFunction,
                "endShape"
            );
        #endregion

        #endregion
    }
}