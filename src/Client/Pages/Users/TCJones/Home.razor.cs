using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Client.Pages.Users.TCJones
{
  public partial class Home
    {
        [Inject]
        private UserService _userService { get; set; }
        private const string UserId = "tcjones";
        private User _self;

        protected override async Task OnInitializedAsync()
        {
            _self = await _userService.GetByIdAsync(UserId);
            if (_self is null)
            {
                throw new Exception($"Could not find user {UserId}");
            }
        }
    }
}