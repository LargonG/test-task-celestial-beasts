using System;
using System.Collections.Generic;
using FirstTask.Characteristics;

namespace FirstTask.Abilities
{
    public class HealAbility: Ability, ICloneable
    {
        public float Power;
        
        public override bool IsActive { get; }
        private bool _active = false;

        public HealAbility(float power)
        {
            Power = power;
        }

        public override void Activate(IEnumerable<Soldier> soldiers)
        {
            if (!_active)
            {
                foreach (var soldier in soldiers)
                {
                    var health = soldier.GetCharacteristic<HealthCharacteristic>();
                    health.ShiftHealth(Power);
                }
                
                _active = true;
            }
        }

        public object Clone()
        {
            return new HealAbility(Power);
        }
    }
}