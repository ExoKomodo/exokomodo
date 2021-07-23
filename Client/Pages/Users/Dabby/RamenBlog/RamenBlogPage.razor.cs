using Client.Config;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Client.Models.Dabby;
using Client.Pages.Users.Jorson.Helpers;
using Client.Pages.Users.Jorson;

namespace Client.Pages.Users.Dabby.RamenBlog
{
    internal class RamenBlogPageBase : PageBase {}

    public partial class RamenBlogPage : IDisposable
    {
        #region Public

        #region Constructors
        public RamenBlogPage()
        {
            _base = new RamenBlogPageBase();
        }
        #endregion

        #region Members
        [Parameter]
        public int Id { get; set; }
        #endregion

        #endregion

        #region Protected

        #region Member Methods
        
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                _base.Initialize();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            _blog = await _db.GetByIdAsync(Id);
            if (_blog is null)
            {
                _navigation.NavigateTo("/users/dabby/ramen-blog");
            }
            _blog.Id = Id;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Blog _blog { get; set; }
        [Inject]
        private JsonDb<int, Blog> _db { get; set; }
        private bool _isDisposed { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
        #endregion

        #endregion

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing)
            {
                return;
            }
            _base.Dispose();
        }
        #endregion
    }
}