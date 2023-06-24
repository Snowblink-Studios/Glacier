#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core {
    [CreateAssetMenu(fileName="FloatVariable", menuName="Glacier/Core/Variables/FloatVariable")]
    public class FloatVariable : VariableMutable<float> {
    }
}
#endif
