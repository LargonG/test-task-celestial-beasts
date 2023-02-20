using TaskOne.Characteristics;
using UnityEngine;

namespace TaskOne.Abilities
{
    public abstract class TimeAbility: Ability
    {
        public float Reload;
        public float Duration;
        
        private float _reloadTimer = 0;

        protected TimeAbility(Soldier owner, float reload, float duration) : base(owner)
        {
            Reload = reload;
            Duration = duration;
        }
        
        public override bool Activate()
        {
            if (!base.Activate())
            {
                return false;
            }

            _reloadTimer += Time.deltaTime;
            if (_reloadTimer < Reload)
            {
                return false;
            }
            _reloadTimer = 0f;
            
            return true;
        }

        public override void Update()
        {
            _reloadTimer += Time.deltaTime;
        }
    }
}