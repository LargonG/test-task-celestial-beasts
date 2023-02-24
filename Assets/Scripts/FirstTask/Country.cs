using UnityEngine;

namespace FirstTask
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