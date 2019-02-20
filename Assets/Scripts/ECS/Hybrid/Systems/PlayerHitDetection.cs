using ECS.Hybrid.Components;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour
{

    void OnTriggerEnter(UnityEngine.Collider collisionInfo)
    {
        Debug.Log("Getting hit!!");
        var playerHitComponent = this.gameObject.GetComponent<PlayerHitComponent>();

        Debug.Log(playerHitComponent == null);
        playerHitComponent.isHit = true;
    }

}