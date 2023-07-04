using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnGround : MonoBehaviour
{
    [SerializeField] private float spawnPointZ;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DespawnTrigger"))
        {
            transform.parent.localPosition = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y, spawnPointZ);
        }
    }
}
