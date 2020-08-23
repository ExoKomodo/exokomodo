using ExoKomodo.Models.Jorson;
using ExoKomodo.Pages.Users.Jorson.Helpers;
using System.Net.Http;

namespace ExoKomodo.Pages.Users.Jorson.Blogs
{
    public class BlogDb : JsonDb<int, Blog>
    {
        #region Public

        #region Constructors
        public BlogDb(HttpClient http) : base(http)
        {
            BaseUrl = "https://api.npoint.io/ebf93ec56fb637e88982/blogs";
        }
        #endregion

        #endregion
    }
}
