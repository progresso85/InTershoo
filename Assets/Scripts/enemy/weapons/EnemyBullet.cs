using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    protected float speed;
    [SerializeField]
    protected Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.collider.tag == "Monster" || collision.collider.tag == "EnemyBullet"))
        {
            // Debug.Log("Collision");
            Destroy(gameObject);
        }
    }
}
