using Microsoft.JSInterop;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Helpers.P5;

namespace ExoKomodo.Pages.Users.Jorson
{
    public partial class Home : IDisposable
    {
        #region Public

        #region Constructors
        public Home()
        {
            _pageBase = new HomePageBase();
            _pageBase.Initialize();
        }
        #endregion

        #region Constants
        public const string UserId = "jorson";
        #endregion

        #region Member Methods
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            _pageBase.Dispose();

            GC.SuppressFinalize(this);
            _isDisposed = true;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override async Task OnInitializedAsync()
        {
            _self = (await _http.GetFromJsonAsync<List<User>>("data/users.json")).Where(user => user.Id == UserId).FirstOrDefault();
            if (_self == null)
            {
                throw new Exception($"Could not find user {UserId}");
            }

            _application = new HomeP5Application(_jsRuntime);
            _application.Start();
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private HomeP5Application _application { get; set; }
        [Inject]
        private HttpClient _http { get; set; }
        private bool _isDisposed { get; set; }
        [Inject]
        private IJSRuntime _jsRuntime { get; set; }
        private PageBase _pageBase { get; set; }
        private User _self;
        #endregion

        #region Classes

        private class HomePageBase : PageBase
        {
            #region Public

            #region Member Methods
            public override void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
            #endregion

            #endregion
        }

        private class HomeP5Application : P5Application
        {
            #region Public

            #region Constructors
            public HomeP5Application(IJSRuntime jsRuntime) : base(jsRuntime, "p5-container")
            {
            }
            #endregion

            #region Members
            public Color ClearColor { get; set; }
            public Image Img { get; set; }
            #endregion

            #region Member Methods
            [JSInvokable("draw")]
            public override void Draw()
            {
                Background(new Color(150, 250, 150));
                Fill(new Color(100, 100, 250));
                Rectangle(20, 20, 60, 60);
                StrokeWeight(5);
                Erase(150, 255);
                Triangle(
                    new Triangle(
                        new Vector2(50, 10),
                        new Vector2(70, 50),
                        new Vector2(90, 10)
                    )
                );
                NoErase();
                
                Push();
                ImageMode(Helpers.P5.Enums.ImageMode.Center);
                Translate(MouseX, MouseY);
                Scale(new double[] {0.5, 0.5, 0.5});
                Rotate(PI / 4d);
                Console.WriteLine($"{MouseX} {MouseY}");
                Image(Img);
                Pop();
            }

            [JSInvokable("preload")]
            public override void Preload()
            {
                Img = LoadImage("assets/jorson/knuckles.jpg");
            }

            [JSInvokable("setup")]
            public override void Setup()
            {
                ClearColor = new Color(hue: 0, saturation: 255, brightness: 255);
                CreateCanvas(800, 800);
                SetImageFields(Img);
            }
            #endregion

            #endregion
        }

        #endregion

        #endregion
    }
}