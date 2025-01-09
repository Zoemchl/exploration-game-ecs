using Unity.Entities;
using Unity.Mathematics;

namespace TMG.Zombies
{
    public struct PlayerMovementComponent : IComponentData
    {
        public float Speed;
        public float3 Direction;
    }
}
