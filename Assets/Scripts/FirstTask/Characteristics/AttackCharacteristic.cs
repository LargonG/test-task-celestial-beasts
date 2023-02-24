using UnityEngine;

namespace FirstTask.Characteristics
{
    public class AttackCharacteristic: Characteristic
    {
        private readonly float _value;
        private readonly float _reload;

        public AttackCharacteristic(float value, float reload)
        {
            _value = value;
            _reload = reload;
        }

        public void Damage(HealthCharacteristic health)
        {
            var delta = Time.deltaTime;
            // Something about calculation accuracy & error accumulation... (no)
            // I heard something about it, but never used
            health.DamageHealth(_value * delta / _reload);
        }
    }
}