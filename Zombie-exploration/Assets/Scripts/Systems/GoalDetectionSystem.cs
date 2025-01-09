using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Collections;


namespace TMG.Zombies
{
    [BurstCompile]
    public partial struct GoalDetectionSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (goalTransform, goalEntity) in SystemAPI.Query<LocalTransform>().WithEntityAccess().WithAll<GoalComponent>())
            {
                foreach (var playerTransform in SystemAPI.Query<LocalTransform>().WithAll<PlayerTag>())
                {
                    if (math.distance(playerTransform.Position, goalTransform.Position) < 1f)
                    {
                        ecb.DestroyEntity(goalEntity);
                        break;
                    }
                }
            }

            ecb.Playback(state.EntityManager);
            ecb.Dispose();
        }
    }
}
