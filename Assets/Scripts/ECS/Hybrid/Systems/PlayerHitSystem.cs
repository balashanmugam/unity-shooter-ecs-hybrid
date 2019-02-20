using Unity.Entities;
using ECS.Hybrid.Components;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace ECS.Hybrid.Systems
{
    public class PlayerHitSystem : ComponentSystem
    {
        public struct Data
        {
            public readonly int Length;
            public ComponentArray<PlayerHitComponent> PlayerHits;
            public EntityArray Entites;

        }
        IEnumerator ExecuteAfterTime(float time, Action task)
        {
            yield return new WaitForSeconds(time);
            task();
        }

        [Inject] private Data _data;
        protected override void OnUpdate()
        {
            for (int i = 0; i < _data.Length; i++)
            {

                if (_data.PlayerHits[i].isHit == true)
                {
                    //Freeze gameplay
                    Time.timeScale = 0;
                    // End game #endregion
                    // Display endscreen.
                }
            }
            //throw new System.NotImplementedException();
        }
    }
}