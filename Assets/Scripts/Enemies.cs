using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected int health;
    protected int timerBuffer = 0;
    protected int timer;

    [SerializeField]
    protected GameObject weapon;

    [SerializeField]
    private AudioClip dieSoundAudio;

    [SerializeField]
    private AudioClip damageSoundAudio;

    [SerializeField]
    private float volume;

    protected float maxPositionY;
    protected float maxPositionX;
    protected float minPositionY;
    protected float minPositionX;
    protected float speedX;
    protected float speedY;

    public void setHealth(int health) { this.health = health; }
    public void setMaxPositionX(float maxPositionX) { this.maxPositionX = maxPositionX; }
    public void setMaxPositionY(float maxPositionY) { this.maxPositionY = maxPositionY; }
    public void setMinPositionX(float minPositionX) { this.minPositionX = minPositionX; }
    public void setMinPositionY(float minPositionY) { this.minPositionY = minPositionY; }
    public void setSpeedX(float speedX) { this.speedX = speedX; }
    public void setSpeedY(float speedY) { this.speedY = speedY; }
    public void setTimer(int timer) { this.timer = timer; }

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
