using SecondTask.Player;
using UnityEngine;

namespace SecondTask
{
    public class Coin: MonoBehaviour
    {
        private static PlayerInventory _inventory;
        
        [SerializeField] private int cost;

        public void AddMoneyToPlayer()
        {
            _inventory.AddMoney(cost);
            Destroy(gameObject);
        }
    }
}