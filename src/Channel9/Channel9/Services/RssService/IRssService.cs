using Channel9.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Channel9.Services.RssService
{
    public interface IRssService
    {
        Task<List<Episode>> GetEpisodesAsync(string uri, string feedId);
    }
}