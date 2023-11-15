using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cyclope : MonoBehaviour
{
    private float maxPositionX = 4f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(-6f, 5);
        Debug.Log("Start position");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < maxPositionX)
        {
            rb.MovePosition(new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y));
            Debug.Log("Moving");
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
