#if GLACIER_UNITY
using UnityEngine;
using UnityEngine.Events;

namespace Glacier.Core.Events {
    public class EventChannelListener<T1, T2> : MonoBehaviour {

        [SerializeField]
        private EventChannelSO<T1, T2> eventChannel;
        [SerializeField]
        private UnityEvent<T1, T2> onEventRaised = new();

        public virtual void OnEventRaised(T1 param1, T2 param2) => onEventRaised?.Invoke(param1, param2);
        public void SetEventChannel(EventChannelSO<T1, T2> eventChannel) => this.eventChannel = eventChannel;
        public void AddUnityEventListener(UnityAction<T1, T2> listener) => onEventRaised.AddListener(listener);

        private void OnEnable() => eventChannel?.AddListener(this);
        private void OnDisable() => eventChannel?.RemoveListener(this);
    }
}
#endif
