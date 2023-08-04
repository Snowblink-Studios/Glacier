#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Variables {
    public class VariableImmutable<T> : RuntimeVariable<T> {

        /*public override T Value {
            get => value;
            set {
                Debug.LogError("Can't modify immutable variable.");
            }
        }*/
    }
}
#endif
