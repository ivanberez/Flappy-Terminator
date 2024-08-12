using Assets.Scripts.Enemys;
using Assets.Scripts.InteractableObjects.InteractableObjectPool;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawner
{
    [RequireComponent(typeof(GunPool))]
    public class SpawnerGunEnemy : SpawnerEnemy<GunEnemy>
    {
        private void OnValidate()
        {
            PoolEnemy = GetComponent<GunPool>();
        }
    }
}