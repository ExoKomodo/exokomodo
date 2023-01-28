module Core.Helpers.Conversions

let inline toFahrenheit (celsius:double) =
  32.0 + (celsius / 0.5556)
