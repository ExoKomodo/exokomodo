using ExoKomodo.Config;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ExoKomodo.Models.Jorson;

namespace ExoKomodo.Pages.Users.Jorson.Blogs
{
    internal class BlogPageBase : PageBase {}

    public partial class BlogPage : IDisposable
    {
        #region Public

        #region Constructors
        public BlogPage()
        {
            _base = new BlogPageBase();
            _base.Initialize();
        }
        #endregion

        #region Members
        [Parameter]
        public int Id { get; set; }
        #endregion

        #region Member Methods
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            _base.Dispose();

            GC.SuppressFinalize(this);
            _isDisposed = true;
        }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        protected override void OnInitialized()
        {
            AppState.IsSideNavHidden = true;
        }

        protected override async Task OnInitializedAsync()
        {
            var blogs = (await _http.GetFromJsonAsync<SiteData>("https://api.npoint.io/ebf93ec56fb637e88982"))?.Blogs;
            _blog = blogs.FirstOrDefault(blog => blog.Id == Id);
            if (_blog == null)
            {
                _navigation.NavigateTo("/users/jorson/blogs");
            }
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Blog _blog { get; set; }
        [Inject]
        private HttpClient _http { get; set; }
        private bool _isDisposed { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion
    }
}