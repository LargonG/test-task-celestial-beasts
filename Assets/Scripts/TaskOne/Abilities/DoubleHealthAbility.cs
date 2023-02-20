namespace TaskOne.Abilities
{
    public class DoubleHealthAbility: TimeAbility
    {
        private const float ReloadTime = 50f;
        private const float DurationTime = 25f;
        
        public DoubleHealthAbility(Soldier owner) : base(owner, ReloadTime, DurationTime)
        {
            
        }
        
    }
}