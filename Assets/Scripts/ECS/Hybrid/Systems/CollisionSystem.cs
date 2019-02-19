using ECS.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Systems{
    public class CollisionSystem : ComponentSystem
    {

        public struct Filter{
            public CollisionData CollisionData;
        }
        protected override void OnUpdate()
        {
            foreach(var entity in GetEntities<Filter>()){
                //Destroy both game objects
                Object.Destroy(entity.CollisionData.source);
                Object.Destroy(entity.CollisionData.other);
            }
        }
    }
}