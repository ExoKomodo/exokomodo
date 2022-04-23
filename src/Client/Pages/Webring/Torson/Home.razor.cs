using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Client.Pages.Webring.Torson
{
  public partial class Home
    {
        [Inject]
        private WebringService _webringService { get; set; }
        private const string UserId = "torson";
        private Page _self;

        protected override async Task OnInitializedAsync()
        {
            _self = await _webringService.GetByIdAsync(UserId);
            if (_self is null)
            {
                throw new Exception($"Could not find user {UserId}");
            }
        }
    }
}