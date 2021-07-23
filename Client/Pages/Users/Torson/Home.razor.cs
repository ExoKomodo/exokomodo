
using Client.Http;
using Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Pages.Users.Torson
{
    public partial class Home
    {
        [Inject]
        private LocalClient _httpLocal { get; set; }
        private const string UserId = "torson";
        private User _self;

        protected override async Task OnInitializedAsync()
        {
            _self = (await _httpLocal.Client.GetFromJsonAsync<List<User>>("data/users.json")).Where(user => user.Id == UserId).FirstOrDefault();
            if (_self is null)
            {
                throw new Exception($"Could not find user {UserId}");
            }
        }
    }
}