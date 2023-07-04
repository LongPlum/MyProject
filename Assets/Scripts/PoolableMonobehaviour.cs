using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PoolableMonobehaviour : MonoBehaviour
{
    public abstract void Setup(Vector3 vector3);
    public abstract void Release();
}
