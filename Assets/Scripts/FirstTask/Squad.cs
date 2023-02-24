using System;
using System.Collections.Generic;
using UnityEngine;

namespace FirstTask
{
    [Serializable]
    public class Squad
    {
        [SerializeField] private List<Soldier> soldiers;
        public List<Soldier> Soldiers => soldiers;

        public void Update(Squad enemy)
        {
            foreach (var soldier in Soldiers)
            {
                soldier.Update(this, enemy);
            }
        }

        public void LateUpdate()
        {
            foreach (var soldier in Soldiers)
            {
                soldier.LateUpdate();
            }
        }
    }
}