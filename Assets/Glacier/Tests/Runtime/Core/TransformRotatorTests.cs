using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Glacier.Core.Transforms;

namespace Glacier.Core.Tests {
    public class TransformRotatorTests {

        [UnityTest]
        public IEnumerator Rotating() {
            var g = new GameObject("Rotator");
            var rotator = g.AddComponent<TransformRotator>();
            rotator.SetFixedDuration(2f);

            var hasReturned = false;
            var returnedAngle = Vector3.zero;
            rotator.OnFinished.AddListener(() => {
                hasReturned = true;
                returnedAngle = rotator.transform.rotation.eulerAngles;
            });
            rotator.Rotate(new Vector3(0f, 0f, 0f), new Vector3(1.0f, 2.0f, 3.0f));

            var timeout = 10f;
            while (!hasReturned && timeout > 0f) {
                timeout -= Time.deltaTime;
                yield return null;
            }

            Assert.AreEqual(true, hasReturned);
            var equalX = returnedAngle.x + 0.0001f > 1.0f && returnedAngle.x - 0.0001f < 1.0f;
            var equalY = returnedAngle.y + 0.0001f > 2.0f && returnedAngle.y - 0.0001f < 2.0f;
            var equalZ = returnedAngle.z + 0.0001f > 3.0f && returnedAngle.z - 0.0001f < 3.0f;
            Assert.AreEqual(true, equalX);
            Assert.AreEqual(true, equalY);
            Assert.AreEqual(true, equalZ);
        }
    }
}
