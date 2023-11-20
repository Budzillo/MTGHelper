using MtgApiManager.Lib.Service;
using Scryfall.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGApi.Repository
{
    public abstract class BaseRepository
    {
        public IMtgServiceProvider serviceProvider = new MtgServiceProvider();
        public ScryfallClient scryfallClient = new ScryfallClient();
        public void WriteTraceExMessage(Exception ex)
        {
            Trace.WriteLine($"Error: {ex.Message}, At = {ex.StackTrace}");
        }
        public BaseRepository()
        {

        }
    }
}
