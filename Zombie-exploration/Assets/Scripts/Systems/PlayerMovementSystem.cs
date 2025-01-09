using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace TMG.Zombies
{
    [BurstCompile]
    public partial struct PlayerMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var (movement, transform) in SystemAPI.Query<RefRW<PlayerMovementComponent>, RefRW<LocalTransform>>().WithAll<PlayerTag>())
            {
                var input = float3.zero;

                if (Input.GetKey(KeyCode.UpArrow)) input.z += 1f;
                if (Input.GetKey(KeyCode.DownArrow)) input.z -= 1f;
                if (Input.GetKey(KeyCode.LeftArrow)) input.x -= 1f;
                if (Input.GetKey(KeyCode.RightArrow)) input.x += 1f;

                if (!math.any(input))
                {
                    movement.ValueRW.Direction = float3.zero;
                }
                else
                {
                    movement.ValueRW.Direction = math.normalize(input);
                }
                transform.ValueRW.Position += movement.ValueRO.Direction * movement.ValueRO.Speed * deltaTime;
            }
        }
    }
}
