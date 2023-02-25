using System;
using UnityEngine;

namespace FirstTask.Characteristics
{
    public class HealthCharacteristic: Characteristic, ICloneable
    {
        public float MaxHealth;


        public float Health
        {
            get => _health[0];
            set => _health[1] = value;
        }
        private readonly float[] _health;
        
        public HealthCharacteristic(float maxHealth)
        {
            _health = new[] { maxHealth, maxHealth };
            MaxHealth = maxHealth;
        }

        private HealthCharacteristic(float maxHealth, float health) : this(maxHealth)
        {
            _health[0] = _health[1] = health;
        }

        public void ShiftHealth(float delta)
        {
            _health[1] = MathF.Max(0, MathF.Min(_health[1] + delta, MaxHealth));
        }

        public override void SwapBuffer()
        {
            _health[0] = _health[1];
        }

        public object Clone()
        {
            return new HealthCharacteristic(MaxHealth, Health);
        }
    }
}