using ExoKomodo.Helpers.P5;
using ExoKomodo.Helpers.P5.Models;
using System.Numerics;

namespace ExoKomodo.Pages.Users.Jorson.Games.CorporationTycoon
{
    public abstract class Building
    {
        #region Public

        #region Members
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public uint StrokeWeight { get; set; } = 0;

        public Vector2 Position
        {
            get => _rect.Position;
            set
            {
                _rect.Position = value;
            }
        }

        public uint Width
        {
            get => (uint)_rect.Width;
            set
            {
                _rect.Width = value == 0 ? 1 : value;
            }
        }
        #endregion

        #region Member Methods
        public abstract void Draw(P5App application);

        public abstract void Update(P5App application, double dt);
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Building(
            Vector2 position,
            Color fillColor,
            Color strokeColor,
            uint strokeWeight,
            uint width
        )
        {
            _rect = new Rectangle(
                position,
                new Vector2(width, 1)
            );
            FillColor = fillColor;
            StrokeColor = strokeColor;
            StrokeWeight = strokeWeight;
        }
        #endregion

        #region Members
        protected Rectangle _rect;
        #endregion

        #endregion
    }
}
