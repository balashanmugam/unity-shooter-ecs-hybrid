using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Systems
{
    public class EnemySpawnSystem : ComponentSystem
    {
        private struct Filter
        {
            public EnemySpawnPointComponent EnemySpawnPointComponent;
        }
        protected override void OnUpdate()
        {
            float time = Time.time;
            foreach (var entity in GetEntities<Filter>())
            {
                if (time - entity.EnemySpawnPointComponent.timeSinceLastSpawn > 0.5f)
                {
                    Object.Instantiate(entity.EnemySpawnPointComponent.EnemyPrefab, entity.EnemySpawnPointComponent.gameObject.transform.position, entity.EnemySpawnPointComponent.gameObject.transform.localRotation);
                    entity.EnemySpawnPointComponent.timeSinceLastSpawn = Time.time;
                }
            }
        }
    }
}