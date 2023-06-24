#if GLACIER_UNITY
namespace Glacier.Game {
    public interface IHealth {

        int Current { get; }
        int Max { get; }

        void TakeDamage(int amount);
        void Heal(int amount);
    }
}
#endif
