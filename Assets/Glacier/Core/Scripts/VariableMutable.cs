#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core {
    public class VariableMutable<T> : Variable<T> {

        public override T Value { get => _value; set => _value = value; }

        protected T _value = default(T);

        
    }
}
#endif
