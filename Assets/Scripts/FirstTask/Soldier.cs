using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FirstTask.Characteristics;

namespace FirstTask
{
    public class Soldier: ICloneable
    {
        public Squad Alliance;
        public Squad Enemy;
        
        private List<Characteristic> _characteristics;
        private List<Ability> _abilities;

        private Strategy _strategy;

        public HealthCharacteristic Health;

        public Soldier(List<Characteristic> characteristics, List<Ability> abilities, Strategy strategy)
        {
            _characteristics = characteristics;
            _abilities = abilities;
            _strategy = strategy;

            Health = GetCharacteristic<HealthCharacteristic>();
        }

        public void Update(Squad ally, Squad enemy)
        {
            Alliance = ally;
            Enemy = enemy;
            
            _strategy.Update(this);
            _abilities.ForEach(it => it.Update());
        }

        public void LateUpdate()
        {
            _characteristics.ForEach(it => it.SwapBuffer());
            _abilities.ForEach(it => it.LateUpdate());
        }

        public T GetCharacteristicOrNull<T>() where T: Characteristic =>
            FindOrNull<T, Characteristic>(_characteristics);
        public T GetCharacteristic<T>() where T: Characteristic =>
            Find<T, Characteristic>(_characteristics);
        
        public T GetAbilityOrNull<T>() where T : Ability =>
            FindOrNull<T, Ability>(_abilities);
        public T GetAbility<T>() where T : Ability =>
            Find<T, Ability>(_abilities);
        
        
        private static TR FindOrNull<TR, T>(IEnumerable<T> collection)
            where TR : class, T
            where T: class
        {
            foreach (var obj in collection)
            {
                if (obj is TR res)
                {
                    return res;
                }
            }

            return null;
        }

        private static TR Find<TR, T>(IEnumerable<T> collection) where TR: T
        {
            foreach (var obj in collection)
            {
                if (obj is TR res)
                {
                    return res;
                }
            }

            throw new InvalidOperationException($"Couldn't find object with type {typeof(T)}");
        }

        public object Clone()
        {
            return new Soldier(_characteristics, _abilities, _strategy);
        }
    }
}