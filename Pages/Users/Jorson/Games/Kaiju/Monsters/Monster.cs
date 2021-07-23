using ExoKomodo.Helpers.P5.Models;
using ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Planets;

namespace ExoKomodo.Pages.Users.Jorson.Games.Kaiju.Monsters
{
    public abstract class Monster
    {
        #region Public

        #region Members
        public KaijuApp Application { get; protected set; }
        public abstract float BaseVelocity { get; }
        public Planet CurrentPlanet { get; set; }
        public float EdgePoint { get; set; }
        #endregion

        #region Member Methods
        public abstract void Draw(float baseRotation = 0f, bool isFocused = false);

        public virtual void Move(float distance)
        {
            _queuedMovement += distance;
        }

        public virtual void Update()
        {
            _delta = Application.DeltaTime * 0.001f;

            PerformMove();
        }
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected Monster(KaijuApp application)
        {
            Application = application;

            _body = new Rect();
        }
        #endregion

        #region Members
        protected Rect _body;
        protected float _delta;
        protected float _queuedMovement;
        #endregion

        #region Member Methods
        protected virtual void PerformMove()
        {
            if (_queuedMovement != 0f)
            {
                EdgePoint += _queuedMovement * _delta;
                _queuedMovement = 0f;
            }
        }
        #endregion

        #endregion
    }
}
