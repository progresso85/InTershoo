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
    private float speed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private AudioClip shotSoundClip;

    [SerializeField]
    private float volume = 1f;

    // number of shot/second
    [SerializeField]
    private float shotsPerMinute;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement = Vector2.zero;
    }

    void Update()
    {
            nextAttackTime -= Time.deltaTime;
            if( nextAttackTime <= 0)
            {
                if (Keyboard.current.spaceKey.isPressed)
                {
                    Shoot();
                }

                GameObject boss = GameObject.Find("Boss");

                if(boss != null)
                {
                //  float distanceToTheBoss = boss.transform;
                //  float angleProjectileLeft = Mathf.Sin(()/());
                    
                    Instantiate(Bullet, rb.position + new Vector2(-0.5f, 0f), Quaternion.Euler(0f, 0f, 0f));
                    Instantiate(Bullet, rb.position + new Vector2(0.5f, 0f), Quaternion.Euler(0f, 0f, 0f));
                }
                
                nextAttackTime = (1/shotsPerMinute);

            }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.collider.tag == "Wall" || collision.collider.tag == "PlayerBullet"))
        {
            // Destroy(gameObject);
        }
    }
    private void Shoot()
    {
        for(int i = -10; i <= 10; i += 10)
        {
            Instantiate(Bullet, rb.position + new Vector2(0, 0.5f), Quaternion.Euler(0f, 0f, i));
        }
        AudioSource.PlayClipAtPoint(shotSoundClip, transform.position, volume);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // sneak to reduce speed

        // do a listener on the key W, on press "input System V2"

        if (Keyboard.current.wKey.isPressed)
        { // Y +
            movement.y += speed;
            position = rb.position;
        }

        if (Keyboard.current.aKey.isPressed)
        { // X -
            movement.x -= speed;
            position = rb.position;
        }

        if (Keyboard.current.sKey.isPressed)
        { // Y -
            movement.y -= speed;
            position = rb.position;
        }

        if (Keyboard.current.dKey.isPressed)
        { // X +
            movement.x += speed;
            position = rb.position;
        }

        movement.Normalize();
        if(Keyboard.current.shiftKey.isPressed)
        {
            movement *= speed / 2;
        }
        else
        {
            movement *= speed;
        }

        if (movement != null || movement != Vector2.zero) {
            rb.MovePosition(rb.position + movement);
        }
        movement = Vector2.zero;

    }
}
