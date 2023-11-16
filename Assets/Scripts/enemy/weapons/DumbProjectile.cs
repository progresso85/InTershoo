using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DumbProjectile : bulletBase
{
    DumbProjectile()
    {
        speed = 0.2f;
        speed *= -1; // :3
    }

    private void Update()
    {
        rb.MovePosition(rb.position + new Vector2(
            (0 * Mathf.Cos(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z) - speed * Mathf.Sin(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z)),
            (0 * Mathf.Sin(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z) + speed * Mathf.Cos(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z))
        ));
    }
}