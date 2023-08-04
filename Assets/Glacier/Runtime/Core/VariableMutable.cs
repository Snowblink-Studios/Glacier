#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core.Variables {
    public class VariableMutable<T> : RuntimeVariable<T> {

        //public override T Value { get => _value; set => _value = value; }

        protected T _value = default(T);

        
    }
}
#endif
