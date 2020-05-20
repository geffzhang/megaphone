using System;

namespace Resource.Models
{
    public interface IResource
    {
        string Id { get; }
        string Display { get; }
        int StatusCode { get; }
        DateTimeOffset Created { get;  }
        bool IsActive { get; }
        ResourceType Type { get; }
        string Description { get; set; }
        Uri Self { get; set; }
        DateTime Published { get; set; }
    }
}