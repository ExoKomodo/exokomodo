using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Client.Models.Jorson;
using Client.Services.Jorson;

namespace Client.Pages.Users.Jorson.Blogs
{
  internal class BlogPageBase : PageBase {}

    public partial class BlogPage : IDisposable
    {
        #region Public

        #region Constructors
        public BlogPage()
        {
            _base = new BlogPageBase();
        }
        #endregion

        #region Members
        [Parameter]
        public int Id { get; set; }
        #endregion

        #region Constants
        public const string UserId = "jorson";
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
            _blogService.UserId = UserId;
            _blog = await _blogService.GetByIdAsync(Id);
            if (_blog is null)
            {
                _navigation.NavigateTo($"/users/{UserId}/blogs");
            }
            _blog.Id = Id;
        }
        #endregion

        #endregion

        #region Private

        #region Members
        private Blog _blog { get; set; }
        [Inject]
        private BlogService _blogService { get; set; }
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
