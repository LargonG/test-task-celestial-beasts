using System.Collections.Generic;
using System.Linq;

namespace FirstTask
{
    public class Squad
    {
        public List<Soldier> Soldiers;

        public Squad(params Soldier[] soldiers)
        {
            Soldiers = soldiers.ToList();
        }

        public void Update(Squad enemy)
        {
            Soldiers.ForEach(it => it?.Update(this, enemy));
        }

        public bool LateUpdate()
        {
            Soldiers.ForEach(it => it?.LateUpdate());

            var count = 0;
            for (var i = Soldiers.Count - 1; i >= 0; i--)
            {
                if (Soldiers[i].Health.Health <= 0f)
                {
                    Soldiers.RemoveAt(i);
                }
                else
                {
                    count++;
                }
            }

            return count > 0;
        }
    }
}