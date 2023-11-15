using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int health = 1;

    [SerializeField]
    protected GameObject EnemyBullet;
    protected float maxPositionY;
    protected float maxPositionX;
    protected float speed;
    [SerializeField]
    private AudioClip DamageSoundClip;

    [SerializeField]
    private AudioClip DieSoundClip;

    private AudioSource audioSource;
    
    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.collider.tag == "Player" || collision.collider.tag == "PlayerBullet"))
        {

        }
        else
        {
            // Debug.Log("Collision");
            health -= 1;
            audioSource.clip = DamageSoundClip;
            audioSource.Play();

            if (health == 0)
            {
                audioSource.clip = DieSoundClip;
                audioSource.Play();
                audioSource.clip = DamageSoundClip;
                audioSource.Play();
                Destroy(this.gameObject);
            }
        }
    }
}
