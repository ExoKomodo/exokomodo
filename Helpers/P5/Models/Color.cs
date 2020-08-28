using System;
using ExoKomodo.Helpers.P5.Enums;

namespace ExoKomodo.Helpers.P5.Models
{
    public struct Color
    {
        #region Public

        #region Conastructors
        public Color(byte red = 0, byte green = 0, byte blue = 0, byte alpha = 255)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;

            Mode = ColorMode.RGB;
        }

        public Color(byte hue = 0, byte saturation = 0, byte brightness = 0)
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
        public static string ToString(ColorMode mode)
        {
            switch (mode)
            {
                case ColorMode.RGB:
                    return "rgb";
                case ColorMode.HSB:
                    return "hsb";
                default:
                    throw new Exception("Invalid ColorMode");
            }
        }
        #endregion

        #endregion
    }
}