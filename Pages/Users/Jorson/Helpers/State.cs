using System;
using System.Collections.Generic;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class State<TId>
        where TId : IEquatable<TId>
    {
        public StateInfo<TId> Info { get; set; }
        public IList<TId> NextStates { get; set; }
    }
}