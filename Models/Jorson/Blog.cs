using System;

namespace ExoKomodo.Models.Jorson
{
    public class Blog : JsonDbModel<int>
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public BlogContent Content { get; set; }
    }
}