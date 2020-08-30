using ExoKomodo.Config;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users
{
    public partial class Index
    {
        [Inject]
        private HttpClient _http { get; set; }
        private IList<User> _users;

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                AppState.Reset();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            _users = await _http.GetFromJsonAsync<List<User>>("data/users.json");
        }
    }
}