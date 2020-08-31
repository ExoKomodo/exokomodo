using System;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Color
    {
        #region Public

        #region Conastructors
        public Color(byte grayscale, byte alpha = 255)
        {
            Red = grayscale;
            Green = grayscale;
            Blue = grayscale;
            Alpha = alpha;

            Mode = ColorMode.RGB;
        }

        public Color(byte red, byte green, byte blue, byte alpha = 255)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;

            Mode = ColorMode.RGB;
        }

        public Color(byte hue, byte saturation, byte brightness)
        {
            Red = hue;
            Green = saturation;
            Blue = brightness;
            Alpha = 0;

            Mode = ColorMode.HSB;
        }
        #endregion

        #region Members
        public readonly ColorMode Mode { get; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        public byte Hue
        {
            get => Red;
            set => Red = value;
        }
        public byte Saturation
        {
            get => Green;
            set => Green = value;
        }
        public byte Brightness
        {
            get => Blue;
            set => Blue = value;
        }
        #endregion

        #region Static Methods
        public static string ColorModeToString(ColorMode mode) => mode switch
        {
                ColorMode.RGB => "rgb",
                ColorMode.HSB => "hsb",
                _ => throw new Exception("Invalid ColorMode"),
        };
        #endregion

        #endregion
    }
}