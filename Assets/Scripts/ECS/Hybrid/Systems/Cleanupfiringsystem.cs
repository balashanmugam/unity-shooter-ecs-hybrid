using System;
using Unity.Entities;
using UnityEngine;
using ECS.Hybrid.Components;

namespace ECS.Hybrid.Systems
{
    public class Cleanupfiringsystem : ComponentSystem {
        private struct Filter {
            public InputComponent InputComponent;
        }

        protected override void OnUpdate(){
            float time = Time.time;
            float rateOfFire = 0.01f;
            foreach (var entity in GetEntities<Filter>())            {
                if(entity.InputComponent.isFired == true && time - entity.InputComponent.startFireTime >= rateOfFire){
                    entity.InputComponent.isFired = false;
                }
            }
        }
    }
}