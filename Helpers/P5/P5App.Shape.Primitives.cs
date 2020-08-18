using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Models;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Member Methods
        public void Arc(
            double x,
            double y,
            double w,
            double h,
            double startAngle,
            double stopAngle,
            Enums.ArcMode mode = Enums.ArcMode.Pie,
            uint detail = 25
        )
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "arc",
                x,
                y,
                w,
                h,
                startAngle,
                stopAngle,
                Models.Arc.ToString(mode),
                detail
            );
        }

        public void Arc(
            Vector2 position,
            Vector2 dimensions,
            double startAngle,
            double stopAngle,
            Enums.ArcMode mode = Enums.ArcMode.Pie,
            uint detail = 25
        ) => Arc(
            position.X,
            position.Y,
            dimensions.X,
            dimensions.Y,
            startAngle,
            stopAngle,
            mode,
            detail
        );

        public void Arc(Arc arc) => Arc(
            arc.X,
            arc.Y,
            arc.Width,
            arc.Height,
            arc.StartAngle,
            arc.StopAngle,
            arc.Mode,
            arc.Detail
        );

        public void Circle(double x, double y, double d)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "circle",
                x,
                y,
                d
            );
        }

        public void Circle(Vector2 position, double d) => Circle(
            position.X,
            position.Y,
            d
        );

        public void Circle(Circle circle) => Circle(
            circle.X,
            circle.Y,
            circle.Diameter
        );

        public void Ellipse(
            double x,
            double y,
            double w,
            double? h = null,
            uint detail = 25
        )
        {
            if (!h.HasValue)
            {
                h = w;
            }
            if (IsWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "ellipse",
                    x,
                    y,
                    w,
                    h,
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
                    w,
                    h
                );
            }
        }

        public void Ellipse(
            Vector2 position,
            Vector2 dimensions,
            uint detail = 25
        ) => Ellipse(
            position.X,
            position.Y,
            dimensions.X,
            dimensions.Y,
            detail
        );

        public void Ellipse(Ellipse ellipse) => Ellipse(
            ellipse.Position,
            ellipse.Dimensions,
            ellipse.Detail
        );

        public void Line(
            double x1,
            double y1,
            double x2,
            double y2
        ) => Line(
            x1,
            y1,
            0,
            x2,
            y2,
            0
        );

        public void Line(
            double x1,
            double y1,
            double z1,
            double x2,
            double y2,
            double z2
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

        public void Line(Vector2 start, Vector2 end) => Line(
            start.X,
            start.Y,
            end.X,
            end.Y
        );

        public void Line(Vector3 start, Vector3 end) => Line(
            start.X,
            start.Y,
            start.Z,
            end.X,
            end.Y,
            end.Z
        );

        public void Line(Line line) => Line(
            line.Start,
            line.End
        );

        public void Point(
            double x,
            double y,
            double z = 0
        )
        {
            if (IsWebGL)
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
        
        public void Point(Vector2 point) => Point(
            point.X,
            point.Y
        );

        public void Point(Vector3 point) => Point(
            point.X,
            point.Y,
            point.Z
        );

        public void Quad(
            double x1,
            double y1,
            double x2,
            double y2,
            double x3,
            double y3,
            double x4,
            double y4
        ) => Quad(
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

        public void Quad(
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
            if (IsWebGL)
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

        public void Quad(
            Vector2 v1,
            Vector2 v2,
            Vector2 v3,
            Vector2 v4
        ) => Quad(
            v1.X,
            v1.Y,
            v2.X,
            v2.Y,
            v3.X,
            v3.Y,
            v4.X,
            v4.Y
        );

        public void Quad(
            Vector3 v1,
            Vector3 v2,
            Vector3 v3,
            Vector3 v4
        ) => Quad(
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
        
        public void Quad(Quad quad) => Quad(
            quad.V1,
            quad.V2,
            quad.V3,
            quad.V4
        );

        public void Rectangle(
            double x,
            double y,
            double w,
            double? h = null,
            double topLeftRadius = 0,
            double topRightRadius = 0,
            double bottomRightRadius = 0,
            double bottomLeftRadius = 0,
            uint detailX = 25,
            uint detailY = 25
        )
        {
            if (IsWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "rect",
                    x,
                    y,
                    w,
                    h.HasValue ? h : null,
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
                    w,
                    h.HasValue ? h : null,
                    topLeftRadius,
                    topRightRadius,
                    bottomRightRadius,
                    bottomLeftRadius
                );
            }
        }

        public void Rectangle(
            Vector2 position,
            Vector2 dimensions,
            double topLeftRadius = 0,
            double topRightRadius = 0,
            double bottomRightRadius = 0,
            double bottomLeftRadius = 0,
            uint detailX = 25,
            uint detailY = 25
        ) => Rectangle(
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

        public void Rectangle(Rectangle rect) => Rectangle(
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

        public void Square(
            double x,
            double y,
            double side,
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

        public void Square(
            Vector2 position,
            double side,
            double? topLeftRadius = null,
            double? topRightRadius = null,
            double? bottomRightRadius = null,
            double? bottomLeftRadius = null
        ) => Square(
            position.X,
            position.Y,
            side,
            topLeftRadius,
            topRightRadius,
            bottomRightRadius,
            bottomLeftRadius
        );

        public void Square(Square square) => Square(
            square.Position,
            square.Side,
            square.TopLeftRadius,
            square.TopRightRadius,
            square.BottomRightRadius,
            square.BottomLeftRadius
        );

        public void Triangle(
            double x1,
            double y1,
            double x2,
            double y2,
            double x3,
            double y3
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

        public void Triangle(
            Vector2 v1,
            Vector2 v2,
            Vector2 v3
        ) => Triangle(
            v1.X,
            v1.Y,
            v2.X,
            v2.Y,
            v3.X,
            v3.Y
        );

        public void Triangle(Triangle triangle) => Triangle(
            triangle.V1,
            triangle.V2,
            triangle.V3
        );
        #endregion

        #endregion
    }
}