using System;
using SecondTask.Player;
using UnityEngine;

namespace SecondTask
{
    public class Coin: MonoBehaviour
    {
        private PlayerInventory _inventory;
        
        [SerializeField] private int cost;
        [SerializeField] private LayerMask player;

        private CoinSpawner _spawner;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (((1 << col.gameObject.layer) & player) > 0)
            {
                _inventory.AddMoney(cost);
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _spawner.CoinDestroyed();
        }

        internal void SetSpawner(CoinSpawner spawner)
        {
            _spawner = spawner;
        }

        internal void SetInventory(PlayerInventory inventory)
        {
            _inventory = inventory;
        }
    }
}