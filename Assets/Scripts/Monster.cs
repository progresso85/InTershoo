using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int health = 1;
    protected int timerBuffer;
    protected int timer = 750;

    [SerializeField]
    protected GameObject weapon;

    [SerializeField]
    private AudioClip dieSoundAudio;

    [SerializeField]
    private AudioClip damageSoundAudio;

    [SerializeField]
    private float volume;

    protected Fire Fire;
    protected float maxPositionY;
    protected float maxPositionX;
    protected float speed;
    
    protected void Start()
    {
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(!(collision.collider.tag == "Player" || collision.collider.tag == "PlayerBullet"))
        {

        }
        else
        {
            // Debug.Log("Collision");
            AudioSource.PlayClipAtPoint(damageSoundAudio, transform.position, volume);
            health -= 1;

            if (health == 0)
            {
                AudioSource.PlayClipAtPoint(dieSoundAudio, transform.position, volume);
                Destroy(this.gameObject);
            }
        }
    }
}
