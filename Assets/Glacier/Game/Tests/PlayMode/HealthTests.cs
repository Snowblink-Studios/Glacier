using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Glacier.Game.Tests {
    public class HealthTests {

        [UnityTest]
        public IEnumerator BasicHealth_TakeDamage() {
            var callbackCount = 0;
            var g = new GameObject();
            var health = g.AddComponent<BasicHealth>();
            health.OnHealthValueChanged.AddListener((value) => callbackCount ++);
            yield return null;
            health.SetMax(200);
            health.SetCurrent(200);
            health.TakeDamage(20);
            Assert.AreEqual(180, health.Current);
            health.TakeDamage(190);
            Assert.AreEqual(0, health.Current);
            Assert.AreEqual(3, callbackCount);
        }

        [UnityTest]
        public IEnumerator BasicHealth_Heal() {
            var callbackCount = 0;
            var g = new GameObject();
            var health = g.AddComponent<BasicHealth>();
            health.OnHealthValueChanged.AddListener((value) => callbackCount ++);
            yield return null;
            health.SetMax(120);
            health.SetCurrent(50);
            health.Heal(25);
            Assert.AreEqual(75, health.Current);
            health.Heal(60);
            Assert.AreEqual(120, health.Current);
            Assert.AreEqual(3, callbackCount);
        }

        [UnityTest]
        public IEnumerator ArmoredHealth_TakeDamage() {
            var healthCallbackCount = 0;
            var armorCallbackCount = 0;
            var g = new GameObject();
            var health = g.AddComponent<ArmoredHealth>();
            health.OnHealthValueChanged.AddListener((value) => healthCallbackCount ++);
            health.OnArmorValueChanged.AddListener((value) => armorCallbackCount ++);
            yield return null;
            health.SetMax(200);
            health.SetMaxArmor(200);
            health.SetCurrent(200);
            health.SetCurrentArmor(200);
            health.TakeDamage(50);
            Assert.AreEqual(200, health.Current);
            Assert.AreEqual(150, health.CurrentArmor);
            health.TakeDamage(175);
            Assert.AreEqual(175, health.Current);
            Assert.AreEqual(0, health.CurrentArmor);
            Assert.AreEqual(2, healthCallbackCount);
            Assert.AreEqual(3, armorCallbackCount);
        }

        [UnityTest]
        public IEnumerator ArmoredHealth_HealArmor() {
            var healthCallbackCount = 0;
            var armorCallbackCount = 0;
            var g = new GameObject();
            var health = g.AddComponent<ArmoredHealth>();
            health.OnHealthValueChanged.AddListener((value) => healthCallbackCount ++);
            health.OnArmorValueChanged.AddListener((value) => armorCallbackCount ++);
            yield return null;
            health.SetMax(200);
            health.SetMaxArmor(200);
            health.SetCurrent(180);
            health.SetCurrentArmor(140);
            health.HealArmor(50);
            Assert.AreEqual(180, health.Current);
            Assert.AreEqual(190, health.CurrentArmor);
            health.Heal(15);
            health.HealArmor(30);
            Assert.AreEqual(195, health.Current);
            Assert.AreEqual(200, health.CurrentArmor);
            Assert.AreEqual(2, healthCallbackCount);
            Assert.AreEqual(3, armorCallbackCount);
        }
    }
}
