using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Skull : Monster
{
    [SerializeField]
    private Rigidbody2D rb;

    Skull()
    {
        maxPositionY = -10f;
        speed = -0.03f;
    }

    new private void Start()
    {
        shoot();
    }

    void Update()
    {
        if (gameObject.transform.position.y > maxPositionY)
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void shoot()
    {
        Instantiate(weapon, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
    }
}