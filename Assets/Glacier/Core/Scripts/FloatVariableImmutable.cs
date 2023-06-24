#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core {
    [CreateAssetMenu(fileName="FloatVariableImmutable", menuName="Glacier/Core/Variables/FloatVariable (Immutable)")]
    public class FloatVariableImmutable : VariableImmutable<float> {
    }
}
#endif
