namespace ExoKomodo.Models.Jorson
{
    public abstract class JsonDbModel<TId>
    {
        #region Public

        #region Members
        public TId Id { get; set; }
        #endregion

        #endregion
    }
}
