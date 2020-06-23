using Dapr.Actors.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Resource.Actor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseActors(actorRuntime =>
                        {
                            actorRuntime.ConfigureActorSettings(a =>
                            {
                                a.ActorIdleTimeout = TimeSpan.FromMinutes(70);
                                a.ActorScanInterval = TimeSpan.FromSeconds(35);
                                a.DrainOngoingCallTimeout = TimeSpan.FromSeconds(35);
                                a.DrainRebalancedActors = true;
                            });
                            actorRuntime.RegisterActor<ResourceActor>();
                        });
                });
    }
}
