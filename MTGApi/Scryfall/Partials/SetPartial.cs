using MtgApiManager.Lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scryfall.API.Models
{
    public partial class Set
    {
        [NotMapped]
        public int CardCountNotNull { get => CardCount != null ? (int)CardCount : 0; }
        [NotMapped]
        public string SetFullString { get => $"{Name} ({CardCountNotNull})"; }
        [NotMapped]
        public UriImageSource UriImageSource 
        {
            get => new UriImageSource
            {
                CacheValidity = new TimeSpan(1),
                CachingEnabled = true,
                Uri = new Uri(IconSvgUri)
            };
        }
    }
}
