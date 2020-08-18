using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;
using System;

namespace ExoKomodo.Helpers.P5
{
    public abstract class P5App : IDisposable
    {
        #region Public

        #region Constructors
        public P5App(IJSRuntime jsRuntime, string containerId)
        {
            if (Instance != null)
            {
                throw new Exception("Only one P5App should exist at once");
            }
            Instance = this;
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
            _p5InvokeFunctionAndReturn,
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
            _p5InvokeFunctionAndReturn,
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
            _p5InvokeFunctionAndReturn,
            "getURL"
        );
        public string UrlPath => _jsRuntime.Invoke<string>(
            _p5InvokeFunctionAndReturn,
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

        #region Static Members
        public static P5App Instance { get; protected set; }
        #endregion

        #region Member Methods
        public void Dispose()
        {
            if (Instance == null)
            {
                return;
            }
            Remove();
            // This is necessary to reset the p5 sketch context
            _jsRuntime.InvokeVoid("location.reload");
            Instance = null;
        }

        [JSInvokable("doubleClicked")]
        public virtual bool DoubleClicked()
        {
            return false; // Event prevent default
        }

        [JSInvokable("draw")]
        public abstract void Draw();

        public DotNetObjectReference<P5App> GetJsInteropReference()
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
            _jsRuntime.InvokeVoid(
                "startP5",
                GetJsInteropReference(),
                _containerId
            );
        }

        [JSInvokable("windowResized")]
        public virtual void WindowResized()
        {
        }

        public void AngleMode(Enums.AngleMode mode)
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

        public void Background(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "background",
                grayscale
            );
        }

        public void Background(Color color)
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

        public void BlendMode(Enums.BlendMode mode)
        {
            var blendMode = "";
            switch (mode)
            {
                case Enums.BlendMode.Add:
                    blendMode = "lighter";
                    break;
                case Enums.BlendMode.Blend:
                    blendMode = "source-over";
                    break;
                case Enums.BlendMode.Burn:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "color-burn";
                    break;
                case Enums.BlendMode.Darkest:
                    blendMode = "darken";
                    break;
                case Enums.BlendMode.Difference:
                    blendMode = "difference";
                    break;
                case Enums.BlendMode.Dodge:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "color-dodge";
                    break;
                case Enums.BlendMode.Exclusion:
                    blendMode = "exclusion";
                    break;
                case Enums.BlendMode.HardLight:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "hard-light";
                    break;
                case Enums.BlendMode.Lightest:
                    blendMode = "lighten";
                    break;
                case Enums.BlendMode.Multiply:
                    blendMode = "multiply";
                    break;
                case Enums.BlendMode.Overlay:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "overlay";
                    break;
                case Enums.BlendMode.Remove:
                    blendMode = "destination-out";
                    break;
                case Enums.BlendMode.Replace:
                    blendMode = "copy";
                    break;
                case Enums.BlendMode.Screen:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "screen";
                    break;
                case Enums.BlendMode.SoftLight:
                    if (IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for WebGL");
                    }
                    blendMode = "soft-light";
                    break;
                case Enums.BlendMode.Subtract:
                    if (!IsWebGL)
                    {
                        throw new Exception("Invalid BlendMode for non-WebGL");
                    }
                    blendMode = "subtract";
                    break;
                default:
                    throw new Exception("Invalid BlendMode");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "blendMode",
                blendMode
            );
        }

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

        public void Clear()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "clear"
            );
        }

        public void ColorMode(Enums.ColorMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "colorMode",
                Models.Color.ToString(mode)
            );
        }

        public void CreateCanvas(uint width, uint height, bool useWebGL = false)
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

        public void Cursor(Enums.CursorMode mode)
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

        public void Cursor(Enums.CursorMode mode, uint x, uint y)
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

        public void Cursor(string mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "cursor",
                mode
            );
        }

        public void Cursor(string mode, uint x, uint y)
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

        public void EllipseMode(Enums.EllipseMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "ellipseMode",
                Models.Ellipse.ToString(mode)
            );
        }

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

        public void Erase(byte strengthFill = 255, byte strengthStroke = 255)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "erase",
                strengthFill,
                strengthStroke
            );
        }

        public void ExitPointerLock()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "exitPointerLock"
            );
        }

        public void Fill(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "fill",
                grayscale
            );
        }

        public void Fill(Color color)
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
        
        public double FrameRate() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "frameRate"
        );

        public void FrameRate(double fps)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "frameRate",
                fps
            );
        }

        public bool Fullscreen() => _jsRuntime.Invoke<bool>(
            _p5InvokeFunctionAndReturn,
            "fullscreen"
        );

        public void Fullscreen(bool isFullscreen)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "fullscreen",
                isFullscreen
            );
        }

        public void Image(Image image) => _jsRuntime.InvokeVoid(
            "p5Instance.imageDotnet",
            image.Id,
            image.X,
            image.Y,
            image.Width,
            image.Height
        );

        public uint ImageHeight(Image image) => _jsRuntime.Invoke<uint>(
            "p5Instance.imageHeightDotnet",
            image.Id
        );

        public void ImageMode(Enums.ImageMode mode)
        {
            var imageMode = "";
            switch (mode)
            {
                case Enums.ImageMode.Center:
                    imageMode = "center";
                    break;
                case Enums.ImageMode.Corner:
                    imageMode = "corner";
                    break;
                case Enums.ImageMode.Corners:
                    imageMode = "corners";
                    break;
                default:
                    throw new Exception("Invalid ImageMode");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "imageMode",
                imageMode
            );
        }

        public uint ImageWidth(Image image) => _jsRuntime.Invoke<uint>(
            "p5Instance.imageWidthDotnet",
            image.Id
        );

        public bool IsKeyDown(uint code) => _jsRuntime.Invoke<bool>(
            _p5InvokeFunctionAndReturn,
            "keyIsDown",
            code
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

        public Font LoadFont(string path) => _jsRuntime.Invoke<Font>(
            "p5Instance.loadFontDotnet",
            path
        );

        public Image LoadImage(string path) => _jsRuntime.Invoke<Image>(
            "p5Instance.loadImageDotnet",
            path
        );

        public void Loop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "loop"
            );
        }

        public void NoCanvas()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noCanvas"
            );
        }

        public void NoCursor()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noCursor"
            );
        }

        public void NoErase()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noErase"
            );
        }

        public void NoFill()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noFill"
            );
        }

        public double Noise(double x) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noise",
            x
        );

        public double Noise(double x, double y) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noise",
            x,
            y
        );

        public double Noise(double x, double y, double z) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noise",
            x,
            y,
            z
        );

        public double Noise(Vector2 dimensions) => Noise(
            dimensions.X,
            dimensions.Y
        );

        public double Noise(Vector3 dimensions) => Noise(
            dimensions.X,
            dimensions.Y,
            dimensions.Z
        );

        public double NoiseDetail(double lod, double falloff) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noiseDetail",
            lod,
            Math.Clamp(falloff, 0, 1)
        );

        public double NoiseSeed(double seed) => _jsRuntime.Invoke<double>(
            _p5InvokeFunction,
            "noiseSeed",
            seed
        );

        public void NoLoop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noLoop"
            );
        }

        public void NoSmooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noSmooth"
            );
        }

        public void NoStroke()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "noStroke"
            );
        }

        public double PixelDensity() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "pixelDensity"
        );

        public void PixelDensity(double density)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "pixelDensity",
                density
            );
        }

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

        public void Pop()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "pop"
            );
        }

        public void Push()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "push"
            );
        }

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

        public void RectangleMode(Enums.RectangleMode mode)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rectMode",
                Models.Rectangle.ToString(mode)
            );
        }

        public void Redraw(uint times = 1)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "redraw",
                times
            );
        }

        public void Remove()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "remove"
            );
        }

        public void RequestPointerLock()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "requestPointerLock"
            );
        }

        public void ResizeCanvas(uint width, uint height, bool noRedraw = false)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "resizeCanvas",
                width,
                height,
                noRedraw
            );
        }

        public void Rotate(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotate",
                angle
            );
        }

        public void RotateX(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateX",
                angle
            );
        }

        public void RotateY(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateY",
                angle
            );
        }

        public void RotateZ(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "rotateZ",
                angle
            );
        }

        public void Save(string savePath)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "save",
                savePath
            );
        }

        public void Save(Image image, string savePath)
        {
            _jsRuntime.InvokeVoid(
                "p5Instance.saveImageDotnet",
                image.Id,
                savePath
            );
        }

        public void SaveJson(object obj, string savePath, bool prettyPrint = true)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "saveJSON",
                obj,
                savePath,
                !prettyPrint
            );
        }

        public void Scale(double[] scales)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "scale",
                scales
            );
        }

        public void SetImageFields(Image image)
        {
            image.Width = ImageWidth(image);
            image.Height = ImageHeight(image);
        }

        public void ShearX(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "shearX",
                angle
            );
        }

        public void ShearY(double angle)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "shearY",
                angle
            );
        }

        public void Smooth()
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "smooth"
            );
        }

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

        public void Stroke(byte grayscale)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "stroke",
                grayscale
            );
        }

        public void Stroke(Color color)
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

        public void StrokeCap(Enums.StrokeCap cap)
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

        public void StrokeJoin(Enums.StrokeJoin join)
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

        public void StrokeWeight(byte weight)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "strokeWeight",
                weight
            );
        }

        public void Text(string text, double x = 0, double y = 0)
        {
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "text",
                text,
                x,
                y
            );
        }

        public void Text(string text, Vector2 position) => Text(
            text,
            position.X,
            position.Y
        );

        public void TextAlign(HorizontalTextAlign align)
        {
            var textAlign = "";
            switch (align)
            {
                case HorizontalTextAlign.Center:
                    textAlign = "center";
                    break;
                case HorizontalTextAlign.Left:
                    textAlign = "left";
                    break;
                case HorizontalTextAlign.Right:
                    textAlign = "right";
                    break;
                default:
                    throw new Exception("Invalid HorizontalTextAlign");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "textAlign",
                textAlign
            );
        }

        public void TextAlign(HorizontalTextAlign horizontalAlign, VerticalTextAlign verticalAlign)
        {
            var horizontalTextAlign = "";
            switch (horizontalAlign)
            {
                case HorizontalTextAlign.Center:
                    horizontalTextAlign = "center";
                    break;
                case HorizontalTextAlign.Left:
                    horizontalTextAlign = "left";
                    break;
                case HorizontalTextAlign.Right:
                    horizontalTextAlign = "right";
                    break;
                default:
                    throw new Exception("Invalid HorizontalTextAlign");
            }
            var verticalTextAlign = "";
            switch (verticalAlign)
            {
                case VerticalTextAlign.Baseline:
                    verticalTextAlign = "alphabetic";
                    break;
                case VerticalTextAlign.Bottom:
                    verticalTextAlign = "bottom";
                    break;
                case VerticalTextAlign.Center:
                    verticalTextAlign = "center";
                    break;
                case VerticalTextAlign.Top:
                    verticalTextAlign = "top";
                    break;
                default:
                    throw new Exception("Invalid VerticalTextAlign");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "textAlign",
                horizontalTextAlign,
                verticalTextAlign
            );
        }

        public double TextAscent() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textAscent"
        );

        public double TextDescent() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textDescent"
        );

        public void TextFont(string font) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textFont",
            font
        );

        public void TextFont(string font, double size) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textFont",
            font,
            size
        );

        public void TextFont(Font font) => _jsRuntime.InvokeVoid(
            "p5Instance.textFontDotnet",
            font.Id
        );

        public void TextFont(Font font, double size) => _jsRuntime.InvokeVoid(
            "p5Instance.textFontDotnet",
            font.Id,
            size
        );

        public double TextLeading() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textLeading"
        );

        public void TextLeading(double leading) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textLeading",
            leading
        );

        public double TextSize() => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textSize"
        );

        public void TextSize(double size) => _jsRuntime.InvokeVoid(
            _p5InvokeFunction,
            "textSize",
            size
        );

        public Enums.TextStyle TextStyle()
        {
            var style = _jsRuntime.Invoke<string>(
                _p5InvokeFunctionAndReturn,
                "textStyle"
            );
            switch (style)
            {
                case "bold":
                    return Enums.TextStyle.Bold;
                case "bold italic":
                    return Enums.TextStyle.BoldItalic;
                case "italic":
                    return Enums.TextStyle.Italic;
                case "normal":
                    return Enums.TextStyle.Normal;
                default:
                    throw new Exception("Invalid TextStyle");
            }
        }

        public void TextStyle(Enums.TextStyle style)
        {
            var textStyle = "";
            switch (style)
            {
                case Enums.TextStyle.Bold:
                    textStyle = "bold";
                    break;
                case Enums.TextStyle.BoldItalic:
                    textStyle = "bold italic";
                    break;
                case Enums.TextStyle.Italic:
                    textStyle = "italic";
                    break;
                case Enums.TextStyle.Normal:
                    textStyle = "normal";
                    break;
                default:
                    throw new Exception("Invalid TextStyle");
            }
            _jsRuntime.InvokeVoid(
                _p5InvokeFunction,
                "textStyle",
                textStyle
            );
        }

        public double TextWidth(string text) => _jsRuntime.Invoke<double>(
            _p5InvokeFunctionAndReturn,
            "textWidth",
            text
        );

        public void Translate(
            double x,
            double y,
            double z = 0
        )
        {
            if (IsWebGL)
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "translate",
                    x,
                    y,
                    z
                );
            }
            else
            {
                _jsRuntime.InvokeVoid(
                    _p5InvokeFunction,
                    "translate",
                    x,
                    y
                );
            }
        }

        public void Translate(Vector2 translation) => Translate(
            translation.X,
            translation.Y,
            0
        );

        public void Translate(Vector3 translation) => Translate(
            translation.X,
            translation.Y,
            translation.Z
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

        #region Protected

        #region Constants
        protected const string _p5InvokeFunction = "p5Instance.invokeP5Function";
        protected const string _p5InvokeFunctionAndReturn = "p5Instance.invokeP5FunctionAndReturn";
        protected const string _p5GetValue = "p5Instance.getValue";
        #endregion

        #region Members
        protected readonly IJSInProcessRuntime _jsRuntime;
        protected readonly string _containerId;
        #endregion

        #endregion
    }
}