using Scryfall.API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper.Helpers
{
    public class LegalStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is LegalStatus legalStatus)
            {
                switch (legalStatus)
                {
                    case LegalStatus.Banned: return Microsoft.Maui.Graphics.Colors.Red;
                    case LegalStatus.Restricted: return Microsoft.Maui.Graphics.Colors.GreenYellow;
                    case LegalStatus.Legal: return Microsoft.Maui.Graphics.Colors.Green;
                    case LegalStatus.NotLegal: return Microsoft.Maui.Graphics.Colors.OrangeRed;
                }
            }
            return Microsoft.Maui.Graphics.Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public Color ConvertWithoutParameters(LegalStatus? legalStatus)
        {
            switch (legalStatus)
            {
                case LegalStatus.Banned: return Microsoft.Maui.Graphics.Colors.Red;
                case LegalStatus.Restricted: return Microsoft.Maui.Graphics.Colors.GreenYellow;
                case LegalStatus.Legal: return Microsoft.Maui.Graphics.Colors.Green;
                case LegalStatus.NotLegal: return Microsoft.Maui.Graphics.Colors.OrangeRed;
                default: return Microsoft.Maui.Graphics.Colors.Black;
            }
        }
    }
}
