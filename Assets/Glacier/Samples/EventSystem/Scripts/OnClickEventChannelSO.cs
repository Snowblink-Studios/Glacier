#if GLACIER_UNITY
using UnityEngine;
using Glacier.Core.Events;

namespace Glacier.Samples.EventSystem {
    [CreateAssetMenu(menuName="Glacier/Samples/EventSystem/Events/OnClick", fileName="OnClick_EventChannelSO")]
    public class OnClickEventChannelSO : EventChannelSO<string> {
    }
}
#endif
