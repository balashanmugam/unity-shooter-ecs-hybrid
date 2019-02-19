using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Components
{
    public class CollisionEmitter : MonoBehaviour
    {
        void OnCollisionEnter(UnityEngine.Collision collisionInfo)
        {
            GameObjectEntity otherGameObjectEntity = collisionInfo.gameObject.GetComponent<GameObjectEntity>();
            if (!otherGameObjectEntity)
            {
                return;
            }
            Entity sourceEntity = GetComponent<GameObjectEntity>().Entity;
            var entityManager = World.Active.GetExistingManager<EntityManager>();
            //Debug.Log("before creating!!");

            Entity collisionEventEntity = entityManager.CreateEntity(typeof(CollisionData));
            var tempObj = new GameObject();


            var data = tempObj.AddComponent<CollisionData>();
            data.source = this.gameObject;
            data.other = collisionInfo.gameObject;
            //entityManager.SetComponentData(collisionEventEntity,
            GameObjectEntity.AddToEntityManager(entityManager,tempObj);
            //Debug.Log("after setting");
        }
    }
}