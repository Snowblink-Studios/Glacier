#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Variables {
    [CreateAssetMenu(fileName="BoolRuntimeVariable", menuName="Glacier/Core/RuntimeVariables/BoolRuntimeVariable")]
    public class BoolRuntimeVariable : RuntimeVariable<bool> {
    }
}
#endif
