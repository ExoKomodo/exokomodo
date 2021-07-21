// using System.Collections.Generic;
// using System.Drawing;
// using System.Numerics;
// using ExoKomodo.Enums;
// using ExoKomodo.Helpers.BlazingUI.Elements.Containers;
// using ExoKomodo.Helpers.BlazingUI.Enums;
// using ExoKomodo.Helpers.P5.Enums;

// namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Ui
// {
//     public class MainMenu : Scene
//     {
//         #region Public

//         #region Constructors
//         public MainMenu(KaijuApp application)
//             : base(application) {}
//         #endregion

//         #region Members
//         public override float Height
//         {
//             get => _container.Height;
//             set => _container.Height = value;
//         }
//         public override ISet<GameStates> ActiveStates { get; protected set; }
//             = new HashSet<GameStates>
//             {
//                 GameStates.MainMenu,
//             };
//         public override float Width
//         {
//             get => _container.Width;
//             set => _container.Width = value;
//         }
//         #endregion

//         #region Member Methods
//         public override void Draw()
//         {
//             Application.Background(Color.Black);
//             _startButton.IsHovered = _startButton.IsHovered || _isStartButtonHovered;
//             _tree?.Render();
//         }

//         public override bool HandleClick(Vector2 clickPosition, bool fallThrough = false)
//             => _tree is null ? false : _tree.HandleClick(clickPosition, fallThrough: fallThrough);
        
//         public override void HandleHover(Vector2 mousePosition)
//             => _tree?.HandleHover(mousePosition);

//         public override void HandleInputDown(KeyCodes code)
//         {
//             switch (code)
//             {
//                 case KeyCodes.Enter:
//                     _isStartButtonHovered = true;
//                     break;
//             }
//         }

//         public override void HandleInputUp(KeyCodes code)
//         {
//             switch (code)
//             {
//                 case KeyCodes.Enter:
//                     _isStartButtonHovered = false;
//                     _startButton.Click();
//                     break;
//             }
//         }

//         public override void Setup(float width, float height)
//         {
//             SetupTree();
//             AddContainer();
//             SetUiScale(width, height);
//             AddTitle();
//             AddButtons();
//             AddFooter();
//         }

//         public override void SetUiScale(float width, float height)
//         {
//             Width = width;
//             Height = height;
//         }

//         public override void Update() {}
//         #endregion

//         #endregion

//         #region Private

//         #region Members
//         private Container<string> _container { get; set; }
//         private bool _isStartButtonHovered { get; set; }
//         private KaijuButton _startButton { get; set; }
//         private KaijuElementTree _tree { get; set; }
//         #endregion

//         #region Member Methods
//         private void AddButtons()
//         {
//             var width = Width / 8f;
//             var dimensions = new Vector2(width, width * (1f / 3f));
//             _startButton = new KaijuButton(Application)
//             {
//                 BackgroundColor = Color.Black,
//                 BackgroundHoverColor = Color.DarkSlateGray,
//                 Dimensions = dimensions,
//                 Offset = Vector2.Zero,
//                 BorderColor = Color.White,
//                 BorderWeight = 2,
//                 Label = new KaijuLabel(Application)
//                 {
//                     FontSize = 24f,
//                     Offset = dimensions / 2f,
//                     Text = "Start",
//                     TextColor = Color.White,
//                 },
//             };
//             _startButton.OnClick += (sender, args)
//                 => {
//                     Application.GameState = GameStates.World;
//                     _startButton.IsHovered = false;
//                 };
//             _container.AddChild(_startButton);
//         }
        
//         private void AddContainer()
//         {
//             _container = new HorizontalContainer<string>()
//             {
//                 Alignment = LayoutAlign.Center,
//                 Offset = Vector2.Zero,
//             };
//             _tree.Root.AddChild(_container);
//         }

//         private void AddFooter()
//         {
//             var footer = new KaijuLabel(Application)
//             {
//                 FontSize = 12f,
//                 Offset = new Vector2(Width / 2f, Height * (19f / 20f)),
//                 Text = "Made by James Orson",
//                 TextColor = Color.White,
//                 HorizontalAlign = HorizontalTextAlign.Center,
//                 VerticalAlign = VerticalTextAlign.Center,
//             };
//             _tree.Root.AddChild(footer);
//         }

//         private void AddTitle()
//         {
//             var title = new KaijuLabel(Application)
//             {
//                 FontSize = 64f,
//                 Offset = new Vector2(Width / 2f, Height / 8f),
//                 Text = "Kaiju",
//                 TextColor = Color.White,
//                 HorizontalAlign = HorizontalTextAlign.Center,
//                 VerticalAlign = VerticalTextAlign.Center,
//             };
//             _tree.Root.AddChild(title);
//         }

//         private void SetupTree()
//         {
//             _tree = new KaijuElementTree();
//         }
//         #endregion

//         #endregion
//     }
// }