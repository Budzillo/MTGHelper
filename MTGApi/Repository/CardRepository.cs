using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGApi.Repository
{
    public class CardRepository : BaseRepository
    {
        private ICardService cardService;
        public CardRepository() 
        {
            this.cardService = this.serviceProvider.GetCardService();
        }
        #region Cards
        public async Task<List<ICard>> GetCardsBySet(string setName)
        {
            try
            {
                var result = await cardService.Where(q=>q.SetName,setName).AllAsync();
                if(result != null && result.Value != null)
                {
                    return result.Value.ToList();
                }
                return new List<ICard>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);    
                return new List<ICard>();
            }
        }
        public async Task<List<ICard>> GetCardsBySubTypes(string subTypes)
        {
            try
            {
                var result = await cardService.Where(q=>q.SubTypes,subTypes).AllAsync();
                if (result != null &&  result.Value != null)
                {
                    return result.Value.ToList();
                }
                return new List<ICard>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<ICard>();
            }
        }
        public async Task<List<ICard>> GetCardsBySuperTypes(string superTypes)
        {
            try
            {
                var result = await cardService.Where(q => q.SuperTypes, superTypes).AllAsync();
                if (result != null && result.Value != null)
                {
                    return result.Value.ToList();
                }
                return new List<ICard>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<ICard>();
            }
        }
        #endregion

        #region Informations
        public async Task<List<string>> GetFormats()
        {
            try
            {
                var result = await this.cardService.GetFormatsAsync();
                if(result != null && result.Value != null ) 
                { 
                    return result.Value.ToList(); 
                }
                return new List<string>();
            }
            catch(Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<string>();
            }
        }
        public async Task<List<string>> GetSubtypes()
        {
            try
            {
                var result = await this.cardService.GetCardSubTypesAsync();
                if (result != null && result.Value != null)
                {
                    return result.Value.ToList();
                }
                return new List<string>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<string>();
            }
        }
        public async Task<List<string>> GetSupertypes()
        {
            try
            {
                var result = await this.cardService.GetCardSuperTypesAsync();
                if (result != null && result.Value != null)
                {
                    return result.Value.ToList();
                }
                return new List<string>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<string>();
            }
        }
        public async Task<List<string>> GetCardTypes()
        {
            try
            {
                var result = await this.cardService.GetCardTypesAsync();
                if (result != null && result.Value != null)
                {
                    return result.Value.ToList();
                }
                return new List<string>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<string>();
            }
        }


        #endregion
    }
}
