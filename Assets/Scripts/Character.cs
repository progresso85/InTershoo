using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 movement;
    private Vector2 position;
    [SerializeField]
    private GameObject Bullet;

    [SerializeField] 
    private GameObject Monster;

    [SerializeField]
    private GameObject Monster2;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(Bullet, rb.position + new Vector2(0, 0.5f), Quaternion.identity);
            Debug.Log("SHOT");
            Debug.Log(rb.position);
            Debug.Log(speed);
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Instantiate(Monster, new Vector2(2, 2), Quaternion.identity);
            Instantiate(Monster2, new Vector2(-2, 2), Quaternion.identity);
            Instantiate(Monster, new Vector2(-2, -2), Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.collider.tag == "Wall" || collision.collider.tag == "PlayerBullet"))
        {
            Debug.Log(collision.collider.tag);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        
        // sneak to reduce speed 
        // normalise vector in the futur (IMPORTANT)

        // do a listener on the key W, on press "input System V2"

        if (Keyboard.current.wKey.isPressed)
        { // Y +
            movement = Vector2.zero;
            Debug.Log("AVANCER");
            movement += rb.position + new Vector2(0, speed);
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.aKey.isPressed)
        { // X -
            movement = Vector2.zero;
            Debug.Log("GAUCHE");
            movement += rb.position + new Vector2(-speed, 0);
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.sKey.isPressed)
        { // Y -
            movement = Vector2.zero;
            Debug.Log("BAS");
            movement += rb.position + new Vector2(0, -speed);
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.dKey.isPressed)
        { // X +
            movement = Vector2.zero;
            Debug.Log("DROITE");
            movement += rb.position + new Vector2(speed, 0);
            rb.MovePosition(movement);
            position = rb.position;
        }


        
    }
}
