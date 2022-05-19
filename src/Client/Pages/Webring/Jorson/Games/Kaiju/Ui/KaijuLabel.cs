using System.Drawing;
using Client.Helpers.BlazingUI.Elements.Labels;
using Client.Helpers.P5;
using Client.Helpers.P5.Enums;

namespace Client.Pages.Webring.Jorson.Games.Kaiju.Ui
{
    public class KaijuLabel
        : Label<string>
    {
        #region Public

        #region Constructors
        public KaijuLabel(P5App application)
            : base()
        {
            Application = application;
            FontSize = 12;
        }
        #endregion

        #region Members
        public P5App Application { get; private set; }
        public HorizontalTextAlign HorizontalAlign { get; set; } = HorizontalTextAlign.Center;
        public Color TextColor { get; set; }
        public VerticalTextAlign VerticalAlign { get; set; } = VerticalTextAlign.Center;
        #endregion

        #region Member Methods
        public override void Render()
        {
            var position = RenderPosition;
            Application.Push();
            Application.Fill(TextColor);
            Application.SetTextSize(FontSize);
            Application.SetTextAlign(HorizontalAlign, VerticalAlign);
            Application.DrawText(Text, RenderPosition);
            Application.Pop();

            base.Render();
        }
        #endregion

        #endregion
    }
}
