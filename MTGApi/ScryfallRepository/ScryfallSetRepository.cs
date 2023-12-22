using Microsoft.Rest;
using Scryfall.API;
using Scryfall.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGApi.ScryfallRepository
{
    public class ScryfallSetRepository : ScryfallBaseRepository
    {
        public ScryfallSetRepository() : base() 
        {

        }
        public async Task<SetList> GetAllSets()
        {
            try
            {
                return await scryfallClient.Sets.GetAllAsync();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return null;
            }
        }
    }
}
