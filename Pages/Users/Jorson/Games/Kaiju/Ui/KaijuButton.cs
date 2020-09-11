using System;
using System.Drawing;
using System.Numerics;
using ExoKomodo.Helpers.BlazingUI.Elements.Buttons;
using ExoKomodo.Helpers.P5;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Ui
{
    public class KaijuButton
        : Button<string>
    {
        #region Public

        #region Constructors
        public KaijuButton(P5App application)
        {
            Application = application;
        }
        #endregion

        #region Members
        public P5App Application { get; private set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public uint BorderWeight { get; set; }
        public Color? BackgroundHoverColor { get; set; }
        public KaijuLabel Label
        {
            get => _label;
            set
            {
                if (ReferenceEquals(Label, value))
                {
                    return;
                }
                if (Label is not null)
                {
                    RemoveChild(Label);
                }
                _label = value;
                AddChild(Label);
            }
        }
        #endregion

        #region Events
        public event EventHandler<KaijuClickEventArgs> OnClick;
        #endregion

        #region Member Methods
        public override void Click() => Click(new KaijuClickEventArgs(this, RenderPosition));

        public void Click(KaijuClickEventArgs args)
        {
            OnClick?.Invoke(this, args);
        }

        public override bool HandleClick(Vector2 clickPosition, bool fallThrough = false)
        {
            if (!Contains(clickPosition))
            {
                return base.HandleClick(clickPosition, fallThrough: fallThrough);
            }
            Click(new KaijuClickEventArgs(this, clickPosition));
            if (fallThrough)
            {
                base.HandleClick(clickPosition, fallThrough: fallThrough);
            }
            return true;
        }

        public override void Render()
        {
            var position = RenderPosition;
            Application.Push();
            if (BorderWeight > 0)
            {
                Application.StrokeWeight(BorderWeight);
                Application.Stroke(BorderColor);
            }
            Application.Fill(
                (IsHovered && BackgroundHoverColor.HasValue)
                    ? BackgroundHoverColor.Value : BackgroundColor
            );
            Application.DrawRectangle(position, Dimensions);
            Application.Pop();

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

    #region Event Args
    public class KaijuClickEventArgs
        : Button<string>.ClickEventArgs<Button<string>>
    {
        #region Public

        #region Constructors
        public KaijuClickEventArgs(KaijuButton button, Vector2 clickPosition)
            : base(button, clickPosition) {}
        #endregion

        #region Members
        public KaijuButton ClickedButton => _clickedButton as KaijuButton;
        #endregion

        #endregion
    }
    #endregion
}
