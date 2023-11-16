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

    [SerializeField]
    private AudioClip shotSoundClip;

    [SerializeField]
    private float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.collider.tag == "Wall" || collision.collider.tag == "PlayerBullet"))
        {
            // Debug.Log(collision.collider.tag);
            Destroy(gameObject);
        }
    }
    private void Shoot()
    {
        Instantiate(Bullet, rb.position + new Vector2(0, 0.5f), Quaternion.identity);
        AudioSource.PlayClipAtPoint(shotSoundClip, transform.position, volume);
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
            // Debug.Log("AVANCER");
            movement += rb.position + new Vector2(0, speed);
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.aKey.isPressed)
        { // X -
            movement = Vector2.zero;
            // Debug.Log("GAUCHE");
            movement += rb.position + new Vector2(-speed, 0);
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.sKey.isPressed)
        { // Y -
            movement = Vector2.zero;
            // Debug.Log("BAS");
            movement += rb.position + new Vector2(0, -speed);
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.dKey.isPressed)
        { // X +
            movement = Vector2.zero;
            // Debug.Log("DROITE");
            movement += rb.position + new Vector2(speed, 0);
            rb.MovePosition(movement);
            position = rb.position;
        }
    }
}
