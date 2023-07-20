#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Variables {
    [CreateAssetMenu(fileName="FloatVariable", menuName="Glacier/Core/Variables/FloatVariable")]
    public class FloatVariable : VariableMutable<float> {
    }
}
#endif
