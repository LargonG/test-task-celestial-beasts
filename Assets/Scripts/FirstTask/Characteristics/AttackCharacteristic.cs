using System;
using UnityEngine;

namespace FirstTask.Characteristics
{
    public class AttackCharacteristic: Characteristic, ICloneable
    {
        public float Strength
        {
            get => _strength[0];
            set => _strength[1] = value;
        }
        private readonly float[] _strength;
        
        public float Reload;

        private float _elapsedTime;

        public AttackCharacteristic(float strength, float reload)
        {
            _strength = new[] { strength, strength };
            Reload = reload;
        }

        public void Attack(HealthCharacteristic health)
        {
            _elapsedTime += Time.deltaTime;
            var times = (int) (_elapsedTime / Reload);
            _elapsedTime -= times * Reload;
            var damage = Strength * times;
            health.ShiftHealth(-damage);
        }

        public override void SwapBuffer()
        {
            _strength[0] = _strength[1];
        }

        public object Clone()
        {
            return new AttackCharacteristic(Strength, Reload);
        }
    }
}