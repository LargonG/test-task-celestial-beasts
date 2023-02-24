using System;
using UnityEngine;

namespace SecondTask.Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerInventory))]
    public class PlayerHitEnemy: MonoBehaviour
    {
        [SerializeField] private LayerMask enemies;

        private PlayerMovement _movement;
        private PlayerInventory _inventory;

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
            _inventory = GetComponent<PlayerInventory>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if ((col.gameObject.layer & enemies) > 0)
            {
                if ()
            }
        }
    }
}