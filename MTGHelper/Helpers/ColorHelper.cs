using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Helpers
{
    public class ColorHelper
    {
        public static Color MixColors(params Color[] colors)
        {
            double totalR = 0, totalG = 0, totalB = 0;

            foreach (var color in colors)
            {
                totalR += color.Red;
                totalG += color.Green;
                totalB += color.Blue;
            }

            double mixedR = totalR / colors.Length;
            double mixedG = totalG / colors.Length;
            double mixedB = totalB / colors.Length;

            return Color.FromRgba(mixedR, mixedG, mixedB, 1.0);
        }
    }
}
