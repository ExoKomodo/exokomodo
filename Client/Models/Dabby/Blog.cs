using System;
using Client.Models.Jorson;

namespace Client.Models.Dabby
{
    public class Blog : JsonDbModel<int>
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public BlogContent Content { get; set; }
    }
}