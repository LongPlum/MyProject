using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    private float scrollSpeed = 10f;
    private BoxCollider boxCollider;
    
    

    

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
     
    void Update()
    {
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);
    }

 


}
