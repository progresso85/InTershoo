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
        rb.MovePosition(rb.position + new Vector2(
            (0 * Mathf.Cos(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z) - speed * Mathf.Sin(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z)),
            (0 * Mathf.Sin(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z) + speed * Mathf.Cos(Mathf.Deg2Rad * this.transform.rotation.eulerAngles.z))
        ));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.collider.tag == "Player" || collision.collider.tag == "PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
