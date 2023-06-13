using System;
using Client.Models;

namespace Client.Models.Jorson.Blogs
{
    public class Blog<TId> : Model<TId>
    {
        public String Date { get; set; }
        public string Title { get; set; }
        public BlogContent Content { get; set; }
        public bool IsHidden { get; set; }
    }
}