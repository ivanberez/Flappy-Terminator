using Assets.Scripts.Enemys;
using Assets.Scripts.InteractableObjects.InteractableObjectPool;
using UnityEngine;

namespace Assets.Scripts.Spawner
{
    [RequireComponent(typeof(KnifePool))]
    public class SpawnerKnife : SpawnerEnemy<Knife>
    {
        private void OnValidate()
        {
            PoolEnemy = GetComponent<KnifePool>();
        }
    }
}