using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Obstacle : PoolableMonobehaviour
{
    private Transform obstacleTransform;

    private Rigidbody obstacleRigidBody;

    private MeshRenderer obstacleMeshRenderer;

    private Collider obstacleCollider;

    public Transform ObstacleTransform => obstacleTransform;
    public Rigidbody ObstacleRigidBody => obstacleRigidBody;
    public MeshRenderer ObstacleMeshRenderer => obstacleMeshRenderer;
    public Collider ObstacleCollider => obstacleCollider;
    public bool IsReset => CheckReset();

    public void Reset()
    {
        obstacleTransform = null;
        obstacleRigidBody = null;
        obstacleMeshRenderer = null;
        obstacleCollider = null;
    }

    private bool CheckReset()
    {
        if (!obstacleTransform && !obstacleRigidBody && !obstacleMeshRenderer && !obstacleCollider)
        {
            return true;
        }
        return false;
    }
}

