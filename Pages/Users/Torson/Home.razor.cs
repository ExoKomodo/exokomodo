
using ExoKomodo.Models;
using ExoKomodo.Config;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Torson
{
    public partial class Home
    {
        [Inject]
        private HttpClient _http { get; set; }
        private const string UserId = "torson";
        private User _self;

        protected override async Task OnInitializedAsync()
        {
            AppState.IsSideNavHidden = true;
            _self = (await _http.GetFromJsonAsync<List<User>>("data/users.json")).Where(user => user.Id == UserId).FirstOrDefault();
            if (_self is null)
            {
                throw new Exception($"Could not find user {UserId}");
            }
        }

        int DaysSince(DateTime startDate){
            return (System.DateTime.Now - startDate).Days;
        }
    }
}