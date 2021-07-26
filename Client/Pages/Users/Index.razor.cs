using Client.Config;
using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages.Users
{
  public partial class Index
    {
        public bool IsLoading { get; set; }
        [Inject]
        private UserService _userService { get; set; }
        private IEnumerable<User> _users;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                AppState.Reset();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            try
            {
                _users = await _userService.GetAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unable to retrieve users:{ex.GetType()}:{ex.Message}:{ex.StackTrace}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}