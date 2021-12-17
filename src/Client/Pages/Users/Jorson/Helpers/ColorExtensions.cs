using System.Drawing;

namespace Client.Pages.Users.Jorson.Helpers
{
    public static class ColorExtensions
    {
        public static Color Lerp(this Color from, Color to, float value)
        {
            var diff = (1f - value);
            var a = from.A * diff + to.A * value;
            var r = from.R * diff + to.R * value;
            var g = from.G * diff + to.G * value;
            var b = from.B * diff + to.B * value;
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }
    }
}
