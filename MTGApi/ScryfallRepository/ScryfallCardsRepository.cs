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
    public class ScryfallCardsRepository : ScryfallBaseRepository
    {
        public ScryfallCardsRepository() : base() 
        { 
        }
        public async Task<Card> GetCardByName(string exactName)
        {
            try
            {
                return await scryfallClient.Cards.GetNamedAsync(fuzzy:exactName);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return null;
            }
        }
        public async Task<HttpOperationResponse<CardList>> GetCardsByName(string name)
        {
            try
            {
                string q = $"\"{name}\" unique:name";
                Trace.WriteLine(q);
                return await scryfallClient.Cards.SearchWithHttpMessagesAsync(q);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                return new HttpOperationResponse<CardList>();
            }
        }
        public async Task<HttpOperationResponse<CardList>> GetCardsBySetColor(string setCode,string color)
        {
            try
            {
                string q = $"color={color} e:{setCode} unique:name";
                return await scryfallClient.Cards.SearchWithHttpMessagesAsync(q);
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
                return new HttpOperationResponse<CardList>();
            }
        }
    }
}
