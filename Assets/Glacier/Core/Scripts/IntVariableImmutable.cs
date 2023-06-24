#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core {
    [CreateAssetMenu(fileName="IntVariableImmutable", menuName="Glacier/Core/Variables/IntVariable (Immutable)")]
    public class IntVariableImmutable : VariableImmutable<int> {
    }
}
#endif
