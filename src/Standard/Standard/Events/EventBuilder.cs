namespace Standard.Events
{
    public class EventBuilder
    {
        private readonly Event e;

        private EventBuilder(string eventName) => this.e = new Event { Name = eventName };

        public static EventBuilder NewEvent(string eventName)
        {
            var b = new EventBuilder(eventName);
            return b;
        }
        public EventBuilder WithParameter(string name, string value)
        {
            this.e.Parameters.Add(name, value);
            return this;
        }

        public EventBuilder WithMetadata(string name, string value)
        {
            this.e.Metadata.Add(name, value);
            return this;
        }

        public EventBuilder WithData(string name, object value)
        {
            this.e.Data.Add(name, value);
            return this;
        }

        public Event Make()
        {
            return this.e;
        }
    }
}