using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICourtProvider : IService
    {
        Task<IEnumerable<Court>> BrowseAsync();
        Task<Court> GetAsync(string city, string street);
    }
}
