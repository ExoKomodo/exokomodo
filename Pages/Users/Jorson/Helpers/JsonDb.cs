using ExoKomodo.Models.Jorson;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public abstract class JsonDb<TId, T> where T : JsonDbModel<TId>
    {
        #region Public

        #region Members
        public string BaseUrl { get; protected set; }
        #endregion

        #region Member Methods
        public async Task<IList<T>> GetAllAsync() => await _http.GetFromJsonAsync<List<T>>($"{BaseUrl}");

        public async Task<T> GetByIdAsync(TId id) => await _http.GetFromJsonAsync<T>($"{BaseUrl}/{id}");
        #endregion

        #endregion

        #region Protected

        #region Constructors
        protected JsonDb(HttpClient http)
        {
            _http = http;
        }
        #endregion

        #region Members
        protected readonly HttpClient _http;
        #endregion

        #endregion
    }
}
