using Dapr.Client;
using Feeds.API.Models;
using Standard.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feeds.API.Services
{
    public class ResourceStorageService : IPartionedStorageService<StorageEntry<List<Resource>>>
    {
        const string STATE_STORE = "feed-state-store";

        private readonly DaprClient client;
        private readonly Dictionary<string, string> trackedEtags = new Dictionary<string, string>();

        public ResourceStorageService(DaprClient client)
        {
            this.client = client;
        }

        public async Task<StorageEntry<List<Resource>>> GetAsync(string partitionKey, string contentKey)
        {
            string key = $"resources/{partitionKey}/{contentKey}";
            var (value, etag) = await this.client.GetStateAndETagAsync<StorageEntry<List<Resource>>>(STATE_STORE, key);
            trackedEtags[key] = etag;

            return value;
        }

        public async Task SetAsync(string partitionKey, string contentKey, StorageEntry<List<Resource>> content)
        {
            string key = $"resources/{partitionKey}/{contentKey}";
            if (trackedEtags.ContainsKey(key))
            {
                var stateSaved = await this.client.TrySaveStateAsync<StorageEntry<List<Resource>>>(STATE_STORE, key, content, trackedEtags[key]);
                if (stateSaved)
                    return;
                throw new Exception($"failed to save state for {key}");
            }
            else
            {
                await this.client.SaveStateAsync<StorageEntry<List<Resource>>>(STATE_STORE, key, content);
            }
        }
    }
}
