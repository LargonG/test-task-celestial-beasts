namespace FirstTask
{
    /**
     * Способности солдата
     */
    public abstract class Ability
    {
        protected bool Active;
        protected readonly Soldier Owner;

        public bool IsActivated => Active;
        
        public Ability(Soldier owner)
        {
            Owner = owner;
        }
        
        public virtual bool Activate()
        {
            if (Active)
            {
                return false;
            }

            Active = true;
            return true;
        }

        public abstract void Update();

        // For double-buffering
        public virtual void LateUpdate()
        {
            
        }

        public virtual bool Deactivate()
        {
            if (!Active)
            {
                return false;
            }

            Active = false;
            return true;
        }
    }
}