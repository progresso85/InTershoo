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
        Fire = new Fire("simple");
        maxPositionY = -10f;
        speed = -0.03f;
    }

    void Update()
    {
        if (gameObject.transform.position.y > maxPositionY)
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed));
            Debug.Log("Moving");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

