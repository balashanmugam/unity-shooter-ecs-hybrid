using ECS.Hybrid.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace ECS.Hybrid.Systems {
    public class CleanupFiringSystem : JobComponentSystem {

        private struct CleanupFiringJob : IJobParallelFor {
            [ReadOnly] public EntityArray Entities;
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;
            public float CurrentTime;
            public ComponentDataArray<Firing> Firings;

            public void Execute(int index) {
                if (CurrentTime - Firings[index].FiredAt < 0.5f) return;
                EntityCommandBuffer.RemoveComponent<Firing>(index, Entities[index]);
            }
        }

        private struct Data {
            public readonly int Length;
            public EntityArray Entities;
            public ComponentDataArray<Firing> Firings;
        }

        [Inject] private Data _data;
        [Inject] private CleanupFiringBarrier _barrier;

        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            return new CleanupFiringJob {
                Entities = _data.Entities,
                EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent(),
                CurrentTime = Time.time,
                Firings = _data.Firings,

            }.Schedule(_data.Length, 64, inputDeps);
        }
    }

    public class CleanupFiringBarrier : BarrierSystem { }
}
