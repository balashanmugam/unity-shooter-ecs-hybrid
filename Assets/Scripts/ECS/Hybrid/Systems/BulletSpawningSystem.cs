using Unity.Entities;
using UnityEngine;
using ECS.Hybrid.Components;

namespace ECS.Hybrid.Systems
{
    public class BulletSpawningSystem : ComponentSystem
    {
        private struct SpawnFilter
        {
            public BulletSpawnPointComponent BulletSpawnPoint;
        }

        private struct PlayerFilter{
            public InputComponent InputComponent;
        }
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<PlayerFilter>())
            {
                
            }
        }
    }
}
