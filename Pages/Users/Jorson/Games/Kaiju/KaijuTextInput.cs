using System.Drawing;
using System.Numerics;
using ExoKomodo.Enums;
using ExoKomodo.Helpers.BlazingUI.Elements.Inputs;
using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public class KaijuTextInput
        : TextInput<string>
    {
        #region Public

        #region Constructors
        public KaijuTextInput(P5App application)
        {
            Application = application;
            _label = new KaijuLabel(Application)
            {
                HorizontalAlign = HorizontalTextAlign.Left,
            };
            AddChild(_label);
        }
        #endregion

        #region Members
        public P5App Application { get; private set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor
        {
            get => _label.TextColor;
            set
            {
                if (_label is null)
                {
                    return;
                }
                _label.TextColor = value;
            }
        }
        public override string Value
        {
            get => _label.Text;
            protected set
            {
                if (_label is null)
                {
                    return;
                }
                _label.Text = value;
            }  
        }
        #endregion

        #region Member Methods
        public override bool HandleClick(Vector2 clickPosition, bool fallThrough = false)
        {
            IsFocused = Contains(clickPosition);
            return base.HandleClick(clickPosition, fallThrough);
        }

        public override void HandleInput(KeyCodes value)
        {
            if (!IsFocused)
            {
                return;
            }
            base.HandleInput(value);
        }

        public override void Render()
        {
            var position = RenderPosition;
            
            Application.Push();
            Application.Fill(BackgroundColor);
            Application.DrawRectangle(position, Dimensions);
            Application.Pop();

            _label.Offset = new Vector2(Width / 20f, Height / 2f);

            base.Render();
        }
        #endregion

        #endregion

        #region Protected

        #region Members
        protected KaijuLabel _label { get; set; }
        #endregion

        #endregion
    }
}
