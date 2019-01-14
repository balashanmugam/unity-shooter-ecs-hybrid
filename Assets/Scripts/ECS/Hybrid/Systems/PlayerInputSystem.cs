using ECS.Hybrid.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Systems {
    public class PlayerInputSystem : ComponentSystem {

        private struct Data {
            public readonly int Length;
            public ComponentArray<InputComponent> InputComponents;
        }
        [Inject] private Data _data;

        protected override void OnUpdate() {
            var horizontal = Input.GetAxis("Horizontal");

            for (int i = 0; i < _data.Length; i++) {
                _data.InputComponents[i].Horizontal = horizontal;
            }
        }
    }
}