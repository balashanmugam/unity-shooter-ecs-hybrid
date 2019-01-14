using Unity.Rendering;
using UnityEngine;

namespace ECS.Hybrid {
    public class Bootstrap : MonoBehaviour {

        public static MeshInstanceRenderer BulletRenderer;
        public static Material BulletMaterial;

        [SerializeField] private MeshInstanceRenderer _bullet;

        private void Awake() {
            BulletRenderer = _bullet;
        }
    }
}
