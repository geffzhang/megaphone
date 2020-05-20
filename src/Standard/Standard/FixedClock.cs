using System;

namespace Standard
{
    public class FixedClock : IClock
    {
        public FixedClock(DateTimeOffset now)
        {
            Now = now;
        }
        public DateTimeOffset Now { get; }
    }
}