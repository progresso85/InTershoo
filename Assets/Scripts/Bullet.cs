using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + new Vector2(0, speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.collider.tag == "Player" || collision.collider.tag == "PlayerBullet"))
        {
            Debug.Log("Collision");
            Destroy(gameObject);
        }
    }
}
