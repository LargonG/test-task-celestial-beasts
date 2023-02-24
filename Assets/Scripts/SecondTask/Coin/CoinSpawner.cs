using System;
using SecondTask.Player;
using UnityEngine;

namespace SecondTask
{
    public class CoinSpawner: MonoBehaviour
    {
        [SerializeField] private PlayerInventory inventory;
        [SerializeField] private GameObject coin;
        [SerializeField] private float reload;
        
        private float _waited;
        private bool _init;

        private Transform _transform;

        private void Start()
        {
            _transform = GetComponent<Transform>();
        }
        
        private void Update()
        {
            if (!_init)
            {
                _waited += Time.deltaTime;

                if (_waited >= reload)
                {
                    var obj = Instantiate(coin, _transform.position, Quaternion.identity, _transform).
                        GetComponent<Coin>();
                    obj.SetSpawner(this);
                    obj.SetInventory(inventory);
                    
                    _init = true;
                    _waited = 0f;
                }
            }
        }

        public void CoinDestroyed()
        {
            _init = false;
            _waited = 0f;
        }
    }
}