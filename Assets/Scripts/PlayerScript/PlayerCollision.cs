using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] ObstaclePool obstaclePool;
    [SerializeField] float knockBackDuration;
    [SerializeField] float knockBackDistance;

    private PlayerHP playerHP;
    public event Action<float> OnPlayerCollision;

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


            foreach (var Obstacle in obstaclePool.ObstacleOnScene)
            {
                var movementComponent = Obstacle.GetComponent<DirectionMovement>();
                var obstacleSpeed = movementComponent.obstacleMoveSpeed;
                movementComponent.obstacleMoveSpeed = 0;

                Obstacle.transform.DOMoveZ(Obstacle.transform.position.z + knockBackDistance, knockBackDuration)
                    .SetEase(Ease.OutExpo)
                    .Play()
                    .SetAutoKill(true)
                    .OnUpdate (() => movementComponent.obstacleMoveSpeed = obstacleSpeed)
                    .OnKill(() => movementComponent.obstacleMoveSpeed = obstacleSpeed);
            }

            OnPlayerCollision.Invoke(knockBackDuration);

        }
    }
}
