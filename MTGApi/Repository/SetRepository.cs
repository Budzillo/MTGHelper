using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGApi.Repository
{
    public class SetRepository : BaseRepository
    {
        private ISetService setService;
        public SetRepository()
        {
            this.setService = this.serviceProvider.GetSetService();
        }
        public async Task<List<ISet>> GetSets()
        {
            try
            {
                var result = await setService.AllAsync();
                if(result != null && result.Value != null)
                {
                    return result.Value.ToList();
                }
                return new List<ISet>();
            }
            catch(Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<ISet>();
            }
        }
        public async Task<List<ISet>> GetSetsByReleaseDate(DateTime date)
        {
            try
            {
                var result = await setService.AllAsync();
                if (result != null && result.Value != null)
                {
                    return result.Value.Where(q=>q.ReleaseDate.Contains(date.Year.ToString())).ToList();
                }
                return new List<ISet>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<ISet>();
            }
        }
        public async Task<List<string>> GetSetNames()
        {
            try
            {
                var result = await setService.AllAsync();
                if (result != null && result.Value != null)
                {
                    return result.Value.Select(q=>q.Name).ToList();
                }
                return new List<string>();
            }
            catch (Exception ex)
            {
                WriteTraceExMessage(ex);
                return new List<string>();
            }
        }
    }
}
