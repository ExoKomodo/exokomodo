using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using ExoKomodo.Enums;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju
{
    public abstract class Scene
    {
        #region Public

        #region Members
        public abstract ISet<GameStates> ActiveStates { get; protected set; }
        public KaijuApp Application { get; protected set; }
        public virtual float Height { get; set; }
        public virtual float Width { get; set; }
        #endregion

        #region Member Methods
        public abstract void Draw();

        public virtual bool HandleClick(Vector2 clickPosition, bool fallThrough = false)
            => true;
        
        public virtual void HandleHover(Vector2 mousePosition) {}

        public virtual void HandleInputDown(KeyCodes code) {}

        public virtual void HandleInputUp(KeyCodes code) { }

        public virtual void SetUiScale(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public abstract void Setup(float width, float height);

        public abstract void Update();
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Scene(KaijuApp application)
        {
            Application = application;
        }
        #endregion

        #endregion
    }
}