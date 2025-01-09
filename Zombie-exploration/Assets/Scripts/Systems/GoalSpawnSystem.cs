using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace TMG.Zombies
{
    [BurstCompile]
    public partial struct GoalSpawnSystem : ISystem
    {
        private Unity.Mathematics.Random _random;

        public void OnCreate(ref SystemState state)
        {
            _random = new Unity.Mathematics.Random(1);
        }

        public void OnUpdate(ref SystemState state)
        {

            bool goalExists = false;
            foreach (var _ in SystemAPI.Query<GoalComponent>())
            {
                goalExists = true;
                break;
            }

            if (!goalExists)
            {
                Entity goalEntity = state.EntityManager.Instantiate(SystemAPI.GetSingleton<GoalPrefabComponent>().Prefab);

                state.EntityManager.AddComponent<GoalComponent>(goalEntity);
                state.EntityManager.SetComponentData(goalEntity, new LocalTransform
                {
                    Position = new float3(_random.NextFloat(-10f, 10f), 0.5f, _random.NextFloat(-10f, 10f)),
                    Rotation = quaternion.identity,
                    Scale = 1f
                });
            }
        }
    }

    public struct GoalPrefabComponent : IComponentData
    {
        public Entity Prefab;
    }
}
