using Scryfall.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGApi.ScryfallRepository
{
    public class ScryfallBaseRepository
    {
        internal ScryfallClient scryfallClient;
        public ScryfallBaseRepository()
        {
            scryfallClient = new ScryfallClient();
        }
    }
}
