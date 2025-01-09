using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace TMG.Zombies
{
    public class PlayerAuthoring : MonoBehaviour
    {
        public float Speed = 5f;

        class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent<PlayerComponent>(entity);

                AddComponent(entity, new PlayerMovementComponent
                {
                    Speed = authoring.Speed,
                    Direction = float3.zero
                });

                AddComponent(entity, new LocalTransform
                {
                    Position = new float3(0f, 1f, 0f),
                    Rotation = quaternion.identity,
                    Scale = 1f
                });

                AddComponent<LocalToWorld>(entity);

                AddComponent<PlayerTag>(entity);
            }
        }
    }

    public struct PlayerComponent : IComponentData
    {
    }
}
