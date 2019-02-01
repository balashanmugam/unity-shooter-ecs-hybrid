using Unity.Entities;
using UnityEngine;
namespace ECS.Hybrid.Components
{

    public class BulletSpawnPointComponent : MonoBehaviour
    {
        [SerializeField]
        public GameObject BulletPrefab;
    }
}