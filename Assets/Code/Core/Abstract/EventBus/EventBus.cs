namespace Code.Core.Abstract.EventBus
{
    using System.Collections.Generic;

    public static class EventBus
    {
        private static HashSet<IEvent> _events = new HashSet<IEvent>();
    }

    internal interface IEvent
    {
    }
}