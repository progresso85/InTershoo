using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int health = 1;

    [SerializeField]
    protected GameObject EnemyBullet;

    protected Fire Fire;
    protected float maxPositionY;
    protected float maxPositionX;
    protected float speed;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.collider.tag == "Player" || collision.collider.tag == "PlayerBullet"))
        {

        }
        else
        {
            Debug.Log("Collision");
            health -= 1;
            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
