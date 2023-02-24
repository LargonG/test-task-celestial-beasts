using UnityEngine;
using UnityEngine.Serialization;

namespace SecondTask.Player
{
    public class PlayerInventory: MonoBehaviour
    {
        [SerializeField] private int money;

        public void AddMoney(int delta)
        {
            money += delta;
        }
    }
}