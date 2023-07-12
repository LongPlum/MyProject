using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMovement : MonoBehaviour
{
    public float obstacleMoveSpeed { get; set; }

    void Update()
    {
        transform.Translate(obstacleMoveSpeed * Time.deltaTime * Vector3.back);
    }
}
