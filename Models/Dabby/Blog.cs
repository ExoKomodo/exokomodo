using System;
using ExoKomodo.Models.Jorson;

namespace ExoKomodo.Models.Dabby
{
    public class Blog : JsonDbModel<int>
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public BlogContent Content { get; set; }
    }
}