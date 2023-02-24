using FirstTask.Characteristics;
using Random = Unity.Mathematics.Random;

namespace FirstTask.Strategies
{
    public class RandomAttackStrategy: IStrategy
    {
        private Random _random = new Random();
        
        public void Interact(Soldier soldier, Squad squad)
        {
            var id = (int) _random.NextUInt() % squad.Soldiers.Count;
            
            var health = squad.Soldiers[id].GetCharacteristic<HealthCharacteristic>();
            var attack = soldier.GetCharacteristic<AttackCharacteristic>();
            
            attack.Damage(health);
        }
    }
}