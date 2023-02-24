using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace SecondTask.Player
{
    public class PlayerInventory: MonoBehaviour
    {
        [SerializeField] private int money;
        [SerializeField] private TMP_Text text;

        public void AddMoney(int delta)
        {
            money += delta;
            text.text = money.ToString();
        }
    }
}