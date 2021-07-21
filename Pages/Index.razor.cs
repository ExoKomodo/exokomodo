using ExoKomodo.Config;
using ExoKomodo.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExoKomodo.Pages
{
    public partial class Index
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                await base.InvokeAsync(AppState.Reset);
            }
        }
    }
}