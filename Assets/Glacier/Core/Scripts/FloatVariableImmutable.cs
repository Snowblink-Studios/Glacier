#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Variables {
    [CreateAssetMenu(fileName="FloatVariableImmutable", menuName="Glacier/Core/Variables/FloatVariable (Immutable)")]
    public class FloatVariableImmutable : VariableImmutable<float> {
    }
}
#endif
