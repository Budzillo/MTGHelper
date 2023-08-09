using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGHelper
{
    public class ClassConst
    {
        public const string BASE_IMAGE_CATALOG_NAME = "/Resources/Images/";
        public const string POISON_COUNTER_IMAGE_NAME = $"{BASE_IMAGE_CATALOG_NAME}poison_counter.svg";
        public const string ENERGY_COUNTER_IMAGE_NAME = $"{BASE_IMAGE_CATALOG_NAME}energy_counter.svg";
        public const string TICKETS_COUNTER_IMAGE_NAME = $"{BASE_IMAGE_CATALOG_NAME}ticket_counter.svg";
        public const string HEART_IMAGE_NAME = $"{BASE_IMAGE_CATALOG_NAME}heart.svg";

        public const string LIFE_COUNTER_NAME = "life";
        public const string POISON_COUNTER_NAME = "poison";
        public const string ENERGY_COUNTER_NAME = "energy";
        public const string TICKETS_COUNTER_NAME = "tickets";

        public static readonly Color GREEN_COLOR = Color.FromRgb(0,115,62);
        public static readonly Color BLUE_COLOR = Color.FromRgb(14,104,171);
        public static readonly Color RED_COLOR = Color.FromRgb(211,32,42);
        public static readonly Color WHITE_COLOR = Color.FromRgb(249,250,244);
        public static readonly Color BLACK_COLOR = Color.FromRgb(21,11,0);
        public enum COUNTER_TYPES : int
        {
            UNKOWN = 0,
            LIFE = 1,
            POISON = 2,
            ENERGY = 3,
            TICKETS = 4
        }
    }
}
