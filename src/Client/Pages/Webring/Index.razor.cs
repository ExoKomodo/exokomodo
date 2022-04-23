using Client.Config;
using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages.Webring
{
  public partial class Index
    {
        public bool IsLoading { get; set; }
        [Inject]
        private WebringService _webringService { get; set; }
        private IEnumerable<Page> _webring;

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
                _webring = await _webringService.GetAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unable to retrieve webring:{ex.GetType()}:{ex.Message}:{ex.StackTrace}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}