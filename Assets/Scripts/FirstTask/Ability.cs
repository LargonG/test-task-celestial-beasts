using System.Collections;
using System.Collections.Generic;

namespace FirstTask
{
    public abstract class Ability
    {
        public virtual bool IsActive { get; }

        public virtual void Activate(IEnumerable<Soldier> soldiers) {}

        public virtual void Update() {}
        public virtual void LateUpdate() {}
    }
}