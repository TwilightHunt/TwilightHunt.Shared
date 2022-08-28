namespace TwilightHunt.Shared.Emitter
{
    public delegate void EventAction(params object[] arg);
    public class EmitterEvents : Dictionary<string, List<EventAction>> {}
}
