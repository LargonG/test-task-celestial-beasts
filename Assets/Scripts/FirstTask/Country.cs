using System;
using UnityEngine;

namespace FirstTask
{
    public class Country
    {
        private readonly Squad _squad;

        public Country(Squad squad)
        {
            _squad = squad;
        }

        public void Update(Country enemy)
        {
            _squad.Update(enemy._squad);
        }

        public bool LateUpdate()
        {
            return _squad.LateUpdate();
        }
    }
}