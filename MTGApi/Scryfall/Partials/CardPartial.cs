using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scryfall.API.Models
{
    public partial class Card
    {
        [NotMapped]
        public ImageSource CardImageSource 
        { 
            get=> new UriImageSource()
            {
                Uri = new Uri(this.ImageUris.Png),
                CacheValidity = new TimeSpan(1),
                CachingEnabled = true,
            }; 
        }
    }
}
