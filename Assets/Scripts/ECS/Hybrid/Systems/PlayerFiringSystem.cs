using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Systems
{
    public class PlayerFiringSystem : ComponentSystem
    {
        private struct Filter
        {
            public InputComponent InputComponent;

        }
        protected override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                foreach (var entity in GetEntities<Filter>())
                {
                    if (entity.InputComponent.isFired == false && Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "Player") 
                        {
                            entity.InputComponent.isFired = true;
                            entity.InputComponent.startFireTime = Time.time;
                            Object.Instantiate(entity.InputComponent.BulletPrefab,hit.collider.attachedRigidbody.transform.position,hit.collider.attachedRigidbody.transform.rotation);
                        }
                    }
                }
            }
        }
    }
}
