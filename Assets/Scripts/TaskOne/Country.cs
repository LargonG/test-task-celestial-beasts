using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaskOne
{
    public class Country: MonoBehaviour
    {
        [SerializeField] private Squad _squad;

        [SerializeField] private Country enemy;

        private void Update()
        {
            _squad.Update(enemy._squad);
        }

        private void LateUpdate()
        {
            _squad.LateUpdate();
        }
    }
}