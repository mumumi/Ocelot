﻿namespace Ocelot.Requester
{
    using System;
    using System.Collections.Concurrent;

    using Configuration;

    public class MemoryHttpClientCache : IHttpClientCache
    {
        private readonly ConcurrentDictionary<DownstreamRoute, IHttpClient> _httpClientsCache;

        public MemoryHttpClientCache()
        {
            _httpClientsCache = new ConcurrentDictionary<DownstreamRoute, IHttpClient>();
        }

        public void Set(DownstreamRoute key, IHttpClient client, TimeSpan expirationTime)
        {
            _httpClientsCache.AddOrUpdate(key, client, (k, oldValue) => client);
        }

        public IHttpClient Get(DownstreamRoute key)
        {
            //todo handle error?
            return _httpClientsCache.TryGetValue(key, out var client) ? client : null;
        }
    }
}
