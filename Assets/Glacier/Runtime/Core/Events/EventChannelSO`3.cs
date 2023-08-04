#if GLACIER_UNITY
using System.Collections.Generic;

namespace Glacier.Core.Events {
    public class EventChannelSO<T1, T2, T3> : EventChannelBaseSO {

        private List<EventChannelListener<T1, T2, T3>> _listenersT3 = new();

        public void AddListener(EventChannelListener<T1, T2, T3> listener) => AddListener(listener, _listenersT3);
        public void RemoveListener(EventChannelListener<T1, T2, T3> listener) => RemoveListener(listener, _listenersT3);

        public virtual void Raise(T1 param1, T2 param2, T3 param3) {
            Raise(_listenersT3, (l) => l.OnEventRaised(param1, param2, param3));
        }
    }
}
#endif
