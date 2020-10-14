using System;
using System.Data;
using System.Threading.Tasks;
using Dapr.Actors;
using Resource.Actor.Interface.Models;

namespace Resource.Actor.Interface
{
    public interface IResourceActor : IActor
    {
        Task UpdateAsync(ResourceRepresentation representation);
    }
}
