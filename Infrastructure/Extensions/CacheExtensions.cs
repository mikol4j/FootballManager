using Infrastructure.Dto;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cacheMemory, Guid tokenId, JwtDto jwt)
            => cacheMemory.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cacheMemory, Guid tokenId)
            => cacheMemory.Get<JwtDto>(GetJwtKey(tokenId));

        public static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}
