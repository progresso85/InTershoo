using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
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

    // number of shot/second
    public float attackSpeed;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement = Vector2.zero;
        attackSpeed = 5f;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            nextAttackTime -= Time.deltaTime;
            Debug.Log(nextAttackTime);
            if( nextAttackTime <= 0)
            {
                Shoot();
                nextAttackTime = (1/attackSpeed);
            }
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
            
            // Debug.Log("AVANCER");
            movement.y += speed;
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.aKey.isPressed)
        { // X -
            // Debug.Log("GAUCHE");
            movement.x -= speed;
            position = rb.position;
        }

        if (Keyboard.current.sKey.isPressed)
        { // Y -
            // Debug.Log("BAS");
            movement.y -= speed;
            rb.MovePosition(movement);
            position = rb.position;
        }

        if (Keyboard.current.dKey.isPressed)
        { // X +
            // Debug.Log("DROITE");
            movement.x += speed;
            rb.MovePosition(movement);
            position = rb.position;
        }
        movement.Normalize();
        movement = movement * speed;
        if (movement != null || movement != Vector2.zero) {
            rb.MovePosition(rb.position + movement);
        }
        movement = Vector2.zero;
    }
}
