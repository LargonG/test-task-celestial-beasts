using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TaskOne.Characteristics;
using Unity.VisualScripting;
using UnityEngine;

namespace TaskOne
{
    [Serializable]
    public sealed class Soldier
    {
        public bool IsAlive => _health.Value > 0;
        
        // Use only in Update's methods (in methods that only Update uses)
        internal Squad GetAllianceSquad() => _alliance;
        internal Squad GetEnemySquad() => _enemy;
        
        // Maybe, some day we will want to add new ability or a component while running,
        // to do this I would change the type of this to Array, create for each component class special id,
        // and find component in array by it's id
        // I'm working here on this problem: https://github.com/LargonG/kote-engine
        [SerializeField] private readonly Ability[] _abilities;
        [SerializeField] private readonly ICharacteristic[] _characteristics;
        [SerializeField] private readonly IStrategy _allianceStrategy;
        [SerializeField] private readonly IStrategy _enemyStrategy;
        
        private Squad _alliance;
        private Squad _enemy;

        private readonly HealthCharacteristic _health;

        public Soldier(ICharacteristic[] characteristics, Ability[] abilities,
            IStrategy allianceStrategy, IStrategy enemyStrategy)
        {
            _characteristics = characteristics;
            _abilities = abilities;
            _allianceStrategy = allianceStrategy;
            _enemyStrategy = enemyStrategy;
            
            _health = GetCharacteristic<HealthCharacteristic>();
        }
        
        public void Update(Squad ally, Squad enemy)
        {
            _allianceStrategy.Interact(this, ally);
            _enemyStrategy.Interact(this, enemy);
        }

        /// <summary>
        /// This method is for double-buffering for characteristics & abilities
        /// </summary>
        public void LateUpdate()
        {
            foreach (var characteristic in _characteristics)
            {
                characteristic.SwapBuffer();
            }

            foreach (var ability in _abilities)
            {
                ability.LateUpdate();
            }
        }

        public T GetCharacteristic<T>() where T : class => FindOrNull<T, ICharacteristic>(_characteristics);
        public T GetAbility<T>() where T : class => FindOrNull<T, Ability>(_abilities);

        private static TR FindOrNull<TR, T>(IEnumerable<T> collection)
            where TR : class
            where T: class
        {
            foreach (var i in collection)
            {
                if (i is TR res)
                {
                    return res;
                }
            }

            return null;
        }

        private static TR Find<TR, T>(IEnumerable<T> collection) where TR : T
        {
            foreach (var i in collection)
            {
                if (i is TR res)
                {
                    return res;
                }
            }

            throw new InvalidOperationException($"{typeof(T)} was not found");
        }
    }
}