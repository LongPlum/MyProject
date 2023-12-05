using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int playerHP;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
           playerHP =- damage;
        }
    }

    private void Update()
    {
        if (playerHP <= 0)
        {
            //game over
        }
    }
}
