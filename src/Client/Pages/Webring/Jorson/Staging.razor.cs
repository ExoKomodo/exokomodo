using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Client.Http;

namespace Client.Pages.Webring.Jorson
{
  public partial class Staging
    {
        [Parameter]
        public int Id { get; set; }
        public bool IsLoading { get; set; }
        public const string UserId = "jorson";

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            try
            {
                _loadedPage = await _localClient.Client.GetStringAsync("data/jorson/staging/index.html");
            }
            finally
            {
                IsLoading = false;
            }
        }
    
        private string _loadedPage { get; set; }
        [Inject]
        private LocalClient _localClient { get; set; }
        [Inject]
        private NavigationManager _navigation { get; set; }
        private PageBase _base { get; set; }
    }
}
