#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Events {
    [CreateAssetMenu(menuName="Glacier/Core/Events/EventChannel(Float)", fileName="Name_Float_EventChannel")]
    public class EventChannelFloatSO : EventChannelSO<float> {
    }
}
#endif
