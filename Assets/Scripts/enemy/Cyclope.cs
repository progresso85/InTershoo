using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cyclops : Monster
{
    [SerializeField]
    private Rigidbody2D rb;

    Cyclops()
    {
        maxPositionX = 4f;
        health = 10;
        speed = 0.05f;
        timer = 200;
        timerBuffer = 0;
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

        if((timerBuffer -= (int)(Time.deltaTime * 1000)) <= 0)
        {
            shoot();
            timerBuffer = timer;
        }
    }

    void shoot()
    {
        for(int i = 0; i <= 360; i+=20)
        {
            Instantiate(weapon, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.Euler(0f, 0f, i));
        }
    }
}