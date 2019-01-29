using ECS.Hybrid.Components;
using Unity.Entities;
using UnityEditorInternal;
using UnityEngine;

namespace ECS.Hybrid.Systems
{
    public class MoveForwardSystem : ComponentSystem
    {

        private struct Filter
        {
            public BulletSpeedComponent Bulletspeed;
            public Rigidbody Rigidbody;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>() )
            {
                var pos = entity.Rigidbody.position;
                var newZPos = entity.Rigidbody.position.z + entity.Bulletspeed.Value * Time.fixedDeltaTime;
                entity.Rigidbody.MovePosition(new Vector3(pos.x,pos.y,newZPos));
            }
        }
    }
}
