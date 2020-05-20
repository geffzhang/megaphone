using System;

namespace Standard
{
    public interface IClock
    {
        DateTimeOffset Now { get; }
    }
}