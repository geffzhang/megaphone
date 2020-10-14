using Dapr.Client;
using Feeds.API.Models;
using Standard.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feeds.API.Services
{
    public class FeedStorageService : IPartionedStorageService<StorageEntry<List<Feed>>>
    {
        private readonly DaprClient client;

        const string STATE_STORE = "feed-state-store";

        private string trackedEtag = string.Empty;

        public FeedStorageService(DaprClient client)
        {
            this.client = client;
        }

        public async Task<StorageEntry<List<Feed>>> GetAsync(string partitionKey, string contentKey)
        {
            var (value, etag) = await this.client.GetStateAndETagAsync<StorageEntry<List<Feed>>>(STATE_STORE, $"{partitionKey}/{contentKey}");
            trackedEtag = etag;

            return value ?? new StorageEntry<List<Feed>>();
        }

        public async Task SetAsync(string partitionKey, string contentKey, StorageEntry<List<Feed>> content)
        {
            content.Updated = DateTimeOffset.UtcNow;
            if (string.IsNullOrEmpty(trackedEtag))
            {
                var stateSaved = await this.client.TrySaveStateAsync(STATE_STORE, $"{partitionKey}/{contentKey}", content, trackedEtag);
                if (stateSaved)
                    return;
                throw new Exception($"failed to save state for {partitionKey}/{contentKey}");
            }
            else
            {
                await this.client.SaveStateAsync(STATE_STORE, $"{partitionKey}/{contentKey}", content);
            }
        }
    }
}
