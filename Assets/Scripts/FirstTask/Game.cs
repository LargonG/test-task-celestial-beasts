using System;
using System.Linq;
using FirstTask.Abilities;
using FirstTask.Characteristics;
using FirstTask.Strategies;
using UnityEngine;

namespace FirstTask
{
    public class Game: MonoBehaviour
    {
        private Country _countryA;
        private Country _countryB;

        private void Start()
        {
            var healthDefault = new Factory<HealthCharacteristic>(
                new HealthCharacteristic(100f));
            var attackDefault = new Factory<AttackCharacteristic>(
                new AttackCharacteristic(10f, .1f));

            var heal = new Factory<HealAbility>(
                new HealAbility(5f));
            var doubleStrength = new Factory<DoubleStrengthAbility>(
                new DoubleStrengthAbility());
            
            var attackStrategy = new AttackStrategy();
            
            _countryA = new Country(new Squad(new Soldier(
                new Characteristic[]{ healthDefault.New(), attackDefault.New() }.ToList(),
                new Ability[] { heal.New(), doubleStrength.New() }.ToList(),
                attackStrategy
            )));

            _countryB = new Country(new Squad(new Soldier(
                new Characteristic[]{healthDefault.New(), attackDefault.New()}.ToList(),
                new Ability[] {}.ToList(),
                attackStrategy
            )));
        }

        private void Update()
        {
            _countryA.Update(_countryB);
            _countryB.Update(_countryA);
        }

        private void LateUpdate()
        {
            if (!_countryA.LateUpdate())
            {
                Debug.Log("Second country win!");
                _countryA = null;
            }

            if (!_countryB.LateUpdate())
            {
                Debug.Log("First country win!");
                _countryB = null;
            }

            if (_countryA == null || _countryB == null)
            {
                Destroy(this);
            }
        }
    }
}