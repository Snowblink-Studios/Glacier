#if GLACIER_UNITY
using System.Collections.Generic;

namespace Glacier.Core.Events {
    public class EventChannelSO<T1, T2> : EventChannelBaseSO {

        private List<EventChannelListener<T1, T2>> _listenersT2 = new();

        public void AddListener(EventChannelListener<T1, T2> listener) => AddListener(listener, _listenersT2);
        public void RemoveListener(EventChannelListener<T1, T2> listener) => RemoveListener(listener, _listenersT2);

        public void Raise(T1 param1, T2 param2) {
            Raise(_listenersT2, (l) => l.OnEventRaised(param1, param2));
        }
    }
}
#endif
