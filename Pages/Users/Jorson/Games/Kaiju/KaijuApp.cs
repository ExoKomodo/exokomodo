using ExoKomodo.Helpers.BlazingUI.Elements;
using ExoKomodo.Helpers.BlazingUI.Enums;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using Microsoft.JSInterop;
using System;
using System.Drawing;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class KaijuApp : P5App
    {
        #region Public

        #region Constructors
        public KaijuApp(IJSRuntime jsRuntime, string containerId)
            : base(jsRuntime, containerId) {}
        #endregion

        #region Members
        #endregion

        #region Member Methods
        [JSInvokable("draw")]
        public override void Draw()
        {
            Background(0);

            _tree.Render();
            DrawCenterLines();
        }

        [JSInvokable("mouseClicked")]
        public override bool MouseClicked()
        {
            _tree.HandleClick(MousePosition);
            return true; // Event prevent default
        }

        [JSInvokable("mouseMoved")]
        public override bool MouseMoved()
        {
            _tree.HandleHover(MousePosition);
            return true; // Event prevent default
        }

        [JSInvokable("preload")]
        public override void Preload()
        {
        }

        public void Reset()
        {
        }

        [JSInvokable("setup")]
        public override void Setup()
        {
            _clearColor = Color.FromArgb(red: 200, green: 200, blue: 200);
            InitializeCanvas();
            Reset();
            SetupUi();
        }

        [JSInvokable("windowResized")]
        public override void WindowResized()
        {
            QueryWindow();
            SetUiScale();
            ResizeCanvas((uint)_width, (uint)_height);
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private KaijuButton _button { get; set; }
        private Camera _camera { get; set; }
        private Container<string> _container { get; set; }
        private float _delta { get; set; } = 0.01f;
        private Color _clearColor { get; set; }
        private float _height { get; set; }
        private Shader _mandelbrot { get; set; }
        private Model3D _teapot { get; set; }
        private KaijuElementTree _tree { get; set; }
        private float _width { get; set; }
        #endregion

        #region Member Methods
        private void ButtonClickTest(object sender, KaijuClickEventArgs args)
        {
            var button = args.ClickedButton;
            Console.WriteLine(
                $"Clicked '{button.GetType()}' from '{GetType()}' at {args.ClickPosition} with text '{button.Label.Text}'"
            );
        }

        private void DrawCenterLines()
        {
            Push();
            Stroke(Color.Red);
            StrokeWeight(1);
            DrawLine(
                new Vector2(0f, _height / 2f),
                new Vector2(_width, _height / 2f)
            );
            DrawLine(
                new Vector2(_width / 2f, 0f),
                new Vector2(_width / 2f, _height)
            );
            Pop();
        }

        private void DrawTeapot()
        {
            var frames = FrameCount;
            Push();
            Scale(0.4f);
            RotateX(frames * 0.01f);
            RotateY(frames * 0.01f);
            NormalMaterial();
            DrawModel(_teapot);
            Pop();
        }

        private void InitializeCanvas()
        {
            QueryWindow();
            CreateCanvas((uint)_width, (uint)_height, useWebGl: false);
        }

        private void QueryWindow()
        {
            bool isVerticalDisplay = WindowWidth / WindowHeight < 1;
            float aspectRatio = isVerticalDisplay ? 4f / 3f : 16f / 9f;
            _width = WindowWidth * 0.75f;
            _height = _width / aspectRatio;
        }

        private void SetUiScale()
        {
            if (_container is null)
            {
                return;
            }
            _container.Width = _width;
            _container.Height = _height;
        }

        private void SetupUi()
        {
            _tree = new KaijuElementTree();
            _container = new HorizontalContainer<string>()
            {
                Alignment = LayoutAlign.Center,
                Offset = Vector2.Zero,
            };
            for (int i = 0; i < 3; i++)
            {
                var dimensions = new Vector2(50f, 50f);
                var button = new KaijuButton(this)
                {
                    BackgroundColor = Color.MediumAquamarine,
                    Dimensions = dimensions,
                    Offset = Vector2.Zero,
                    Label = new KaijuLabel(this)
                    {
                        Offset = dimensions / 2f,
                        Text = $"Test {i}",
                        TextColor = Color.Black,
                    },
                };
                button.OnClick += (sender, args)
                    => ButtonClickTest(sender, args);
                button.OnHoverEnter += (element, args)
                    => {
                        var hoveredButton = (element as KaijuButton);
                        Console.WriteLine(
                            $"Hover enter button with text '{hoveredButton?.Label.Text}'. Hover state: {hoveredButton?.IsHovered}"
                        );
                        hoveredButton.BackgroundColor = Color.Aqua;
                    };
                button.OnHoverExit += (element, args)
                    => {
                        var hoveredButton = (element as KaijuButton);
                        Console.WriteLine(
                            $"Hover exit button with text '{hoveredButton?.Label.Text}'. Hover state: {hoveredButton?.IsHovered}"
                        );
                        hoveredButton.BackgroundColor = Color.MediumAquamarine;
                    };
                _container.AddChild(button);
            }
            _tree.Root.AddChild(_container);

            SetUiScale();
        }
        #endregion

        #endregion
    }
}