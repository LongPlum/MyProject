using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    private float scrollSpeed = 10f;
    
    void Update()
    {
        transform.Translate(scrollSpeed * Time.deltaTime * Vector3.back);
    }
}
