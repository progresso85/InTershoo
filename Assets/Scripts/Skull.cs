using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private float maxPositionY = -10f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(-3, 9);
        Debug.Log("Start position");
    }

    // Update is called once per frame
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

