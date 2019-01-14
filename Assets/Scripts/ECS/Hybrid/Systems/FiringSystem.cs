using ECS.Hybrid.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace ECS.Hybrid.Systems {
    public class FiringSystem : JobComponentSystem {
        [Inject] private FiringBarrier _barrier;

        protected override JobHandle OnUpdate(JobHandle inputDeps) {
            return new FiringJob {
                EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent(),
            }.Schedule(this, inputDeps);
        }
        public struct FiringJob : IJobProcessComponentData<Firing, Position, Rotation> {

            public EntityCommandBuffer.Concurrent EntityCommandBuffer; 
            public void Execute( ref Firing firing, ref Position position, ref Rotation rotation) {
            }
        }
        private class FiringBarrier : BarrierSystem {

        }

    }
}
