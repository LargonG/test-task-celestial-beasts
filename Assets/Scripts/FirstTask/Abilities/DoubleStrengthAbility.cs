using System;
using System.Collections;
using System.Collections.Generic;
using FirstTask.Characteristics;

namespace FirstTask.Abilities
{
    // Одноразовая способность, для простоты
    public class DoubleStrengthAbility: Ability, ICloneable
    {
        public override bool IsActive { get; }
        private bool _active = false;
        
        public override void Activate(IEnumerable<Soldier> soldiers)
        {
            if (!_active)
            {
                foreach (var soldier in soldiers)
                {
                    var attack = soldier.GetCharacteristic<AttackCharacteristic>();
                    attack.Strength *= 2f;
                }
                
                _active = true;
            }
        }

        public object Clone()
        {
            return new DoubleStrengthAbility();
        }
    }
}