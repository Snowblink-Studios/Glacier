#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core {
    [CreateAssetMenu(fileName="IntVariable", menuName="Glacier/Core/Variables/IntVariable")]
    public class IntVariable : VariableMutable<int> {

        private void Start() {
            Debug.Log("Variable<T> Awake()");
            _value = value;
        }
    }
}
#endif
