using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    int health;

    [SerializeField]
    private GameObject EnemyBullet;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
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
