using ECS.Hybrid.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace ECS.Hybrid.Systems {
    public class PlayerShootingSystem : JobComponentSystem {

        private struct PlayerShootingJob : IJobParallelFor {
            [ReadOnly] public EntityArray EntityArray;
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;
            public float CurrentTime;

            public void Execute(int index) {
                EntityCommandBuffer.AddComponent(index, EntityArray[index], new Firing { FiredAt = CurrentTime });
            }
        }

        private struct Data {
            public readonly int Length;
            public EntityArray Entites;
            public ComponentDataArray<Weapon> Weapons;
            public SubtractiveComponent<Firing> Firings;
        }

        [Inject] private Data _data;
        [Inject] private PlayerShootingBarrier _barrier;

        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            if (Input.GetButton("Fire1")) {
                return new PlayerShootingJob {
                    EntityArray = _data.Entites,
                    EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent(),
                    CurrentTime = Time.time
                }.Schedule(_data.Length, 64, inputDeps);
            }
            return base.OnUpdate(inputDeps);
        }
    }

    public class PlayerShootingBarrier : BarrierSystem {

    }
}
