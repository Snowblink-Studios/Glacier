#if GLACIER_UNITY
using UnityEngine;

namespace Glacier.Core {
    public abstract class Variable<T> : ScriptableObject {

        [SerializeField]
        protected T value;

        public virtual T Value { get; set; }
    }
}
#endif
