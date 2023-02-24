namespace FirstTask.Abilities
{
    public class DoubleStrengthAbility: TimeAbility
    {
        // Если бы у меня было больше времени, я бы перенёс эти данные либо в json,
        // Либо в scriptableObject, но я им редко пользовался, поэтому не сейчас
        private const float ReloadTime = 10f;
        private const float DurationTime = 5f;

        public DoubleStrengthAbility(Soldier owner) : base(owner, ReloadTime, DurationTime)
        {
            
        }
    }
}