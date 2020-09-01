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
        public void DrawArc(
            float x,
            float y,
            float width,
            float height,
            float startAngle,
            float stopAngle,
            ArcMode mode = ArcMode.Pie,
            uint detail = Arc.DEFAULT_DETAIL
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "arc",
                x,
                y,
                width,
                height,
                startAngle,
                stopAngle,
                Arc.ArcModeToString(mode),
                detail
            );
        }

        public void DrawArc(
            Vector2 position,
            Vector2 dimensions,
            float startAngle,
            float stopAngle,
            ArcMode mode = ArcMode.Pie,
            uint detail = Arc.DEFAULT_DETAIL
        ) => DrawArc(
            position.X,
            position.Y,
            dimensions.X,
            dimensions.Y,
            startAngle,
            stopAngle,
            mode,
            detail
        );

        public void DrawArc(Arc arc) => DrawArc(
            arc.X,
            arc.Y,
            arc.Width,
            arc.Height,
            arc.StartAngle,
            arc.StopAngle,
            arc.Mode,
            arc.Detail
        );

        public void DrawCircle(float x, float y, float d)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "circle",
                x,
                y,
                d
            );
        }

        public void DrawCircle(Vector2 position, float d) => DrawCircle(
            position.X,
            position.Y,
            d
        );

        public void DrawCircle(Circle circle) => DrawCircle(
            circle.X,
            circle.Y,
            circle.Diameter
        );

        public void DrawEllipse(
            float x,
            float y,
            float width,
            double? height = null,
            uint detail = Ellipse.DEFAULT_DETAIL
        )
        {
            if (!height.HasValue)
            {
                height = width;
            }
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "ellipse",
                    x,
                    y,
                    width,
                    height,
                    detail
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "ellipse",
                    x,
                    y,
                    width,
                    height
                );
            }
        }

        public void DrawEllipse(
            Vector2 position,
            Vector2 dimensions,
            uint detail = Ellipse.DEFAULT_DETAIL
        ) => DrawEllipse(
            position.X,
            position.Y,
            dimensions.X,
            dimensions.Y,
            detail
        );

        public void DrawEllipse(Ellipse ellipse) => DrawEllipse(
            ellipse.Position,
            ellipse.Dimensions,
            ellipse.Detail
        );

        public void DrawLine(
            float x1,
            float y1,
            float x2,
            float y2
        ) => DrawLine(
            x1,
            y1,
            0,
            x2,
            y2,
            0
        );

        public void DrawLine(
            float x1,
            float y1,
            float z1,
            float x2,
            float y2,
            float z2
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "line",
                x1,
                y1,
                z1,
                x2,
                y2,
                z2
            );
        }

        public void DrawLine(Vector2 start, Vector2 end) => DrawLine(
            start.X,
            start.Y,
            end.X,
            end.Y
        );

        public void DrawLine(Vector3 start, Vector3 end) => DrawLine(
            start.X,
            start.Y,
            start.Z,
            end.X,
            end.Y,
            end.Z
        );

        public void DrawLine(Line line) => DrawLine(
            line.Start,
            line.End
        );

        public void DrawPoint(
            float x,
            float y,
            float z = 0
        )
        {
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                    "point",
                    x,
                    y,
                    z
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "point",
                    x,
                    y
                );
            }
            
        }
        
        public void DrawPoint(Vector2 point) => DrawPoint(
            point.X,
            point.Y
        );

        public void DrawPoint(Vector3 point) => DrawPoint(
            point.X,
            point.Y,
            point.Z
        );

        public void DrawQuad(
            float x1,
            float y1,
            float x2,
            float y2,
            float x3,
            float y3,
            float x4,
            float y4
        ) => DrawQuad(
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

        public void DrawQuad(
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
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "quad",
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
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "quad",
                    x1,
                    y1,
                    x2,
                    y2,
                    x3,
                    y3,
                    x4,
                    y4
                );
            }
        }

        public void DrawQuad(
            Vector2 v1,
            Vector2 v2,
            Vector2 v3,
            Vector2 v4
        ) => DrawQuad(
            v1.X,
            v1.Y,
            v2.X,
            v2.Y,
            v3.X,
            v3.Y,
            v4.X,
            v4.Y
        );

        public void DrawQuad(
            Vector3 v1,
            Vector3 v2,
            Vector3 v3,
            Vector3 v4
        ) => DrawQuad(
            v1.X,
            v1.Y,
            v1.Z,
            v2.X,
            v2.Y,
            v2.Z,
            v3.X,
            v3.Y,
            v3.Z,
            v4.X,
            v4.Y,
            v4.Z
        );
        
        public void DrawQuad(Quad quad) => DrawQuad(
            quad.V1,
            quad.V2,
            quad.V3,
            quad.V4
        );

        public void DrawRectangle(
            float x,
            float y,
            float width,
            double? height = null,
            float topLeftRadius = 0,
            float topRightRadius = 0,
            float bottomRightRadius = 0,
            float bottomLeftRadius = 0,
            uint detailX = Rectangle.DEFAULT_DETAIL,
            uint detailY = Rectangle.DEFAULT_DETAIL
        )
        {
            if (IsWebGl)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "rect",
                    x,
                    y,
                    width,
                    height.HasValue ? height.Value : width,
                    topLeftRadius,
                    topRightRadius,
                    bottomRightRadius,
                    bottomLeftRadius,
                    detailX,
                    detailY
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "rect",
                    x,
                    y,
                    width,
                    height.HasValue ? height.Value : width,
                    topLeftRadius,
                    topRightRadius,
                    bottomRightRadius,
                    bottomLeftRadius
                );
            }
        }

        public void DrawRectangle(
            Vector2 position,
            Vector2 dimensions,
            float topLeftRadius = 0,
            float topRightRadius = 0,
            float bottomRightRadius = 0,
            float bottomLeftRadius = 0,
            uint detailX = Rectangle.DEFAULT_DETAIL,
            uint detailY = Rectangle.DEFAULT_DETAIL
        ) => DrawRectangle(
            position.X,
            position.Y,
            dimensions.X,
            dimensions.Y,
            topLeftRadius,
            topRightRadius,
            bottomRightRadius,
            bottomLeftRadius,
            detailX,
            detailY
        );

        public void DrawRectangle(Rectangle rect) => DrawRectangle(
            rect.X,
            rect.Y,
            rect.Width,
            rect.Height,
            rect.TopLeftRadius,
            rect.TopRightRadius,
            rect.BottomRightRadius,
            rect.BottomLeftRadius,
            rect.DetailX,
            rect.DetailY
        );

        public void DrawSquare(
            float x,
            float y,
            float side,
            double? topLeftRadius = null,
            double? topRightRadius = null,
            double? bottomRightRadius = null,
            double? bottomLeftRadius = null
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "square",
                x,
                y,
                side,
                topLeftRadius,
                topRightRadius,
                bottomRightRadius,
                bottomLeftRadius
            );
        }

        public void DrawSquare(
            Vector2 position,
            float side,
            double? topLeftRadius = null,
            double? topRightRadius = null,
            double? bottomRightRadius = null,
            double? bottomLeftRadius = null
        ) => DrawSquare(
            position.X,
            position.Y,
            side,
            topLeftRadius,
            topRightRadius,
            bottomRightRadius,
            bottomLeftRadius
        );

        public void DrawSquare(Square square) => DrawSquare(
            square.Position,
            square.Side,
            square.TopLeftRadius,
            square.TopRightRadius,
            square.BottomRightRadius,
            square.BottomLeftRadius
        );

        public void DrawTriangle(
            float x1,
            float y1,
            float x2,
            float y2,
            float x3,
            float y3
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "triangle",
                x1,
                y1,
                x2,
                y2,
                x3,
                y3
            );
        }

        public void DrawTriangle(
            Vector2 v1,
            Vector2 v2,
            Vector2 v3
        ) => DrawTriangle(
            v1.X,
            v1.Y,
            v2.X,
            v2.Y,
            v3.X,
            v3.Y
        );

        public void DrawTriangle(Triangle triangle) => DrawTriangle(
            triangle.V1,
            triangle.V2,
            triangle.V3
        );
        #endregion

        #endregion
    }
}