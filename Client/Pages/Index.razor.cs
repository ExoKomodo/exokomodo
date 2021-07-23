using Client.Config;
using Client.Http;
using Client.Models;
using Microsoft.AspNetCore.Components;
using Client.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;

namespace Client.Pages
{
    public partial class Index
    {
        [Inject]
        private ApiClient _httpApi { get; set; }
        protected WeatherForecast _weatherGuess { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                AppState.Reset();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await GuessWeather();
        }

        protected async Task GuessWeather()
        {
            _weatherGuess = await _httpApi.Client.GetFromJsonAsync<WeatherForecast>("WeatherForecast");
        }
    }
}