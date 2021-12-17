using System;
using Client.Models;

namespace Client.Models.Jorson
{
    public class Blog : Model<int>
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public BlogContent Content { get; set; }
    }
}