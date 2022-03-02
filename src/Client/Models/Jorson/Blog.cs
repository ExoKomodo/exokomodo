using System;
using Client.Models;

namespace Client.Models.Jorson
{
    public class Blog<TId> : Model<TId>
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public BlogContent Content { get; set; }
    }
}