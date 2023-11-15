using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cyclops : Monster
{
    [SerializeField]
    private Rigidbody2D rb;

    Cyclops()
    {
        maxPositionX = 6f;
        health = 10;
        speed = 0.03f;
    }

    new private void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.position.x < maxPositionX)
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y));
        }
        else
        {
            Destroy(gameObject);
        }
    }
}