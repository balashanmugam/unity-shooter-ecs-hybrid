using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Components
{
    public struct CollisionData : IComponentData
    {
        public GameObject source;
        public GameObject other;
    }

    public class CollisionComponent : MonoBehaviour
    {
        void OnCollisionEnter(Collision collisionInfo)
        {
            var otherEntity = collisionInfo.gameObject.GetComponent<GameObjectEntity>();
            if (!otherEntity) return;

            var sourceEntity = this.GetComponent<GameObjectEntity>();

            var entityManager = World.Active.GetExistingManager<EntityManager>();
            Entity collisionEventEntity = entityManager.CreateEntity(typeof(CollisionData));
            entityManager.SetComponentData(collisionEventEntity, new CollisionData
            {
                source = sourceEntity.gameObject,
                other = otherEntity.gameObject
            });
        }
    }
}