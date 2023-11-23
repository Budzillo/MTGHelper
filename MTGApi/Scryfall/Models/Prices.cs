using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scryfall.API.Models
{
    public class Prices
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "usd")]
        public string? Usd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "usd_foil")]
        public string? UsdFoil { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "usd_etched")]
        public string? UsdEtched { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "eur")]
        public string? Euro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "eur_foil")]
        public string? EuroFoil { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "eur_etched")]
        public string? EuroEtched { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "tix")]
        public string? Tix { get; set; }
    }
}
