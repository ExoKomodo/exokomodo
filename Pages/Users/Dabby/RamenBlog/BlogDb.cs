using ExoKomodo.Models.Dabby;
using ExoKomodo.Pages.Users.Jorson.Helpers;
using System.Net.Http;

namespace ExoKomodo.Pages.Users.Dabby.RamenBlog
{
    public class BlogDb : JsonDb<int, Blog>
    {
        #region Public

        #region Constructors
        public BlogDb(HttpClient http) : base(http)
        {
            BaseUrl = "https://api.npoint.io/6735cf9c87e2f9bc81c0/ramenBlogs";
        }
        #endregion

        #endregion
    }
}
