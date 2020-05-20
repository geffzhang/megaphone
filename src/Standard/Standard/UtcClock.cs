using System;

namespace Standard
{
    public class UtcClock : IClock
    {
        public DateTimeOffset Now { get; } = DateTimeOffset.UtcNow;
    }
}