using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ObstaclePool obstaclePool;
    private PlayerHP playerHP;

    private void Start()
    {
        playerHP = gameObject.GetComponent<PlayerHP>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject.CompareTag("Obstacle"))
        {
            playerHP.TakeDamage(1);
            obstaclePool.ReleaseObstacle(other.gameObject);
        }
    }
}
