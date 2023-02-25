using System;
using FirstTask.Abilities;
using FirstTask.Characteristics;
using UnityEngine;
using Random = System.Random;

namespace FirstTask.Strategies
{
    public class AttackStrategy: Strategy
    {
        private Random _random = new();
        
        public override void Update(Soldier soldier)
        {
            var attack = soldier.GetCharacteristic<AttackCharacteristic>();
            var enemy = PeekRandomSoldier(soldier.Enemy);
            var health = enemy.GetCharacteristic<HealthCharacteristic>();
            
            var doubleStrengthAbility = soldier.GetAbilityOrNull<DoubleStrengthAbility>();
            doubleStrengthAbility?.Activate(soldier.Alliance.Soldiers);
            var healAbility = soldier.GetAbilityOrNull<HealAbility>();
            healAbility?.Activate(soldier.Alliance.Soldiers);

            attack.Attack(health);
            
            Debug.Log($"{soldier} attacked enemy {enemy} with strength {attack.Strength}," +
                      $" enemy health: {enemy.Health.Health}");
        }

        private Soldier PeekRandomSoldier(Squad squad)
        {
            var index = (int) MathF.Abs(_random.Next()) % squad.Soldiers.Count;
            return squad.Soldiers[index];
        }
    }
}