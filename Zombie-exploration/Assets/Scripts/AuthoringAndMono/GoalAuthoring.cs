using Unity.Entities;
using UnityEngine;

namespace TMG.Zombies
{
    public class GoalAuthoring : MonoBehaviour
    {
        public GameObject CubePrefab;

        class Baker : Baker<GoalAuthoring>
        {
            public override void Bake(GoalAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var prefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic);

                AddComponent(entity, new GoalPrefabComponent { Prefab = prefab });
            }
        }
    }
}
