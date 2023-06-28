using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    private float scrollSpeed = 10f;
    
    

    

    void Start()
    {
    }
     
    void Update()
    {
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);
    }

 


}
