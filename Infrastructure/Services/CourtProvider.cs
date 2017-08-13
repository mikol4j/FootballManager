using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Diagnostics;

namespace Infrastructure.Services
{
    public class CourtProvider : ICourtProvider
    {
        private readonly IMemoryCache _cache;
        private readonly static string CacheKey = "courts";
        private static readonly IDictionary<string, IEnumerable<CourtDetails>> avaibleCourts =
            new Dictionary<string, IEnumerable<CourtDetails>>
            {
                ["Poland"] = new List<CourtDetails>()
                {
                    new CourtDetails("Warszawa", "Lazienkowska")
                },
                ["England"] = new List<CourtDetails>()
                {
                    new CourtDetails("Manchaster", "Old Trafford"),
                    new CourtDetails("London", "Emirates Stadium")
                },
                ["Spain"] = new List<CourtDetails>()
                {
                    new CourtDetails("Barcelona", "Camp Nou")
                },
                ["Germany"] = new List<CourtDetails>()
                {
                    new CourtDetails("Monachium", "Allianz Arena")
                }
            };

        public CourtProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<IEnumerable<Court>> BrowseAsync()
        {
            var courts = _cache.Get<IEnumerable<Court>>(CacheKey);
            if(courts == null)
            {
                courts = await GetAllAsync();
                _cache.Set(CacheKey, courts);
            }

            return courts;
        }

        private async Task<IEnumerable<Court>> GetAllAsync()
            => await Task.FromResult(avaibleCourts.GroupBy(x => x.Key)
                .SelectMany(g => g.SelectMany(v => v.Value.Select(c => new Court
                {
                    City = v.Key,
                    Street = c.Street,
                    Name = c.City
                }
                  ))));

        public async Task<Court> GetAsync(string city, string street)
        {
            if(!avaibleCourts.ContainsKey(city))
            {
                throw new Exception($"Court in: '{city}' is not avaible");
            }
            var courts = avaibleCourts[city];
            var court = courts.SingleOrDefault(x => x.City == city);
            if(court == null)
            {
                throw new Exception($"Court : '{street}' for city: '{city}' is not avaible");
            }
            return await Task.FromResult(new Court() { City = city, Street = street }); 
        }

        private class CourtDetails
        {
            public string City { get; }
            public string Street { get; }

            public CourtDetails(string city, string street)
            {
                City = city;
                Street = street;
            }
        }
    }
}
