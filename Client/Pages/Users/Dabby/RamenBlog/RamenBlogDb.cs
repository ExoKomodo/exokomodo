using Client.Models.Dabby;
using Client.Pages.Users.Jorson.Helpers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Pages.Users.Dabby.RamenBlog
{
    public class RamenBlogDb : JsonDb<int, Blog>
    {
        #region Public

        #region Constructors
        public RamenBlogDb(HttpClient http) : base(http)
        {
            BaseUrl = "data/dabby/blogs/ramenBlogs.json";
        }
        #endregion

        #region Member Methods
        public override async Task<Blog> GetByIdAsync(int id)
        {
            var objs = await GetAllAsync();
            if (objs is null || objs.Count <= id || id < 0)
            {
                return null;
            }
            return objs[id];
        }
        #endregion

        #endregion
    }
}
