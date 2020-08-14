using System.Text.Json.Serialization;
using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using System;
using System.Threading.Tasks;

namespace ExoKomodo.Helpers.P5
{
    public abstract class P5Application
    {
        #region Public

        #region Constructors
        public P5Application(IJSRuntime jsRuntime, string containerId)
        {
            _jsRuntime = jsRuntime as IJSInProcessRuntime;
            _containerId = containerId;
        }
        #endregion

        #region Members
        public double DeltaTime => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "deltaTime"
        );
        public double DisplayDensity => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "displayDensity"
        );
        public uint DisplayHeight => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "displayHeight"
        );
        public double DisplayWidth => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "displayWidth"
        );
        public uint Height => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "height"
        );
        public string Key => _jsRuntime.Invoke<string>(
            _p5GetValue,
            "key"
        );
        public uint KeyCode => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "keyCode"
        );
        public bool KeyIsPressed => _jsRuntime.Invoke<bool>(
            _p5GetValue,
            "keyIsPressed"
        );
        public uint FrameCount => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "frameCount"
        );
        public bool IsFocused => _jsRuntime.Invoke<bool>(
            _p5GetValue,
            "focused"
        );
        public bool IsLooping => _jsRuntime.Invoke<bool>(
            _p5InvokeFunction,
            "isLooping"
        );
        public bool IsWebGL { get; protected set; }
        // Careful calling this function if the mouse is not currently pressed
        public string MouseButton => _jsRuntime.Invoke<string>(
            _p5GetValue,
            "mouseButton"
        );
        public bool MouseIsPressed => _jsRuntime.Invoke<bool>(
            _p5GetValue,
            "mouseIsPressed"
        );
        public double MouseX => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "mouseX"
        );
        public double MouseXPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pmouseX"
        );
        public double MouseY => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "mouseY"
        );
        public double MouseYPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pmouseY"
        );
        public double MouseMovedX => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "movedX"
        );
        public double MouseMovedY => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "movedY"
        );
        public string Url => _jsRuntime.Invoke<string>(
            _p5InvokeFunction,
            "getURL"
        );
        public string UrlPath => _jsRuntime.Invoke<string>(
            _p5InvokeFunction,
            "getURLPath"
        );
        public double Width => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "width"
        );
        public uint WindowHeight => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "windowHeight"
        );
        public double WindowMouseX => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "winMouseX"
        );
        public double WindowMouseXPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pwinMouseX"
        );
        public double WindowMouseY => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "winMouseY"
        );
        public double WindowMouseYPrevious => _jsRuntime.Invoke<double>(
            _p5GetValue,
            "pwinMouseY"
        );   
        public double WindowWidth => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "windowWidth"
        );
        #endregion

        #region Constants
        public const double HALF_PI = 1.57079632679489661923d;
        public const double PI = 3.14159265358979323846d;
        public const double QUARTER_PI = 0.7853982d;
        public const double TAU = 6.28318530717958647693d;
        public const double TWO_PI = 6.28318530717958647693d;
        #endregion

        #region Member Methods
        [JSInvokable("doubleClicked")]
        public virtual bool DoubleClicked()
        {
            return false; // Event prevent default
        }

        [JSInvokable("draw")]
        public abstract void Draw();

        public DotNetObjectReference<P5Application> GetJsInteropReference()
        {
            return DotNetObjectReference.Create(this);
        }

        [JSInvokable("keyPressed")]
        public virtual bool KeyPressed()
        {
            return false; // Event prevent default
        }

        [JSInvokable("keyReleased")]
        public virtual bool KeyReleased()
        {
            return false; // Event prevent default
        }

        [JSInvokable("keyTyped")]
        public virtual bool KeyTyped()
        {
            return false; // Event prevent default
        }

        [JSInvokable("mouseClicked")]
        public virtual bool MouseClicked()
        {
            return false; // Event prevent default
        }

        [JSInvokable("mouseDragged")]
        public virtual bool MouseDragged()
        {
            return false; // Event prevent default
        }

        [JSInvokable("mouseMoved")]
        public virtual bool MouseMoved()
        {
            return false; // Event prevent default
        }
        
        [JSInvokable("mousePressed")]
        public virtual bool MousePressed()
        {
            return false; // Event prevent default
        }

        [JSInvokable("mouseReleased")]
        public virtual bool MouseReleased()
        {
            return false; // Event prevent default
        }

        [JSInvokable("preload")]
        public virtual void Preload()
        {
        }

        [JSInvokable("setup")]
        public abstract void Setup();

        public void Start()
        {
            _jsRuntime.InvokeVoid("startP5", GetJsInteropReference(), _containerId);
        }

        [JSInvokable("windowResized")]
        public virtual void WindowResized()
        {
        }
        #endregion

        #endregion

        #region Protected

        #region Constants
        protected const string _p5InvokeFunction = "window.p5Instance.invokeP5Function";
        protected const string _p5GetValue = "window.p5Instance.getValue";
        #endregion

        #region Members
        protected readonly IJSInProcessRuntime _jsRuntime;
        protected readonly string _containerId;
        #endregion

        #region Member Methods
        protected void AngleMode(Enums.AngleMode mode)
        {
            var angleMode = "";
            switch (mode)
            {
                case Enums.AngleMode.Degrees:
                    angleMode = "degrees";
                    break;
                case Enums.AngleMode.Radians:
                    angleMode = "radians";
                    break;
                default:
                    throw new Exception("Invalid AngleMode");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "angleMode",
                angleMode
            );
        }

        protected void Arc(
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

        protected void Arc(
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

        protected void Arc(Arc arc) => Arc(
            arc.X,
            arc.Y,
            arc.W,
            arc.H,
            arc.StartAngle,
            arc.StopAngle,
            arc.Mode,
            arc.Detail
        );

        protected void Background(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "background",
                grayscale
            );
        }

        protected void Background(Color color)
        {
            switch (color.Mode)
            {
                case Enums.ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "background",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case Enums.ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "background",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        protected void BeginContour()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "beginContour"
            );
        }

        protected void BeginShape()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "beginShape"
            );
        }

        protected void BeginShape(ShapeKind kind)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "beginShape",
                (uint)kind
            );
        }

        protected void Bezier(
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

        protected void Bezier(
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
        
        protected void Bezier(Bezier bezier) => Bezier(
            bezier.FirstAnchor,
            bezier.FirstControl,
            bezier.SecondControl,
            bezier.SecondAnchor
        );

        protected void BezierDetail(uint detail = 20)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "bezierDetail",
                detail
            );
        }

        protected void BezierPoint(
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

        protected void BezierTangent(
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

        protected void BezierVertex(
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

        protected void BezierVertex(
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

        protected void BezierVertex(
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

        protected void BezierVertex(
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
        
        protected void BezierVertex(BezierVertex bezierVertex) => BezierVertex(
            bezierVertex.FirstControl,
            bezierVertex.SecondControl,
            bezierVertex.SecondAnchor
        );

        protected void Circle(double x, double y, double d)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "circle",
                x,
                y,
                d
            );
        }

        protected void Circle(Vector2 position, double d) => Circle(
            position.X,
            position.Y,
            d
        );

        protected void Circle(Circle circle) => Circle(
            circle.X,
            circle.Y,
            circle.D
        );

        protected void Clear()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "clear"
            );
        }

        protected void ColorMode(Enums.ColorMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "colorMode",
                Models.Color.ToString(mode)
            );
        }

        protected void CreateCanvas(uint width, uint height, bool useWebGL = false)
        {
            IsWebGL = useWebGL;
            if (useWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "createCanvas",
                    width,
                    height,
                    "webgl"
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "createCanvas",
                    width,
                    height
                );
            }
        }

        protected void Cursor(Enums.CursorMode mode)
        {
            var cursorMode = "";
            switch (mode)
            {
                case Enums.CursorMode.Arrow:
                    cursorMode = "default";
                    break;
                case Enums.CursorMode.Cross:
                    cursorMode = "crosshair";
                    break;
                case Enums.CursorMode.Hand:
                    cursorMode = "pointer";
                    break;
                case Enums.CursorMode.Move:
                    cursorMode = "move";
                    break;
                case Enums.CursorMode.Text:
                    cursorMode = "text";
                    break;
                case Enums.CursorMode.Wait:
                    cursorMode = "wait";
                    break;
                default:
                    throw new Exception("Invalid CursorMode");
            }
            Cursor(cursorMode);
        }

        protected void Cursor(Enums.CursorMode mode, uint x, uint y)
        {
            var cursorMode = "";
            switch (mode)
            {
                case Enums.CursorMode.Arrow:
                    cursorMode = "default";
                    break;
                case Enums.CursorMode.Cross:
                    cursorMode = "crosshair";
                    break;
                case Enums.CursorMode.Hand:
                    cursorMode = "pointer";
                    break;
                case Enums.CursorMode.Move:
                    cursorMode = "move";
                    break;
                case Enums.CursorMode.Text:
                    cursorMode = "text";
                    break;
                case Enums.CursorMode.Wait:
                    cursorMode = "wait";
                    break;
                default:
                    throw new Exception("Invalid CursorMode");
            }
            Cursor(cursorMode, x, y);
        }

        protected void Cursor(string mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "cursor",
                mode
            );
        }

        protected void Cursor(string mode, uint x, uint y)
        {
            x = Math.Min(x, 32);
            y = Math.Min(y, 32);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "cursor",
                mode,
                x,
                y
            );
        }

        protected void Curve(
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

        protected void Curve(
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

        protected void Curve(
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

        protected void Curve(
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

        protected void Curve(Curve curve) => Curve(
            curve.BeginningControl,
            curve.FirstPoint,
            curve.SecondPoint,
            curve.EndingControl
        );

        protected void CurveDetail(uint detail = 20)
        {
            detail = Math.Max(3, detail);
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curveDetail",
                detail
            );
        }

        protected void CurvePoint(
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

        protected void CurveTangent(
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

        protected void CurveTightness(double amount)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "curveTightness",
                amount
            );
        }

        protected void CurveVertex(
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

        protected void CurveVertex(Vector2 vertex) => CurveVertex(
            vertex.X,
            vertex.Y
        );

        protected void CurveVertex(Vector3 vertex) => CurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );
        
        protected void CurveVertex(CurveVertex vertex) => CurveVertex(
            vertex.X,
            vertex.Y,
            vertex.Z
        );

        protected void Ellipse(
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

        protected void Ellipse(
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

        protected void Ellipse(Ellipse ellipse) => Ellipse(
            ellipse.Position,
            ellipse.Dimensions,
            ellipse.Detail
        );

        protected void EllipseMode(Enums.EllipseMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ellipseMode",
                Models.Ellipse.ToString(mode)
            );
        }

        protected void EndContour()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "endContour"
            );
        }

        protected void EndShape(bool shouldClose = false)
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

        protected void Erase(byte strengthFill = 255, byte strengthStroke = 255)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "erase",
                strengthFill,
                strengthStroke
            );
        }

        protected void ExitPointerLock()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "exitPointerLock"
            );
        }

        protected void Fill(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "fill",
                grayscale
            );
        }

        protected void Fill(Color color)
        {
            switch (color.Mode)
            {
                case Enums.ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "fill",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case Enums.ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "fill",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }
        
        protected double FrameRate() => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "frameRate"
        );

        protected void FrameRate(double fps)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "frameRate",
                fps
            );
        }

        protected bool Fullscreen() => _jsRuntime.Invoke<bool>(
            _p5InvokeFunction,
            "fullscreen"
        );

        protected void Fullscreen(bool isFullscreen)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "fullscreen",
                isFullscreen
            );
        }

        protected bool IsKeyDown(uint code) => _jsRuntime.Invoke<bool>(
            _p5InvokeFunction,
            "keyIsDown",
            code
        );

        protected void Line(
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

        protected void Line(
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

        protected void Line(Vector2 start, Vector2 end) => Line(
            start.X,
            start.Y,
            end.X,
            end.Y
        );

        protected void Line(Vector3 start, Vector3 end) => Line(
            start.X,
            start.Y,
            start.Z,
            end.X,
            end.Y,
            end.Z
        );

        protected void Line(Line line) => Line(
            line.Start,
            line.End
        );

        protected void Loop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "loop"
            );
        }


        protected void NoCursor()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noCursor"
            );
        }

        protected void NoErase()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noErase"
            );
        }

        protected void NoFill()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noFill"
            );
        }

        protected void NoLoop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noLoop"
            );
        }

        protected void NoSmooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noSmooth"
            );
        }

        protected void NoStroke()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noStroke"
            );
        }

        protected double PixelDensity() => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "pixelDensity"
        );

        protected void PixelDensity(double density)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "pixelDensity",
                density
            );
        }

        protected void Point(
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
        
        protected void Point(Vector2 point) => Point(
            point.X,
            point.Y
        );

        protected void Point(Vector3 point) => Point(
            point.X,
            point.Y,
            point.Z
        );

        protected void Pop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "pop"
            );
        }

        protected void Push()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "push"
            );
        }

        protected void Quad(
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

        protected void Quad(
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

        protected void Quad(
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

        protected void Quad(
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
        
        protected void Quad(Quad quad) => Quad(
            quad.V1,
            quad.V2,
            quad.V3,
            quad.V4
        );

        protected void QuadraticVertex(
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
        
        protected void QuadraticVertex(
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

        protected void QuadraticVertex(
            Vector2 controlPoint,
            Vector2 anchorPoint
        ) => QuadraticVertex(
            controlPoint.X,
            controlPoint.Y,
            anchorPoint.X,
            anchorPoint.Y
        );

        protected void QuadraticVertex(
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

        protected void QuadraticVertex(QuadraticVertex vertex) => QuadraticVertex(
            vertex.ControlPoint,
            vertex.AnchorPoint
        );

        protected void Rectangle(
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

        protected void Rectangle(
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

        protected void Rectangle(Rectangle rect) => Rectangle(
            rect.X,
            rect.Y,
            rect.W,
            rect.H,
            rect.TopLeftRadius,
            rect.TopRightRadius,
            rect.BottomRightRadius,
            rect.BottomLeftRadius,
            rect.DetailX,
            rect.DetailY
        );

        protected void RectangleMode(Enums.RectangleMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rectMode",
                Models.Rectangle.ToString(mode)
            );
        }

        protected void Redraw(uint times = 1)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "redraw",
                times
            );
        }

        protected void Remove()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "remove"
            );
        }

        protected void RequestPointerLock()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "requestPointerLock"
            );
        }

        protected void Smooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "smooth"
            );
        }

        protected void Square(
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

        protected void Square(
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

        protected void Square(Square square) => Square(
            square.Position,
            square.Side,
            square.TopLeftRadius,
            square.TopRightRadius,
            square.BottomRightRadius,
            square.BottomLeftRadius
        );

        protected void Stroke(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "stroke",
                grayscale
            );
        }

        protected void Stroke(Color color)
        {
            switch (color.Mode)
            {
                case Enums.ColorMode.RGB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "stroke",
                        color.Red,
                        color.Green,
                        color.Blue
                    );
                    break;
                case Enums.ColorMode.HSB:
                    _jsRuntime.InvokeVoid(
                        _p5InvokeFunction,
                        "stroke",
                        color.Hue,
                        color.Saturation,
                        color.Brightness
                    );
                    break;
            }
        }

        protected void StrokeCap(Enums.StrokeCap cap)
        {
            var mode = "";
            switch (cap)
            {
                case Enums.StrokeCap.Project:
                    mode = "project";
                    break;
                case Enums.StrokeCap.Round:
                    mode = "round";
                    break;
                case Enums.StrokeCap.Square:
                    mode = "square";
                    break;
                default:
                    throw new Exception("Invalid StrokeCap");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeCap",
                mode
            );
        }

        protected void StrokeJoin(Enums.StrokeJoin join)
        {
            var mode = "";
            switch (join)
            {
                case Enums.StrokeJoin.Bevel:
                    mode = "bevel";
                    break;
                case Enums.StrokeJoin.Miter:
                    mode = "miter";
                    break;
                case Enums.StrokeJoin.Round:
                    mode = "round";
                    break;
                default:
                    throw new Exception("Invalid StrokeJoin");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeJoin",
                mode
            );
        }

        protected void StrokeWeight(byte weight)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeWeight",
                weight
            );
        }

        protected void Triangle(
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

        protected void Triangle(
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

        protected void Triangle(Triangle triangle) => Triangle(
            triangle.V1,
            triangle.V2,
            triangle.V3
        );

        protected void Vertex(double x, double y) => Vertex(x, y, 0);
        protected void Vertex(double x, double y, double u, double v) => Vertex(x, y, 0, u, v);
        protected void Vertex(double x, double y, double z)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "vertex",
                x,
                y,
                z
            );
        }
        protected void Vertex(double x, double y, double z, double u, double v)
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

        protected void Vertex(Vector2 position, Vector2? uv = null)
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

        protected void Vertex(Vector3 position, Vector2? uv = null)
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

        protected void Vertex(Vertex vertex) => Vertex(vertex.Position, vertex.UV);
        #endregion

        #endregion
    }
}