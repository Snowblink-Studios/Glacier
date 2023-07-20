#if GLACIER_UNITY
using System;
using UnityEngine;

namespace Glacier.Core.Variables {
    public abstract class RuntimeVariable<T> : ScriptableObject {

        [NonSerialized]
        protected T value;

        public T Value { get; set; }
    }
}
#endif
