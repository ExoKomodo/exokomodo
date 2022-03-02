using System.Collections.Generic;

namespace Client.Models.Jorson
{
    public class SiteData
    {
        public IList<Blog<int>> Blogs { get; set; }
    }
}