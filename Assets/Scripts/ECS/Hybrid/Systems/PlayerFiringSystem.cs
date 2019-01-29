using System;
using System.Linq.Expressions;
using Unity.Entities;
using UnityEngine;

namespace ECS.Hybrid.Systems {
    public class PlayerFiringSystem : ComponentSystem {

        private struct Filter {
            public InputComponent InputComponent;
            public BoxCollider BoxCollider;
        }
        protected override void OnUpdate() {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                foreach (var entity in GetEntities<Filter>()) {
                    if (Physics.Raycast(ray, out hit)) {
                        if (hit.transform.tag == "Player") {
                            Debug.Log("Player 1 Fire");
                            entity.InputComponent.isFired = true;
                        }
                    }
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                RaycastHit hit;
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                foreach (var entity in GetEntities<Filter>()) {
                    if (Physics.Raycast(ray, out hit)) {
                        if (hit.transform.tag == "Player") {
                            Debug.Log("Player 1 unfired");
                            entity.InputComponent.isFired = false;
                        }
                    }
                }
            }
        }
    }
}
