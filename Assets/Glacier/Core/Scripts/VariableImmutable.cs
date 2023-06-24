#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core {
    public class VariableImmutable<T> : Variable<T> {

        public override T Value {
            get => value;
            set {
                Debug.LogError("Can't modify immutable variable.");
            }
        }
    }
}
#endif
