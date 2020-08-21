using System;

namespace ExoKomodo.Models.Jorson
{
    public class Blog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public BlogContent Content { get; set; }
    }
}