using System;

namespace Client.Pages.Webring.Jorson.Helpers
{
    public class StateInfo<TId>
        where TId : IEquatable<TId>
    {
        #region Public

        #region Members
        public TId Id { get; set; }
        #endregion

        #region Member Methods
        public override int GetHashCode() => Id.GetHashCode();
        #endregion

        #endregion

        #region Operator Overloads
        public static bool operator ==(StateInfo<TId> left, StateInfo<TId> right) => left.Equals(right);
        public static bool operator !=(StateInfo<TId> left, StateInfo<TId> right) => !(left == right);
        public static bool operator ==(StateInfo<TId> left, TId right) => left.Equals(right);
        public static bool operator !=(StateInfo<TId> left, TId right) => !(left == right);
        public static bool operator ==(TId left, StateInfo<TId> right) => right.Equals(left);
        public static bool operator !=(TId left, StateInfo<TId> right) => !(right == left);
        #endregion

        #region IEquatable Support
        public override bool Equals(object obj) => (obj is StateInfo<TId> other) ? this.Equals(other) : false;

        public bool Equals(StateInfo<TId> other) => Equals(other.Id);
        public bool Equals(TId otherId) => Id.Equals(otherId);
        #endregion
    }
}