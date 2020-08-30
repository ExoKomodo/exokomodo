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
        public Index()
        {
            AppState.Reset();
        }
    }
}