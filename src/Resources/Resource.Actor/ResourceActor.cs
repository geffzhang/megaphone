using Dapr.Actors;
using Dapr.Actors.Runtime;
using Dapr.Client;
using Resource.Actor.Commands;
using Resource.Actor.Events;
using Resource.Actor.Interface;
using Resource.Actor.Interface.Models;
using Resource.Actor.Models;
using System;
using System.Threading.Tasks;

namespace Resource.Actor
{
    public class ResourceActor : Dapr.Actors.Runtime.Actor, IResourceActor, IRemindable
    {
        private DaprClient DaprClient;
        private ResourceActorState state;
        private string StateName;

        protected async override Task OnActivateAsync()
        {
            StateName = this.Id.GetId();

            state = await this.StateManager.GetStateAsync<ResourceActorState>(StateName);
            if (state == null)
            {
                state = new ResourceActorState();
                await this.StateManager.SetStateAsync<ResourceActorState>(StateName, state);
            }

            DaprClient = new DaprClientBuilder().Build();

            await base.OnActivateAsync();
        }

        protected async override Task OnPreActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            state = await this.StateManager.GetStateAsync<ResourceActorState>(StateName);

            await base.OnPreActorMethodAsync(actorMethodContext);
        }

        protected async override Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            await this.StateManager.SetStateAsync<ResourceActorState>(StateName, state);

            await base.OnPostActorMethodAsync(actorMethodContext);
        }

        protected async override Task OnDeactivateAsync()
        {
            await this.SaveStateAsync();

            await base.OnDeactivateAsync();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceActor"/> class.
        /// </summary>
        /// <param name="service">Actor Service hosting the actor.</param>
        /// <param name="actorId">Actor Id.</param>
        public ResourceActor(ActorService service, ActorId actorId) : base(service, actorId)
        {
        }

        private async Task RegisterCrawlReminder(CrawlStrategy strategy)
        {
            state.CrawlCount = 0;

            switch (strategy)
            {
                case CrawlStrategy.Realtime:
                    await this.RegisterReminderAsync("crawl", null, TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(15));
                    break;
                case CrawlStrategy.Hourly:
                    await this.RegisterReminderAsync("crawl", null, TimeSpan.FromHours(1), TimeSpan.FromHours(1));
                    break;
                case CrawlStrategy.Daily:
                    await this.RegisterReminderAsync("crawl", null, TimeSpan.FromDays(1), TimeSpan.FromDays(1));
                    break;
                case CrawlStrategy.Weekly:
                    await this.RegisterReminderAsync("crawl", null, TimeSpan.FromDays(7), TimeSpan.FromDays(7));
                    break;
                case CrawlStrategy.Monthly:
                    await this.RegisterReminderAsync("crawl", null, TimeSpan.FromDays(30), TimeSpan.FromDays(30));
                    break;
            }

            this.state.IsCrawlReminderActive = true;
        }

        private async Task UnregisterCrawlReminder()
        {
            await this.UnregisterReminderAsync("crawl");
            this.state.IsCrawlReminderActive = false;
        }

        public async Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
        {
            this.state.CrawlCount++;

            var c = new PublishCrawlRequestEventCommand(new CrawlRequestEvent { Url = this.state.Resource.Self.OriginalString });
            await c.ApplyAsync(this.DaprClient);

            await AdjustCrawlStrategy();
        }

        private async Task AdjustCrawlStrategy()
        {
            switch (state.Resource.Type)
            {
                case ResourceType.Page:
                    await AdjustPageCrawlStrategy();
                    break;
                case ResourceType.Feed:
                    {
                        if (state.IsCrawlReminderActive)
                            break;

                        await UnregisterCrawlReminder();
                        await RegisterCrawlReminder(CrawlStrategy.Realtime);                      
                    }
                    break;
            }
        }

        private async Task AdjustPageCrawlStrategy()
        {
            switch (state.CrawlStrategy)
            {
                case CrawlStrategy.Hourly:
                    if (state.CrawlCount > 23)
                    {
                        await UnregisterCrawlReminder();
                        await RegisterCrawlReminder(CrawlStrategy.Daily);
                    }
                    break;
                case CrawlStrategy.Daily:
                    if (state.CrawlCount > 6)
                    {
                        await UnregisterCrawlReminder();
                        await RegisterCrawlReminder(CrawlStrategy.Weekly);
                    }
                    break;
                case CrawlStrategy.Weekly:
                    if (state.CrawlCount > 3)
                    {
                        await UnregisterCrawlReminder();
                        await RegisterCrawlReminder(CrawlStrategy.Monthly);
                    }
                    break;
                case CrawlStrategy.Monthly:
                    if (state.CrawlCount > 11)
                    {
                        await UnregisterCrawlReminder();
                    }
                    break;
            }
        }

        public async Task UpdateAsync(ResourceRepresentation representation)
        {
            bool changed = UpdateResource(representation);

            if (changed)
            {
                var c = MakeEventPublishCommand();
                await c.ApplyAsync(this.DaprClient);
            }

            if (!state.IsCrawlReminderActive)
                await AdjustCrawlStrategy();
        }

        private bool UpdateResource(ResourceRepresentation representation)
        {
            var changed = false;

            changed = changed || state.Resource.Id != representation.Id;

            state.Resource.Id = representation.Id;

            changed = changed || state.Resource.Self != representation.Self;

            state.Resource.Self = representation.Self;

            changed = changed || state.Resource.StatusCode != representation.StatusCode;

            state.Resource.StatusCode = representation.StatusCode;

            if (representation.IsActive)
            {
                changed = changed || state.Resource.Created != representation.Created;

                state.Resource.Created = representation.Created;

                changed = changed || state.Resource.Published != representation.Published;

                state.Resource.Published = representation.Published;

                changed = changed || state.Resource.Type != representation.Type;

                state.Resource.Type = representation.Type;

                changed = changed || state.Resource.Description != representation.Description;

                state.Resource.Description = representation.Description;

                changed = changed || state.Resource.Display != representation.Display;

                state.Resource.Display = representation.Display;
            }

            return changed;
        }

        private PublishEventCommand<ResourceEvent> MakeEventPublishCommand()
        {
            var e = new ResourceEvent
            {
                Event = "update",
                Id = state.Resource.Id,
                LastCrawled = DateTimeOffset.UtcNow,
                LastStatusCode = state.Resource.StatusCode,
                Url = state.Resource.Self.AbsoluteUri,
                Type = state.Resource.Type
            };

            if (e.Type == ResourceType.Page)
                return new PublishPageUpdateEventCommand(e);
            else
                return new PublishFeedUpdateEventCommand(e);
        }
    }
}
