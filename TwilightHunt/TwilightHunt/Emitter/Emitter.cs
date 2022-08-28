using TwilightHunt.Shared.API;

namespace TwilightHunt.Shared.Emitter
{
    public abstract class Emitter : IBridgeEmitter
    {
        public EmitterEvents _emitters { get; set; }
        public Emitter()
        {
            _emitters = new EmitterEvents();
        }

        /// <summary>
        /// Подписаться на определенное событие по его имени
        /// </summary>
        /// <param name="event_name">Наименование события</param>
        /// <param name="action">Action, который будет вызван при срабатывании Emit</param>
        /// <returns>Action отписки от события</returns>
        public Action Subscribe(string event_name, EventAction action)
        {
            _emitters.TryGetValue(event_name, out var list);
            if (list != null) _emitters[event_name].Add(action);
            else _emitters[event_name] = new List<EventAction> { action };
            return new Action(() => _emitters[event_name]?.Remove(action));
        }

        public Action Subscribe(Enum event_name, EventAction action) => Subscribe(event_name.ToString(), action);

        /// <summary>
        /// Вызвать событие по его имени
        /// </summary>
        /// <param name="event_name">Наименование события</param>
        /// <param name="args">Аргументы события</param>
        public void Emit(string event_name, params object[] args)
        {
            _emitters.TryGetValue(event_name, out var actions);
            actions?.ForEach((action) => action(args));
        }

        public void Emit(Enum event_name, params object[] args) => Emit(event_name.ToString(), args);
    }
}
