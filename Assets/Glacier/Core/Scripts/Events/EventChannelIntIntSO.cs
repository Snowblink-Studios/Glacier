#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Events {
    [CreateAssetMenu(menuName="Glacier/Core/Events/EventChannel(Int)", fileName="Name_Int_Int_EventChannel")]
    public class EventChannelIntIntSO : EventChannelSO<int, int> {
    }
}
#endif
