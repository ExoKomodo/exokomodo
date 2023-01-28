module Core.Services.Weather

open Core.Models
open System.Net.Http
open System.Net.Http.Json


[<Literal>]
let baseUrl =
#if DEBUG
  "https://localhost:5001/api/"
#else
  "https://services.exokomodo.com/api/"
#endif

let getForecastTask (client:HttpClient) =
  client.GetFromJsonAsync<WeatherForecast>($"{baseUrl}/WeatherForecast")

let getForecastAsync (client:HttpClient) =
  async {
    return! getForecastTask client |> Async.AwaitTask
  }

let getForecast (client:HttpClient) =
  (getForecastTask client).Result
