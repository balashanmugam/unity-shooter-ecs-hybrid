using ECS.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Systems{
    public class CollisionSystem : ComponentSystem
    {
        private struct Filter{
            public CollisionData CollisionData;
        }
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var sourceObject = entity.CollisionData.source;
                var collidedObject = entity.CollisionData.other;
                // Receiving already collided data.
                if(collidedObject.tag == "Enemy"){
                    Debug.Log("Enemy Collision!");
                    Object.Destroy(sourceObject,0.0f);
                    Object.Destroy(collidedObject,0.1f);

                }
            } 
        }


    }
}