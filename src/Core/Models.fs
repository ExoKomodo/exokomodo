module Core.Models

open Core.Helpers
open System

type WeatherForecast =
    { Date: DateTime
      Summary: string
      TemperatureC: double}

      member this.TemperatureF() = Conversions.toFahrenheit this.TemperatureC
