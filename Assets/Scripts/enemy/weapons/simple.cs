using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : EnemyBullet
{
    SimpleProjectile()
    {
        speed = 1f;
    }

    private void Update()
    {
        rb.MovePosition(rb.position + new Vector2(0, -speed));
    }
}