using TwilightHunt.Shared.Emitter;
namespace TwilightHunt.Shared.API
{
    internal interface IBridgeEmitter
    {
        EmitterEvents _emitters { get; set; }
        Action Subscribe(string event_name, EventAction action);
        Action Subscribe(Enum event_name, EventAction action);
        void Emit(string event_name, params object[] args);
        void Emit(Enum event_name, params object[] args);
    }
}
