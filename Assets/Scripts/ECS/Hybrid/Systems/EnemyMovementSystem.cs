using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Systems{

    public class EnemyMovementSystem : ComponentSystem
    {
        private struct Filter{
            public EnemyMovementSpeedComponent  EnemyMovementSpeedComponent;
            public Rigidbody Rigidbody;
        }
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var pos = entity.Rigidbody.position;
                var newZPos = entity.Rigidbody.position.z + entity.EnemyMovementSpeedComponent.Value * Time.fixedDeltaTime;
                entity.Rigidbody.MovePosition(new Vector3(pos.x, pos.y, newZPos));
            }
        }
    }

}